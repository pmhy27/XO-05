using System;
using System.Drawing;
using System.Windows.Forms;

namespace XO_05.PageControls
{
    [System.Diagnostics.DebuggerStepThrough]
    public partial class BoardExistencePageControl : Page
    {
        public BoardExistencePageControl()
        {
            InitializeComponent();
            this.Load += BoardExistencePageControl_Load;
            FindAllPlcInteractables((Control)this);
            GetAllReadPlcBuffers();
        }

        private void BoardExistencePageControl_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Pen pen = new Pen(Color.Black, 1);
                Font font = new Font("Arial", 12);
                Brush brush = Brushes.Black;

                // 畫箭頭 1：Over Bake（較長）
                Point start1 = new Point(15, 0);
                Point ang1e1 = new Point(15, 50);
                Point end1 = new Point(65, 50);
                g.DrawLine(pen, start1, ang1e1);
                g.DrawLine(pen, ang1e1, end1);
                DrawArrowHead(g, pen, start1, new Point(start1.X, start1.Y + 10));
                g.DrawString("Over Bake", font, brush, 70, 40);

                // 畫箭頭 2：Baked Board（較短）
                Point start2 = new Point(50, 0);
                Point ang1e2 = new Point(50, 30);
                Point end2 = new Point(65, 30);
                g.DrawLine(pen, start2, ang1e2);
                g.DrawLine(pen, ang1e2, end2);
                DrawArrowHead(g, pen, start2, new Point(start2.X, start2.Y + 10));
                g.DrawString("Baked Board", font, brush, 70, 20);
            }

            pictureBox1.Image = bmp;
        }

        private void DrawArrowHead(Graphics g, Pen pen, Point tip, Point basePoint)
        {
            const double arrowAngle = Math.PI / 6; // 30 度角
            const int arrowLength = 12;

            double dx = tip.X - basePoint.X;
            double dy = tip.Y - basePoint.Y;
            double angle = Math.Atan2(dy, dx);

            PointF p1 = new PointF(
                tip.X - arrowLength * (float)Math.Cos(angle - arrowAngle),
                tip.Y - arrowLength * (float)Math.Sin(angle - arrowAngle));

            PointF p2 = new PointF(
                tip.X - arrowLength * (float)Math.Cos(angle + arrowAngle),
                tip.Y - arrowLength * (float)Math.Sin(angle + arrowAngle));

            g.DrawLine(pen, tip, p1);
            g.DrawLine(pen, tip, p2);
        }

        private void BoardExistencePageControl_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
