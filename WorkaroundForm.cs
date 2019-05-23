using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskPaneWorkaround
{
    public partial class WorkaroundForm : Form
    {
        public WorkaroundForm()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 602);
            this.Name = "WorkaroundForm";
            this.Text = "WorkaroundForm";
            this.Load += new System.EventHandler(this.WorkaroundForm_Load);
            this.ResumeLayout(false);
        }
        private void WorkaroundForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Location = new Point(0, 0);
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            WebBrowser webBrowser = new WebBrowser();
            this.Controls.Add(webBrowser);
            webBrowser.Location = new Point(0, 0);
            webBrowser.Dock = DockStyle.Fill;
            this.ResumeLayout();
            webBrowser.Focus();
            webBrowser.Navigate(new System.Uri("https://bing.com"));
        }
    }
}