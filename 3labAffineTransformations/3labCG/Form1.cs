using System.Globalization;

namespace _3labCG
{
	public partial class Form1 : Form
	{
		static Graphics canva;
		static Pen pen;
		static Font font;

		double[,] coordinates = { { -250, -200, 1 }, { -250, -30, 1 }, { -170, 80, 1 }, { 250, 180, 1 } };
		double[,] startCoordinates = { { -250, -200, 1 }, { -250, -30, 1 }, { -170, 80, 1 }, { 250, 180, 1 } };


		double[,] reflectY = { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

		double[,] reflectX = { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };

		public Form1()
		{
			InitializeComponent();
			
		}

		public void draw()
		{

		}

		private void Form_Click(object sender, EventArgs e)
		{
			canva = CreateGraphics();
			pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			font = new Font("Arial", 10);

			var center = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
			var zero = new PointF(ClientSize.Width / 2 + 20, ClientSize.Height / 2);
			var x1 = new PointF(ClientSize.Width / 2 - 300, ClientSize.Height / 2);
			var x2 = new PointF(ClientSize.Width / 2 + 300, ClientSize.Height / 2);
			var y1 = new PointF(ClientSize.Width / 2, ClientSize.Height / 2 - 250);
			var y2 = new PointF(ClientSize.Width / 2, ClientSize.Height / 2 + 250);

			canva.DrawLine(pen, x1, x2);
			canva.DrawLine(pen, y1, y2);

			canva.DrawString("x", font, Brushes.Black, x2);
			canva.DrawString("y", font, Brushes.Black, y1);
			canva.DrawString("0", font, Brushes.Black, center);
			canva.DrawString("1", font, Brushes.Black, zero);

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Draw(startCoordinates);
			coordinates = startCoordinates;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			double degrees = Double.Parse(textBox1.Text, CultureInfo.InvariantCulture);
			double[,] rotation = { { (double)Math.Cos(degrees * Math.PI / 180), (double)Math.Sin(degrees * Math.PI / 180), 0 }, { -(double)Math.Sin(degrees * Math.PI / 180), (double)Math.Cos(degrees * Math.PI / 180), 0 }, { 0, 0, 1 } };
			coordinates = multiply(coordinates,rotation);
			Draw(coordinates);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			coordinates = multiply(coordinates, reflectX);
			Draw(coordinates);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			coordinates = multiply(coordinates, reflectY);
			Draw(coordinates);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			
			
			if (textBox2.Text == String.Empty)
			{
				double[,] figureMove = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, -double.Parse(textBox3.Text, CultureInfo.InvariantCulture), 1 } };
				coordinates = multiply(coordinates, figureMove);
			}
			else if (textBox3.Text == String.Empty)
			{
				double[,] figureMove = { { 1, 0, 0 }, { 0, 1, 0 }, { double.Parse(textBox2.Text, CultureInfo.InvariantCulture), 0, 1 } };
				coordinates = multiply(coordinates, figureMove);
			}
			else 
			{
				double[,] figureMove = { { 1, 0, 0 }, { 0, 1, 0 }, { double.Parse(textBox2.Text, CultureInfo.InvariantCulture), -double.Parse(textBox3.Text, CultureInfo.InvariantCulture), 1 } };
				coordinates = multiply(coordinates, figureMove);
			}
			Draw(coordinates);

		}

		private void button6_Click(object sender, EventArgs e)
		{
			double[,] figureSize = { { Double.Parse(textBox4.Text, CultureInfo.InvariantCulture), 0, 0 }, { 0, Double.Parse(textBox4.Text, CultureInfo.InvariantCulture), 0 }, { 0, 0, 1 } };
			coordinates = multiply(coordinates, figureSize);
			Draw(coordinates);
		}

		void Draw(double[,] coordinates)
		{
			Refresh();

			canva = CreateGraphics();
			pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			font = new Font("Arial", 10);

			var center = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
			var zero = new PointF(ClientSize.Width / 2 + 20, ClientSize.Height / 2);
			var x1 = new PointF(ClientSize.Width / 2 - 300, ClientSize.Height / 2);
			var x2 = new PointF(ClientSize.Width / 2 + 300, ClientSize.Height / 2);
			var y1 = new PointF(ClientSize.Width / 2, ClientSize.Height / 2 - 250);
			var y2 = new PointF(ClientSize.Width / 2, ClientSize.Height / 2 + 250);

			canva.DrawLine(pen, x1, x2);
			canva.DrawLine(pen, y1, y2);

			canva.DrawString("x", font, Brushes.Black, x2);
			canva.DrawString("y", font, Brushes.Black, y1);
			canva.DrawString("0", font, Brushes.Black, center);
			canva.DrawString("1", font, Brushes.Black, zero);

			canva = CreateGraphics();

			pen = new Pen(Color.Purple);

			var a = new PointF(ClientSize.Width / 2 + (float)coordinates[0, 0], ClientSize.Height / 2 + (float)coordinates[0, 1]);
			var b = new PointF(ClientSize.Width / 2 + (float)coordinates[1, 0], ClientSize.Height / 2 + (float)coordinates[1, 1]);
			var c = new PointF(ClientSize.Width / 2 + (float)coordinates[2, 0], ClientSize.Height / 2 + (float)coordinates[2, 1]);
			var d = new PointF(ClientSize.Width / 2 + (float)coordinates[3, 0], ClientSize.Height / 2 + (float)coordinates[3, 1]);

			canva.DrawLine(pen, a, b);
			canva.DrawLine(pen, b, c);
			canva.DrawLine(pen, c, d);
			canva.DrawLine(pen, d, a);
			canva.Dispose();
		}

		public static double[,] multiply(double[,] matrix1, double[,] matrix2)
		{
			var matrix1Rows = matrix1.GetLength(0);
			var matrix1Cols = matrix1.GetLength(1);
			var matrix2Cols = matrix2.GetLength(1);

			double[,] product = new double[matrix1Rows, matrix2Cols];

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

		private void button7_Click(object sender, EventArgs e)
		{
			Refresh();
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}
	}
}