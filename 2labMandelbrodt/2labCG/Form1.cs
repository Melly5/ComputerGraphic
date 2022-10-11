namespace _2labCG
{
	public partial class Form1 : Form
	{

		double x0 = -2.2, xN = 1.0, y0 = -1.2, yN = 1.2, radiusMin = 4;
		int kMax = 100;
		public Form1()
		{
			InitializeComponent();
		}

		private void Mandelbrodt(object sender, EventArgs e)
		{

			Draw();
		
		}

		public void Draw()
		{
			Bitmap frame = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			double Xk = ((xN - x0) / Convert.ToDouble(frame.Width));
			double Yk = ((yN - y0) / Convert.ToDouble(frame.Height));
			double cA, cB;

			for (int x = 0; x < frame.Width; x++)
			{
				cA = (Xk * x) - Math.Abs(x0);
				for (int y = 0; y < frame.Height; y++)
				{
					int k = 0;
					double z = 0;
					double a = 0, b = 0;
					cB = (Yk * y) - Math.Abs(y0);
					do
					{
						k++;
						double temp = a;
						a = (a * a) - (b * b) + cA;
						b = 2 * temp * b + cB;

						z = (a * a) + (b * b);

					} while (k < kMax && z <= radiusMin);

					frame.SetPixel(x, y, Color.FromArgb(50, k % 32 * 7, k % 32 * 5, k % 16 * 2)) ;
					

				}
				pictureBox1.Image = frame;
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

			}
		}
	}
}