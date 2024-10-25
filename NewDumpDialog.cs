using System.Data;

namespace dischadum
{
    public partial class NewDumpDialog : Form
    {
        public delegate bool ApplyCallback(HttpClient client, Core.DiscordGuild guild, List<Core.DiscordChannel> targetedChannels);

        private HttpClient? _client = null;
        private Core.DiscordGuild? _guild = null;

        private bool _Channel
        {
            get => checkBoxChannel.Checked;
            set => checkBoxChannel.Checked = value;
        }

        private List<Core.DiscordChannel> _TargetedChannels => checkedListBox.CheckedItems.Cast<Core.DiscordChannel>().ToList();

        public ApplyCallback Callback { get; set; }

        public NewDumpDialog(bool targetSingleChannel, ApplyCallback applyCallback)
        {
            InitializeComponent();

            Callback = applyCallback;

            _Channel = targetSingleChannel;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            var element = sender as Button;

            try
            {
                if (_client != null)
                {
                    Core.CloseClient(ref _client);
                }

                var client = _client = Core.OpenClient(textBoxToken.Text);
                if (client == null) throw new Exception("Can't open http client");

                var channels = (List<Core.DiscordChannel>)null;
                if (_Channel)
                {
                    var channel = Core.GetChannelInfo(client, textBoxTargetId.Text);
                    if (channel == null) throw new Exception("Can't get channel info");

                    channels = new List<Core.DiscordChannel>() { channel };
                }
                else
                {
                    var guild = _guild = Core.GetGuildInfo(client, textBoxTargetId.Text);
                    if (guild == null) throw new Exception("Can't get guild info");

                    channels = guild.Channels;
                }

                if (channels == null || channels.Count == 0) throw new Exception("Can't get channels");

                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(channels.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var channels = _TargetedChannels;

            if (_client == null || (!_Channel && _guild == null) || channels == null || channels.Count == 0)
            {
                MessageBox.Show("Invalid data provided", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();

            if(Callback(_client, _guild, channels))
            {
                textBoxToken.Text = null;

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                Show();
            }
        }
    }
}
