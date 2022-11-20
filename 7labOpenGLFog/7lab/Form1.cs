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

namespace _7lab
{
	public partial class Form1 : Form
	{
		float ang = 0;
		float[] fogColor = { 1, 1, 1, 1 };

		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Gl.glFrustum(-1, 1, -1, 1, 2, 10);
			//не знаю нужна ли перспектива здесь
			//Glu.gluPerspective(45, simp.Width / simp.Height, 0.1, 200);

			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();
			Gl.glTranslated(0, 0, -6);

			Gl.glEnable(Gl.GL_BLEND);
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);


			//с моими фигурами было плохо видно туман, поэтому сделали с преподавателем GL_EXP
			//вместо linear что ли, поэтому не ориентируйтесь здесь на туман
			Gl.glEnable(Gl.GL_FOG);
			Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP);
			Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
			Gl.glFogf(Gl.GL_FOG_DENSITY, 0.4f);
			Gl.glFogf(Gl.GL_FOG_START, 5f);
			Gl.glFogf(Gl.GL_FOG_END, 10);
		}

		void Draw(float angle)
		{

			Gl.glClearColor(255, 255, 255, 1);
			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);


			Gl.glPushMatrix();
			Gl.glRotated(45, 1, 1, 0);
			Gl.glColor4f(0f, 0.5f, 0.5f, 1f);
			Gl.glRotatef(angle, 1, 1, 1);
			Gl.glTranslatef(0f, 0.9f, 0);
			Glut.glutSolidTeapot(0.1f);
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glColor4f(0.5f, 0f, 0.5f, 1f);
			Gl.glRotatef(angle, 0f, 1f, 0f);
			Gl.glTranslatef(1f, 0, 0);
			Gl.glScaled(0.3, 0.3, 0.3);
			Glut.glutSolidIcosahedron();
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glColor4f(0.5f, 1f, 0f, 1f);
			Gl.glRotatef(angle, 1f, 0f, 0f);
			Glut.glutSolidCone(0.4f, 0.8f, 50, 50);
			Gl.glPopMatrix();

			simp.Invalidate();

		}


		private void simp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Q)
			{
				ang += 10;
				Draw(ang);
			}

			if (e.KeyCode == Keys.X)
				timer1.Stop();
			if (e.KeyCode == Keys.Space)
				timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			ang += 10;
			Draw(ang);
		}

		private void simp_Load(object sender, EventArgs e)
		{

		}
	}
}
