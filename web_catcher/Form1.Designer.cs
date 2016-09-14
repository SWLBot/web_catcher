namespace web_catcher
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.file_textBox = new System.Windows.Forms.TextBox();
            this.start_button = new System.Windows.Forms.Button();
            this.display_textBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // file_textBox
            // 
            this.file_textBox.AllowDrop = true;
            this.file_textBox.Location = new System.Drawing.Point(13, 13);
            this.file_textBox.Name = "file_textBox";
            this.file_textBox.Size = new System.Drawing.Size(178, 22);
            this.file_textBox.TabIndex = 0;
            this.file_textBox.TextChanged += new System.EventHandler(this.file_textBox_TextChanged);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(197, 12);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 1;
            this.start_button.Text = "start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // display_textBox
            // 
            this.display_textBox.Location = new System.Drawing.Point(12, 41);
            this.display_textBox.Name = "display_textBox";
            this.display_textBox.Size = new System.Drawing.Size(260, 209);
            this.display_textBox.TabIndex = 2;
            this.display_textBox.Text = "";
            this.display_textBox.TextChanged += new System.EventHandler(this.display_textBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.display_textBox);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.file_textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file_textBox;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.RichTextBox display_textBox;
    }
}

