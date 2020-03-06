using Bejeweled3AI.Common.Native;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bejeweled3AI.UI
{
    public partial class OverlayForm : Form
    {
        public OverlayForm()
        {
            InitializeComponent();
        }

        public void SetImage(Image img) => this.pictureBox1.Image = img;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var wl = User32.GetWindowLong(this.Handle, User32.GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            User32.SetWindowLong(this.Handle, User32.GWL.ExStyle, wl);
            User32.SetLayeredWindowAttributes(this.Handle, 0, 128, User32.LWA.Alpha);
        }
    }
}
