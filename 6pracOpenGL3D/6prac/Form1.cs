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

namespace _6prac
{
	public partial class Form1 : Form
	{
		float[,] cube = { { 0f, 0f, 0f }, { 0.5f, 0f, 0f }, { 0.5f, 0.5f, 0f }, { 0f, 0.5f, 0f }, { 0f, 0f, 0.5f }, { 0.5f, 0f, 0.5f }, { 0.5f, 0.5f, 0.5f }, { 0f, 0.5f, 0.5f } };

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
			simp.Invalidate();

		}
        void DrawCube(float[,] a)
        {
            Gl.glColor3f(0, 0.5f, 1);
            Gl.glLineWidth(2f);

            Gl.glBegin(Gl.GL_LINE_LOOP);
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

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 4; i < 8; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();

            Gl.glColor3f(0.5f, 0.3f, 0.8f);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < 8; i++)
                Gl.glVertex3f(a[i, 0], a[i, 1], a[i, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
            Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
            Gl.glVertex3f(a[7, 0], a[7, 1], a[7, 2]);
            Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);    
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
            Gl.glVertex3f(a[0, 0], a[0, 1], a[0, 2]);
            Gl.glVertex3f(a[4, 0], a[4, 1], a[4, 2]);
            Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
            Gl.glVertex3f(a[3, 0], a[3, 1], a[3, 2]);
            Gl.glVertex3f(a[7, 0], a[7, 1], a[7, 2]);
            Gl.glVertex3f(a[6, 0], a[6, 1], a[6, 2]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(a[1, 0], a[1, 1], a[1, 2]);
            Gl.glVertex3f(a[2, 0], a[2, 1], a[2, 2]);
            Gl.glVertex3f(a[6, 0], a[6, 1], a[6, 2]);
            Gl.glVertex3f(a[5, 0], a[5, 1], a[5, 2]);
            Gl.glEnd();

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
            simp.Invalidate();
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
    }
}
