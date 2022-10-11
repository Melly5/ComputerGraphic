namespace _4CGl
{
	public partial class Form1 : Form
	{
		static Graphics canva;
		static Pen pen;
		static Font font;

		float[,] coordinates = { { -100, 0, 100, 1 }, { -100, 0, -100, 1 }, { 100, 0, -100, 1 }, { 100, 0, 100, 1 },
		{ 0, 100, 0, 1 }, { 0, -100, 0, 1 }};
		float[,] startCoordinates = { { -100, 0, 100, 1 }, { -100, 0, -100, 1 }, { 100, 0, -100, 1 }, { 100, 0, 100, 1 },
		{ 0, 100, 0, 1 }, { 0, -100, 0, 1 }};

		public Form1()
		{
			InitializeComponent();
		}
		/*1.–еализуйте программу, позвол€ющую выполн€ть композицию преобразований 
		над октаэдром: масштабирование относительно различных осей координат и 
		аксонометрическое изометрическое проецирование.*/
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

			for (int i = 0; i < 4; i++)
			{
				int j = 0;
				if (i == 0)
					canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[i+3, j], centerH + coordinates[i+3, j + 1]);

				canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[i + 1, j], centerH + coordinates[i + 1, j + 1]);
				canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[4, j], centerH + coordinates[4, j + 1]);
				canva.DrawLine(pen, centerW + coordinates[i, j], centerH + coordinates[i, j + 1], centerW + coordinates[5, j], centerH + coordinates[5, j + 1]);


			}
			canva.Dispose();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DrawCoords();
			DrawFigure(startCoordinates);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DrawCoords();
			float a = 1, b = 1, c = 1;

			if (radioButton1.Checked)
			{
				if (maskedTextBox1.Text.Length != 0)
					a = float.Parse(maskedTextBox1.Text);
			}
			else if (radioButton2.Checked)
			{
				if (maskedTextBox1.Text.Length != 0)
					b = float.Parse(maskedTextBox1.Text);
			}
			else if (radioButton3.Checked)
			{
				if (maskedTextBox1.Text.Length != 0)
					c = float.Parse(maskedTextBox1.Text);
			}
			float[,] resize = { { a, 0, 0, 0 }, { 0, b, 0, 0 }, { 0, 0, c, 0 }, { 0, 0, 0, 1 } };

			coordinates = multiply(coordinates, resize);
			DrawFigure(coordinates);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DrawCoords();
			float degree = 0;
			if (maskedTextBox1.Text.Length != 0)
				degree = float.Parse(maskedTextBox1.Text);
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

		private void button4_Click(object sender, EventArgs e)
		{
			DrawCoords();
			float[,] I =
			{
				{0.707f, -0.408f, 0, 0 },
				{0, 0.816f, 0, 0 },
				{-0.707f,-0.408f, 0, 0 },
				{0, 0, 0, 1 }
			};
			coordinates = multiply(startCoordinates, I);
			DrawFigure(coordinates);
		}
	}
}