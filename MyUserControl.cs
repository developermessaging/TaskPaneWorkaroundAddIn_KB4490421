using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TaskPaneWorkaround
{
    public partial class MyUserControl : UserControl
    {
        bool isformdisplayed = false;
        WorkaroundForm workaroundForm;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MyUserControl()
        {
            this.SuspendLayout();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MyUserControl";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyUserControl_Paint);
            this.Resize += new System.EventHandler(this.MyUserControl_Resize);
            this.ResumeLayout(false);

            this.Paint += MyUserControl_Paint;
            this.Resize += MyUserControl_Resize;
        }

        private void MyUserControl_Load(object sender, System.EventArgs e)
        {
            this.Paint += MyUserControl_Paint;
        }

        private void MyUserControl_Paint(object sender, PaintEventArgs e)
        {
            if (!isformdisplayed)
            {
                this.SuspendLayout();
                workaroundForm = new WorkaroundForm();
                SetParent(workaroundForm.Handle, this.Handle);
                workaroundForm.Dock = DockStyle.Fill;
                workaroundForm.Width = Width;
                workaroundForm.Height = Height;
                workaroundForm.Show();
                isformdisplayed = true;
                this.ResumeLayout();
            }
        }

        private void MyUserControl_Resize(object sender, EventArgs e)
        {
            if (isformdisplayed)
            {
                workaroundForm.Width = this.Width;
                workaroundForm.Height = this.Height;
            }
        }
    }
}