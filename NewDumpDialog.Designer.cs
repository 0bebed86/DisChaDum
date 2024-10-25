namespace dischadum
{
    partial class NewDumpDialog
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
            buttonGet = new Button();
            textBoxTargetId = new TextBox();
            textBoxToken = new TextBox();
            checkBoxChannel = new CheckBox();
            checkedListBox = new CheckedListBox();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Controls.Add(buttonOk, 4, 0);
            tableLayoutPanel.Controls.Add(buttonGet, 3, 0);
            tableLayoutPanel.Controls.Add(textBoxTargetId, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxToken, 0, 0);
            tableLayoutPanel.Controls.Add(checkBoxChannel, 2, 0);
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
            buttonOk.Location = new Point(637, 3);
            buttonOk.Margin = new Padding(4, 3, 4, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(43, 23);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonGet
            // 
            buttonGet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonGet.Location = new Point(562, 3);
            buttonGet.Margin = new Padding(4, 3, 4, 3);
            buttonGet.Name = "buttonGet";
            buttonGet.Size = new Size(67, 23);
            buttonGet.TabIndex = 1;
            buttonGet.Text = "Get";
            buttonGet.UseVisualStyleBackColor = true;
            buttonGet.Click += buttonGet_Click;
            // 
            // textBoxTargetId
            // 
            textBoxTargetId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTargetId.Location = new Point(243, 3);
            textBoxTargetId.Margin = new Padding(4, 3, 4, 3);
            textBoxTargetId.MaxLength = 256;
            textBoxTargetId.Name = "textBoxTargetId";
            textBoxTargetId.PlaceholderText = "Target ID";
            textBoxTargetId.Size = new Size(231, 23);
            textBoxTargetId.TabIndex = 3;
            // 
            // textBoxToken
            // 
            textBoxToken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxToken.Location = new Point(4, 3);
            textBoxToken.Margin = new Padding(4, 3, 4, 3);
            textBoxToken.MaxLength = 256;
            textBoxToken.Name = "textBoxToken";
            textBoxToken.PlaceholderText = "Token";
            textBoxToken.Size = new Size(231, 23);
            textBoxToken.TabIndex = 2;
            textBoxToken.UseSystemPasswordChar = true;
            // 
            // checkBoxChannel
            // 
            checkBoxChannel.Dock = DockStyle.Left;
            checkBoxChannel.Location = new Point(481, 3);
            checkBoxChannel.Name = "checkBoxChannel";
            checkBoxChannel.Size = new Size(70, 23);
            checkBoxChannel.TabIndex = 5;
            checkBoxChannel.Text = "Channel";
            checkBoxChannel.UseVisualStyleBackColor = true;
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
            // NewDumpDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 361);
            Controls.Add(checkedListBox);
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(400, 200);
            Name = "NewDumpDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New dump";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.TextBox textBoxTargetId;
        private CheckedListBox checkedListBox;
        private Button buttonOk;
        private CheckBox checkBoxChannel;
    }
}