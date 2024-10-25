using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dischadum
{
    public static class Core
    {
        public class DiscordGuild
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<DiscordChannel>? Channels { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Id})";
            }
        }

        public class DiscordChannel
        {
            public string rawMessages;

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public int Type { get; set; }

            [JsonPropertyName("recipients")]
            public List<DiscordSender>? Recipients { get; set; }

            public List<DiscordMessage>? Messages { get; set; }

            public override string ToString()
            {
                if (string.IsNullOrEmpty(Name) && Recipients != null && Recipients.Count > 0)
                {
                    var name = "";

                    foreach(var recipient in Recipients)
                    {
                        if(name.Length > 0)
                        {
                            name += ", ";
                        }

                        name += recipient.Username;
                    }

                    Name = name;
                }

                return $"[{Type}] {Name} ({Id})";
            }
        }

        public class DiscordMessage
        {
            [JsonPropertyName("author")]
            public DiscordSender Author { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("timestamp")]
            public string Time { get; set; }

            [JsonPropertyName("edited_timestamp")]
            public string EditedTime { get; set; }

            public override string ToString()
            {
                return Author.ToString() + $" ({Time}): " + Content;
            }
        }

        public class DiscordSender
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("username")]
            public string Username { get; set; }

            [JsonPropertyName("global_name")]
            public string GlobalName { get; set; }

            public override string ToString()
            {
                return Username;
            }
        }

        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan _delay = TimeSpan.FromMilliseconds(250);

        private static HttpResponseMessage GetRequest(this HttpClient client, string url)
        {
            var task = client.GetAsync(url);
            {
                if (!task.Wait(_timeout)) throw new TimeoutException();
            }

            return task.Result;
        }

        private static string GetAnswerText(this HttpResponseMessage response)
        {
            var task = response.Content.ReadAsStringAsync();
            {
                if (!task.Wait(_timeout)) throw new TimeoutException();
            }

            return task.Result;
        }

        public static HttpClient OpenClient(string userToken)
        {
            var client = new HttpClient();
            {
                client.DefaultRequestHeaders.Add("Authorization", userToken);
                userToken = null;
            }

            return client;
        }

        public static void CloseClient(ref HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = null;
            client.DefaultRequestHeaders.Clear();

            client = null;
        }

        public static DiscordGuild? GetGuildInfo(HttpClient client, string guildId)
        {
            var url = $"https://discord.com/api/v9/guilds/{guildId}";
            var response = client.GetRequest(url);
            if (response.IsSuccessStatusCode)
            {
                var guildData = response.GetAnswerText();
                using var doc = JsonDocument.Parse(guildData);

                return new DiscordGuild
                {
                    Id = guildId,
                    Name = doc.RootElement.GetProperty("name").GetString(),
                    Channels = GetGuildChannels(client, guildId)
                };
            }

            return null;
        }

        public static DiscordChannel? GetChannelInfo(HttpClient client, string channelId)
        {
            var url = $"https://discord.com/api/v9/channels/{channelId}";
            var response = client.GetRequest(url);
            if (response.IsSuccessStatusCode)
            {
                var channelData = response.GetAnswerText();
                using var doc = JsonDocument.Parse(channelData);

                return JsonSerializer.Deserialize<DiscordChannel>(channelData);
            }

            return null;
        }

        public static List<DiscordChannel>? GetGuildChannels(HttpClient client, string guildId)
        {
            var url = $"https://discord.com/api/v9/guilds/{guildId}/channels";
            var response = client.GetRequest(url);

            if (response.IsSuccessStatusCode)
            {
                var channelData = response.GetAnswerText();
                return JsonSerializer.Deserialize<List<DiscordChannel>>(channelData);
            }
            else
            {
                Trace.TraceError($"Error while getting guild {guildId} channels: {response.StatusCode}");
            }

            return null;
        }

        public static List<DiscordMessage> GetChannelMessages(HttpClient client, string channelId, ref bool state, ref string raw)
        {
            raw = null;

            var messages = new List<DiscordMessage>();
            string before = null;

            while (state)
            {
                var url = $"https://discord.com/api/v9/channels/{channelId}/messages?limit=100" +
                          (before != null ? $"&before={before}" : "");

                var response = client.GetRequest(url);
                if (response.IsSuccessStatusCode)
                {
                    var messageData = response.GetAnswerText();
                    var batch = JsonSerializer.Deserialize<List<DiscordMessage>>(messageData);

                    if (batch.Count == 0) break;

                    raw += messageData;

                    messages.AddRange(batch);

                    before = batch[^1].Id;

                    Thread.Sleep(_delay); 
                }
                else if ((int)response.StatusCode == 429)
                {
                    var retryAfter = response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 1;

                    Trace.TraceInformation($"API request limit has been exceeded, retrying after {retryAfter} secounds");

                    Thread.Sleep((int)(retryAfter * 1000));
                }
                else
                {
                    Trace.TraceError($"Error while getting channel {channelId} messages: {response.StatusCode}; {response.GetAnswerText()}");
                    
                    break;
                }
            }

            if (!string.IsNullOrEmpty(raw))
            {
                raw = JsonSerializer.Serialize(JsonDocument.Parse(raw), new JsonSerializerOptions { 
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }

            return messages;
        }

        public static async Task SaveMessagesToFile(string directory, string channelName, List<DiscordMessage> messages)
        {
            var filePath = Path.Combine(directory, $"{channelName}.json");
            var options = new JsonSerializerOptions { WriteIndented = true };

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(stream, messages, options);
            }
        }

    }
}
