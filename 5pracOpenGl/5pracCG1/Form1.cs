using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace _5pracCG1
{
	public partial class Form1 : Form
	{
		float[,] points = {
			{ -0.4f, -0.2f },
			{ -0.25f, 0.6f },
			{ 0, 0f },
			{ 0.25f, 0.6f },
			{ 0.4f, -0.2f },
			{ -0.15f, -0.5f } 
		};
		private void Coords()
		{
			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClearColor(1, 1, 1, 1);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glColor3f(0, 0, 0);
			Gl.glLineWidth(1);
			Gl.glBegin(Gl.GL_LINE_LOOP);
			Gl.glVertex2f(0, -0.7f);
			Gl.glVertex2f(0, 0.7f);
			Gl.glEnd();
			Gl.glBegin(Gl.GL_LINE_LOOP);
			Gl.glVertex2f(-0.5f, 0);
			Gl.glVertex2f(0.5f, 0);
			Gl.glEnd();
		}

		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();
		}

		private void simp_Paint(object sender, PaintEventArgs e)
		{
			
		}

		private void linesToolStripMenuItem_Click(object sender, EventArgs e)
		{

			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClearColor(1, 1, 1, 1);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Coords();
			Gl.glColor3f(1, 0, 0);
			Gl.glLineWidth(3);
			Gl.glBegin(Gl.GL_LINE_LOOP);
			for (int i = 0; i < 6; i++)
			{
				Gl.glVertex2f(points[i, 0], points[i, 1]);
			}
			Gl.glEnd();
			simp.Invalidate();


		}

		private void poligonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClearColor(1, 1, 1, 1);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Coords();
			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glColor3f(1, 0, 0);
			Gl.glVertex2f(points[5, 0], points[5, 1]);
			Gl.glColor3f(1, 0, 1);
			Gl.glVertex2f(points[4, 0], points[4, 1]);
			Gl.glColor3f(0, 0, 1);
			Gl.glVertex2f(points[3, 0], points[3, 1]);
			Gl.glColor3f(1, 0, 1);
			Gl.glVertex2f(points[2, 0], points[2, 1]);
			Gl.glColor3f(1, 0, 1);
			Gl.glVertex2f(points[1, 0], points[1, 1]);
			Gl.glColor3f(1, 0, 1);
			Gl.glVertex2f(points[0, 0], points[0, 1]);
			Gl.glEnd();
			simp.Invalidate();

		}
	}
}
