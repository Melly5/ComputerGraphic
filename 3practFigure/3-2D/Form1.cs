namespace _3_2D
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		static Graphics canva;
		static Pen pen;
		static Font font;

		private void button1_Click(object sender, EventArgs e)
		{
			Refresh();
			canva = CreateGraphics();
			canva.Clear(Color.White);
			pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			font = new Font("Arial", 10);

			float partX = ClientSize.Width / 30;
			float partY = ClientSize.Height / 30;

			var center = new PointF(ClientSize.Width / 2 + 6f*partX, ClientSize.Height / 2);
			var one = new PointF(ClientSize.Width / 2 + 7f*partX, ClientSize.Height / 2);
			var x1 = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
			var x2 = new PointF(ClientSize.Width / 2 + 12f*partX, ClientSize.Height / 2);
			var y1 = new PointF(ClientSize.Width / 2 + 6f * partX, ClientSize.Height / 2 - 11f*partY);
			var y2 = new PointF(ClientSize.Width / 2 + 6f * partX, ClientSize.Height / 2 + 11f*partY);

			canva.DrawLine(pen, x1, x2);
			canva.DrawLine(pen, y1, y2);

			canva.DrawString("x", font, Brushes.Black, x2);
			canva.DrawString("y", font, Brushes.Black, y1);
			canva.DrawString("0", font, Brushes.Black, center);
			canva.DrawString("1", font, Brushes.Black, one);
			canva.Dispose();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			canva = CreateGraphics();

			pen = new Pen(Color.Purple);

			float partX = ClientSize.Width / 50;
			float partY = ClientSize.Height / 50;

			var a = new PointF(ClientSize.Width / 2 + partX, ClientSize.Height / 2 - 15f * partY);
			var b = new PointF(ClientSize.Width / 2 + partX, ClientSize.Height / 2 - 2.5f * partY);
			var c = new PointF(ClientSize.Width / 2 + 5f * partX, ClientSize.Height / 2 + 7f * partY);
			var d = new PointF(ClientSize.Width / 2 + 18f * partX, ClientSize.Height / 2 + 15f * partY);

			canva.DrawLine(pen, a, b);
			canva.DrawLine(pen, b, c);
			canva.DrawLine(pen, c, d);
			canva.DrawLine(pen, d, a);

		}
	}
}