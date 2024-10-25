namespace dischadum
{
    partial class SaveDumpDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            buttonOk = new Button();
            buttonSelectFolder = new Button();
            textBoxFolder = new TextBox();
            checkedListBox = new CheckedListBox();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Controls.Add(buttonOk, 2, 0);
            tableLayoutPanel.Controls.Add(buttonSelectFolder, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxFolder, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(684, 29);
            tableLayoutPanel.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonOk.Enabled = false;
            buttonOk.Location = new Point(638, 3);
            buttonOk.Margin = new Padding(4, 3, 4, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(42, 23);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSelectFolder.Location = new Point(513, 3);
            buttonSelectFolder.Margin = new Padding(4, 3, 4, 3);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(117, 23);
            buttonSelectFolder.TabIndex = 1;
            buttonSelectFolder.Text = "Select folder";
            buttonSelectFolder.UseVisualStyleBackColor = true;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // textBoxFolder
            // 
            textBoxFolder.Dock = DockStyle.Fill;
            textBoxFolder.Location = new Point(3, 3);
            textBoxFolder.Name = "textBoxFolder";
            textBoxFolder.PlaceholderText = "Destination folder";
            textBoxFolder.Size = new Size(503, 23);
            textBoxFolder.TabIndex = 5;
            textBoxFolder.TextChanged += textBoxFolder_TextChanged;
            // 
            // checkedListBox
            // 
            checkedListBox.CheckOnClick = true;
            checkedListBox.Dock = DockStyle.Fill;
            checkedListBox.FormattingEnabled = true;
            checkedListBox.IntegralHeight = false;
            checkedListBox.Location = new Point(0, 29);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(684, 332);
            checkedListBox.TabIndex = 1;
            // 
            // SaveDumpDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 361);
            Controls.Add(checkedListBox);
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(400, 200);
            Name = "SaveDumpDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Save dumps";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonSelectFolder;
        private CheckedListBox checkedListBox;
        private Button buttonOk;
        private TextBox textBoxFolder;
    }
}