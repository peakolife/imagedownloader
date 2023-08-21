
namespace WebPageDownloader
{
    partial class Form1
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.rTBoxError = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(113, 45);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(218, 22);
            this.txtUrl.TabIndex = 0;
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Location = new System.Drawing.Point(113, 100);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.Size = new System.Drawing.Size(218, 22);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "İndirilecek Dosya Yolu";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(113, 145);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "İndir";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click_1);
            // 
            // rTBoxError
            // 
            this.rTBoxError.Location = new System.Drawing.Point(-1, 198);
            this.rTBoxError.Name = "rTBoxError";
            this.rTBoxError.Size = new System.Drawing.Size(628, 187);
            this.rTBoxError.TabIndex = 5;
            this.rTBoxError.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(453, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(627, 389);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rTBoxError);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDownloadPath);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RichTextBox rTBoxError;
        private System.Windows.Forms.TextBox textBox1;
    }
}

