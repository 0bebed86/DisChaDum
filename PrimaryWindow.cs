namespace dischadum
{
    public partial class PrimaryWindow : Form
    {
        private static readonly Font font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);

        public PrimaryWindow()
        {
            InitializeComponent();
        }

        private void GetChannelMessages(HttpClient client, Core.DiscordChannel channel)
        {
            var state = true;

            using (var dialog = new ProgressView($"Getting messages from {channel.Name}", (d) => { state = false; return true; }))
            {
                this.Invoke(() => dialog.Show());

                try
                {
                    channel.Messages = Core.GetChannelMessages(client, channel.Id, ref state, ref channel.rawMessages);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private TreeNode[] GetMessagesNodes(List<Core.DiscordMessage> messages)
        {
            var results = new TreeNode[messages.Count];

            for (int i = 0, l = results.Length; i < l; i++)
            {
                var message = messages[i];

                var node = new TreeNode(message.ToString());
                {
                    node.Tag = message;
                }

                results[i] = node;
            }

            return results;
        }

        private TreeNode[] GetChannelsNodes(List<Core.DiscordChannel> channels)
        {
            var results = new TreeNode[channels.Count];

            for (int i = 0, l = results.Length; i < l; i++)
            {
                var channel = channels[i];
                var inner = GetMessagesNodes(channel.Messages);

                var node = new TreeNode(channel.ToString());
                {
                    node.Tag = channel;
                    node.Nodes.AddRange(inner);
                }

                results[i] = node;
            }

            return results;
        }

        private void AddTab(string id, string name, object tag, TreeNode[] nodes)
        {
            var tree = new TreeView();
            {
                tree.Dock = DockStyle.Fill;
                tree.Location = new Point(0, 0);
                tree.Name = "treeView" + id;
                tree.Size = new Size(776, 409);
                tree.TabIndex = 0;
                tree.Nodes.AddRange(nodes);
                tree.Tag = tag;
                tree.Font = font;
            }

            var pageName = "tabPage" + id;

            for (int i = 0, l = tabControl.Controls.Count; i < l; i++)
            {
                var control = tabControl.Controls[i];

                if (control.Name.Equals(pageName))
                {
                    tabControl.Controls.Remove(control);
                    break;
                }
            }

            var page = new TabPage(name);
            {
                page.Controls.Add(tree);
                page.Location = new Point(4, 24);
                page.Name = pageName;
                page.Size = new Size(776, 409);
                page.TabIndex = tabControl.Controls.Count;
                page.UseVisualStyleBackColor = true;
                page.Tag = tag;
            }

            tabControl.Controls.Add(page);
        }

        private void ApplyGuild(Core.DiscordGuild guild, List<Core.DiscordChannel> channels)
        {
            AddTab(guild.Id, guild.Name, guild, GetChannelsNodes(channels));
        }

        private void ApplyChannel(Core.DiscordChannel channel)
        {
            AddTab(channel.Id, channel.Name, channel, GetMessagesNodes(channel.Messages));
        }

        private void ShowNewDumpDialog()
        {
            HttpClient client = null;
            Core.DiscordGuild guild = null;
            List<Core.DiscordChannel> targetedChannels = null;

            using (var dialog = new NewDumpDialog(false, (c, g, t) =>
            {
                client = c;
                guild = g;
                targetedChannels = t;
                return true;
            }))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
            }

            var tasks = new List<Task>();

            foreach(var channel in targetedChannels)
            {
                tasks.Add(Task.Factory.StartNew(() => GetChannelMessages(client, channel)));
            }

            Task.Factory.StartNew(() =>
            {
                foreach (var task in tasks)
                {
                    task.Wait();
                }

                Core.CloseClient(ref client);

                if (guild == null)
                {
                    this.Invoke(() => ApplyChannel(targetedChannels[0]));
                }
                else
                {
                    this.Invoke(() => ApplyGuild(guild, targetedChannels));
                }
            });
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewDumpDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sources = new List<object>();

            foreach(TabPage tab in tabControl.TabPages)
            {
                var tag = tab.Tag;
                if(tag == null) continue;

                sources.Add(tag);
            }

            using (var dialog = new SaveDumpDialog(sources))
            {
                dialog.ShowDialog(this);
            }
        }
    }
}
