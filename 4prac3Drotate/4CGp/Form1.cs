namespace _4CGp
{
	public partial class Form1 : Form
	{

		static Graphics canva;
		static Pen pen;
		static Font font;

		float[,] coordinates = { { -140, -110, 30, 1 }, { -140, -10, 30, 1 }, { -80, 50, 30, 1 }, { 120, 90, 30, 1 },
		{ -140, -110, -30, 1 }, { -140, -10, -30, 1 }, { -80, 50, -30, 1 }, { 120, 90, -30, 1 }};
		float[,] startCoordinates = { { -140, -110, 30, 1 }, { -140, -10, 30, 1 }, { -80, 50, 30, 1 }, { 120, 90, 30, 1 },
		{ -140, -110, -30, 1 }, { -140, -10, -30, 1 }, { -80, 50, -30, 1 }, { 120, 90, -30, 1 }};
		

		public Form1()
		{
			InitializeComponent();
		}

		private void pictureBox1_LoadCompleted(object sender, EventArgs e)
		{
			DrawCoords();
			DrawFigure(coordinates);
		}

		void DrawCoords()
		{
			Refresh();

			canva = pictureBox1.CreateGraphics();
			pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			font = new Font("Arial", 10);
			var centerH = pictureBox1.Height / 2 + 30;
			var centerW = pictureBox1.Width / 2 - 30;

			var center = new PointF(centerW, centerH);
			var zero = new PointF(centerW + 20, centerH);

			//var x1 = new PointF(centerW, centerH);
			var z2 = new PointF(centerW - 125, centerH + 125);
			//var y1 = new PointF(centerW, centerH);
			var x2 = new PointF(centerW + 200, centerH);
			//var z1 = new PointF(centerW, centerH );
			var y2 = new PointF(centerW, centerH - 200);

			canva.DrawLine(pen, center, x2);
			canva.DrawLine(pen, center, y2);
			canva.DrawLine(pen, center, z2);

			canva.DrawString("x", font, Brushes.Black, x2);
			canva.DrawString("y", font, Brushes.Black, y2);
			canva.DrawString("z", font, Brushes.Black, z2);
			canva.DrawString("0", font, Brushes.Black, center);
			canva.DrawString("1", font, Brushes.Black, zero);

			
		}

		void DrawFigure(float[,] coordinates)
		{
			int centerH = pictureBox1.Height / 2 + 30;
			int centerW = pictureBox1.Width / 2 - 30;

			canva = pictureBox1.CreateGraphics();

			pen = new Pen(Color.Purple);

			for (int i = 0; i < 7; i++)
			{
				int j = 0;
				if (i!=3)
					canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[i + 1, j], centerH + coordinates[i + 1, j + 1]);
				if (i<4)
					canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[i + 4, j], centerH + coordinates[i + 4, j + 1]);
				canva.DrawLine(pen, centerW + coordinates[0, j], centerH + coordinates[0, j + 1], centerW + coordinates[3, j], centerH + coordinates[3, j + 1]);
				canva.DrawLine(pen, centerW + coordinates[4, j], centerH + coordinates[4, j + 1], centerW + coordinates[7, j], centerH + coordinates[7, j + 1]);


			}
			canva.Dispose();
		}

		public static float[,] multiply(float[,] matrix1, float[,] matrix2)
		{
			var matrix1Rows = matrix1.GetLength(0);
			var matrix1Cols = matrix1.GetLength(1);
			var matrix2Cols = matrix2.GetLength(1);

			float[,] product = new float[matrix1Rows, matrix2Cols];

			for (int i = 0; i < matrix1Rows; i++)
			{
				for (int j = 0; j < matrix2Cols; j++)
				{
					for (int k = 0; k < matrix1Cols; k++)
					{
						product[i, j] += matrix1[i, k] * matrix2[k, j];
					}
				}
			}

			return product;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DrawCoords();
			DrawFigure(startCoordinates);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DrawCoords();
			float degree = 0;
			if (textBox1.Text.Length != 0)
				degree = float.Parse(textBox1.Text);
			else return;
			float[,] rotationX = { { 1, 0, 0, 0 }, { 0, (float)Math.Cos(degree * Math.PI / 180), (float)Math.Sin(degree * Math.PI / 180), 0 }, { 0, -(float)Math.Sin(degree * Math.PI / 180), (float)Math.Cos(degree * Math.PI / 180), 0 }, { 0, 0, 0, 1 } };
			float[,] rotationY = { { (float)Math.Cos(degree * Math.PI / 180), 0, -(float)Math.Sin(degree * Math.PI / 180), 0 }, { 0, 1, 0, 0 }, { (float)Math.Sin(degree * Math.PI / 180), 0, (float)Math.Cos(degree * Math.PI / 180), 0 }, { 0, 0, 0, 1 } };
			float[,] rotationZ = { { (float)Math.Cos(degree * Math.PI / 180), (float)Math.Sin(degree * Math.PI / 180), 0, 0 }, { -(float)Math.Sin(degree * Math.PI / 180), (float)Math.Cos(degree * Math.PI / 180), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };


			if (radioButton1.Checked)
			{
				coordinates = multiply(coordinates, rotationX);
			}
			else if (radioButton2.Checked)
			{
				coordinates = multiply(coordinates, rotationY);
			}
			else if (radioButton3.Checked)
			{
				coordinates = multiply(coordinates, rotationZ);
			}
				
			DrawFigure(coordinates);
		}
	}
}