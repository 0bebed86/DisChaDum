using System.Data;

namespace dischadum
{
    public partial class SaveDumpDialog : Form
    {
        private FolderBrowserDialog _folderSelectionDialog = new();
        private string? _folderPath = null;

        private List<object> _Sources => checkedListBox.Items.Cast<object>().ToList();
        private List<object> _SelectedSources => checkedListBox.CheckedItems.Cast<object>().ToList();

        public SaveDumpDialog(List<object> sources)
        {
            InitializeComponent();

            checkedListBox.Items.AddRange(sources.ToArray());
        }

        private void ApplyPath(string path, bool applyTextBox, bool applyFileDialog)
        {
            if (applyTextBox)
            {
                textBoxFolder.Text = path;
            }

            if (applyFileDialog)
            {
                _folderSelectionDialog.SelectedPath = path;
            }

            _folderPath = path;

            buttonOk.Enabled = !string.IsNullOrEmpty(path);
        }

        private Task? SaveChannelAsync(DirectoryInfo root, Core.DiscordChannel channel)
        {
            if (string.IsNullOrEmpty(channel.rawMessages)) return null;

            var path = Path.Combine(root.FullName, channel.Name + ".json");

            return File.WriteAllTextAsync(path, channel.rawMessages);
        }

        private void SaveGuild(DirectoryInfo root, Core.DiscordGuild guild)
        {
            if (guild.Channels == null) return;

            var path = Path.Combine(root.FullName, guild.Name);
            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                directory.Create();
            }

            foreach (var channel in guild.Channels)
            {
                SaveChannelAsync(directory, channel);
            }
        }

        private void textBoxFolder_TextChanged(object sender, EventArgs e)
        {
            ApplyPath((sender as TextBox).Text, false, true);
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (_folderSelectionDialog.ShowDialog(this) != DialogResult.OK) return;

            ApplyPath(_folderSelectionDialog.SelectedPath, true, false);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_folderPath)) return;

            var path = Path.GetFullPath(_folderPath);
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                directory.Create();
            }

            var sources = _Sources;
            foreach (var source in sources)
            {
                if (source is Core.DiscordGuild)
                {
                    SaveGuild(directory, source as Core.DiscordGuild);
                }
                else if (source is Core.DiscordChannel)
                {
                    SaveChannelAsync(directory, source as Core.DiscordChannel);
                }
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
