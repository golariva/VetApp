using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SQLApp
{
    public class GradientButton : Button
    {
        private Color startColor = Color.Red;
        private Color endColor = Color.Yellow;
        private float angle = 45f;

        public Color StartColor
        {
            get { return startColor; }
            set { startColor = value; Invalidate(); }
        }

        public Color EndColor
        {
            get { return endColor; }
            set { endColor = value; Invalidate(); }
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, StartColor, EndColor, Angle))
            {
                brush.SetSigmaBellShape(0.5f);
                e.Graphics.FillRectangle(brush, ClientRectangle);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, sf);
                }
            }
        }
    }
}
