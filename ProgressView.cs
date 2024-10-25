namespace dischadum
{
    public partial class ProgressView : Form
    {
        public delegate bool AbortFunction(ProgressView sender);

        private AbortFunction abortFunction;

        public string Label
        {
            get => label.Text;
            set => label.Text = value;
        }

        public ProgressView(string label, AbortFunction abortFunction)
        {
            InitializeComponent();

            this.label.Text = label;
            this.abortFunction = abortFunction;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (abortFunction(this))
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                MessageBox.Show("Can't abort process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
