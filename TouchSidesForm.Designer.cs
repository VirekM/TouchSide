
namespace TouchSides
{
    partial class TouchSidesForm
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
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.FileLocationTextBox = new System.Windows.Forms.RichTextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(39, 101);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(579, 220);
            this.ResultTextBox.TabIndex = 0;
            this.ResultTextBox.Text = "";
            this.ResultTextBox.TextChanged += new System.EventHandler(this.ResultTextBox_TextChanged);
            // 
            // FileLocationTextBox
            // 
            this.FileLocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLocationTextBox.Location = new System.Drawing.Point(39, 26);
            this.FileLocationTextBox.Name = "FileLocationTextBox";
            this.FileLocationTextBox.ReadOnly = true;
            this.FileLocationTextBox.Size = new System.Drawing.Size(579, 36);
            this.FileLocationTextBox.TabIndex = 1;
            this.FileLocationTextBox.Text = "";
            this.FileLocationTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(650, 26);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(93, 36);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // TouchSidesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.FileLocationTextBox);
            this.Controls.Add(this.ResultTextBox);
            this.Name = "TouchSidesForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.RichTextBox FileLocationTextBox;
        private System.Windows.Forms.Button BrowseBtn;
    }
}

