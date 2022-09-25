using System.Drawing;
using System.Windows.Forms;
using System;

namespace koh
{
	public partial class Form1 : Form
	{
		static Graphics canva;
		static Pen pen_green;


		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			pen_green = new Pen(Color.Green, 1);
			
			canva = CreateGraphics();
			canva.Clear(Color.White);


			var p1 = new PointF(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 + 100); 
			var p2 = new PointF(this.ClientSize.Width / 2 + 200, this.ClientSize.Height / 2 + 100); 
			var p3 = new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2 - 100);

			canva.DrawLine(pen_green, p1, p2);
			canva.DrawLine(pen_green, p2, p3);
			canva.DrawLine(pen_green, p3, p1);

			FractalKoh(p1, p2, p3, 5);
			FractalKoh(p2, p3, p1, 5);
			FractalKoh(p3, p1, p2, 5);
		}

		static int FractalKoh(PointF p1, PointF p2, PointF p3, int i)
		{
			if (i>0) {
				var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
				var p5 = new PointF((2 * p2.X + p1.X) / 3, (2 * p2.Y + p1.Y) / 3);
				var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
				var pn = new PointF((4 * ps.X - p3.X) / 3,(4 * ps.Y - p3.Y) / 3);
				
				canva.DrawLine(pen_green, p4, pn);
				canva.DrawLine(pen_green, p5, pn);
				canva.DrawLine(pen_green, p4, p5);

				FractalKoh(p4, pn, p5, i - 1);
				FractalKoh(pn, p5, p4, i - 1);
				FractalKoh(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), i - 1);
				FractalKoh(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), i - 1);
			}
			return i;
		}
	}
}