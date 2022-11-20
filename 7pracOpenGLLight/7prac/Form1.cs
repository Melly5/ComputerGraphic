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

namespace _7prac
{
	public partial class Form1 : Form
	{
		float[,] figure = { { -0.3f, -0.2f, 0.8f }, { 0.3f, -0.2f, 0.8f }, { 0.3f, -0.2f, -0.4f }, { -0.3f, -0.2f, -0.4f }, { -0.3f, 0, 0.8f }, { 0.3f, 0, 0.8f }, { 0.3f, 0, 0 }, { -0.3f, 0, 0 }, { -0.3f, 0.2f, 0 }, { 0.3f, 0.2f, 0 }, { 0.3f, 0.2f, -0.4f }, { -0.3f, 0.2f, -0.4f } };
		float[] lightX = { 1, 0, 0, 0 };
		float[] lightY = { 0, 1, 0, 0 };
		float[] lightZ = { 0, 0, 1, 0 };
		float[] light_dif = { 0.7f, 0.2f, 0.2f };
		float[] color = { 0.5f, 0.2f, 1f };

		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();

			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClearColor(1, 1, 1, 1);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Gl.glFrustum(-1, 1, -1, 1, 3, 10);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glTranslatef(0, 0, -7);
			DrawFigure(figure);

			simp.Invalidate();

		}

		void DrawFigure(float[,] a)
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);


			//нижняя
			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glNormal3f(0.0f, -1.0f, 0.0f);
			for (int i = 0; i < 4; i++)
				Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
			Gl.glEnd();
			//над нижней
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3f(0.0f, 1.0f, 0.0f);
			for (int i = 4; i < 8; i++)
				Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
			Gl.glEnd();
			//над над нижней
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3f(0.0f, 1.0f, 0.0f);
			for (int i = 11; i > 7; i--)
				Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
			Gl.glEnd();

			//перед низ
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3f(0.0f, 0.0f, 1.0f);
			Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
			Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
			Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
			Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);
			Gl.glEnd();
			//перед верх
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3f(0.0f, 0.0f, 1.0f);
			Gl.glVertex3f(a[7, 0], a[7, 1], a[7, 2]);
			Gl.glVertex3f(a[6, 0], a[6, 1], a[6, 2]);
			Gl.glVertex3f(a[9, 0], a[9, 1], a[9, 2]);
			Gl.glVertex3f(a[8, 0], a[8, 1], a[8, 2]);
			Gl.glEnd();
			//зад
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glNormal3f(0.0f, 0.0f, -1.0f);
			Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
			Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
			Gl.glVertex3f(a[10, 0], a[10, 1], a[10, 2]);
			Gl.glVertex3f(a[11, 0], a[11, 1], a[11, 2]);
			Gl.glEnd();

			//бок -х
			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glNormal3f( -1.0f, 0.0f, 0.0f);
			Gl.glVertex3f(a[7, 0], a[7, 1], a[7, 2]);
			Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);
			Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
			Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
			Gl.glVertex3f(a[11, 0], a[11, 1], a[11, 2]);
			Gl.glVertex3f(a[8, 0], a[8, 1], a[8, 2]);
			Gl.glEnd();
			//бок х
			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glNormal3f(1.0f, 0.0f, 0.0f);
			Gl.glVertex3f(a[6, 0], a[6, 1], a[6, 2]);
			Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
			Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
			Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
			Gl.glVertex3f(a[10, 0], a[10, 1], a[10, 2]);
			Gl.glVertex3f(a[9, 0], a[9, 1], a[9, 2]);
			Gl.glEnd();
			simp.Invalidate();
		}
		private void Rotation(float x, float y, float z)
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glRotatef(10, x, y, z);
			DrawFigure(figure);
			simp.Invalidate();
		}

		private void toolStripDropDownButton2_Click(object sender, EventArgs e)
		{

		}

		private void ambientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color);
			simp.Invalidate();
		}

		private void diffuseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color);
			simp.Invalidate();
		}

		private void specularToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color);
			simp.Invalidate();
		}

		private void emissionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, color);
			simp.Invalidate();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Rotation(1, 1, 1);
		}

		private void simp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
				timer1.Start();
			if (e.KeyCode == Keys.X)
				timer1.Stop();
			if (e.KeyCode == Keys.Q)
				Rotation(1f, 0, 0);
			if (e.KeyCode == Keys.W)
				Rotation(-1f, 0, 0);
			if (e.KeyCode == Keys.E)
				Rotation(0, 1f, 0);
			if (e.KeyCode == Keys.R)
				Rotation(0, -1f, 0);
			if (e.KeyCode == Keys.T)
				Rotation(0, 0, 1f);
			if (e.KeyCode == Keys.Y)
				Rotation(0, 0, -1f);
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightX);

		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightY);

		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightZ);

		}

		private void toolStripDropDownButton2_Click_1(object sender, EventArgs e)
		{
			Gl.glEnable(Gl.GL_LIGHTING);
			Gl.glEnable(Gl.GL_LIGHT0);
			Gl.glEnable(Gl.GL_NORMALIZE);
			Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
			Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
		}
	}
}
