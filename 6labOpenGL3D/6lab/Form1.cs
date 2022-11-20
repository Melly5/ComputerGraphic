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

namespace _6lab
{
	public partial class Form1 : Form
	{
        float[,] cube = { { 1, 1, 1 }, { -1, 1, 1 }, { -1, -1, 1 }, { 1, -1, 1 }, { 1, 1, -1 }, { -1, 1, -1 }, { -1, -1, -1 }, { 1, -1, -1 } };
        float[,] pyramid = { { 0, 0.7f, 0 }, { 0, -0.5f, -0.5f }, { -0.5f, -0.5f, 0 },{ -0.25f, -0.5f, 0.5f }, { 0.25f, -0.5f, 0.5f }, { 0.5f, -0.5f, 0 } };

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
			Gl.glTranslatef(0, 0, -8);
            DrawCube(cube);
            DrawPyramid(pyramid);
            simp.Invalidate();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
            Rotation(1, 1, 1);
		}

		private void Rotation(float x, float y, float z)
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glRotatef(10, x, y, z);
            DrawCube(cube);
            DrawPyramid(pyramid);
            simp.Invalidate();
		}

		private void simp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
				timer1.Start();
			if (e.KeyCode == Keys.X)
				timer1.Stop();
		}

        void DrawCube(float[,] a)
        {         
            Gl.glLineWidth(2f);
            Gl.glColor3f(0, 0, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);


            Gl.glBegin(Gl.GL_QUADS);
            for (int i = 0; i < 4; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();

            for (int i = 0; i < 4; i++)
            {
                Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
                Gl.glVertex3f(a[i + 4, 0], a[i + 4, 1], a[i + 4, 2]);
                Gl.glEnd();
            }
           
            Gl.glBegin(Gl.GL_QUADS);
            for (int i = 4; i < 8; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();

            simp.Invalidate();
        }

        void DrawPyramid(float[,] a)
        {
            Gl.glColor3f(0, 1, 0);
            Gl.glLineWidth(2f);

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 1; i < 6; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();


            for (int i = 1; i < 6; i++)
            {
                Gl.glBegin(Gl.GL_LINE_LOOP);
                    Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                    Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
                Gl.glEnd();
            }
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);

            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0.52f, 0.44f, 1.0f);//violet
                Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
                Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(1, 0.84f, 0);//yellow
                Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
                Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0.94f, 0.5f, 0.5f);//pink
                Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
                Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0, 1, 0);//green
                Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);
                Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor3f(0, 0, 1);//pink
                Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
                Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
                Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);// основание пирамиды
            Gl.glColor3f(1f, 0.51f, 0.28f); // orange
            for (int i = 1; i < 6; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();

            simp.Invalidate();
        }
    }
}
