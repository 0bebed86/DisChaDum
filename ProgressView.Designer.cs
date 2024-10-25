namespace dischadum
{
    partial class ProgressView
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
            progressBar = new ProgressBar();
            label = new Label();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 27);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(360, 23);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 9);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 1;
            label.Text = "label1";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(12, 56);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(360, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProgressView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 91);
            Controls.Add(buttonCancel);
            Controls.Add(label);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ProgressView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Progress";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label label;
        private Button buttonCancel;
    }
}