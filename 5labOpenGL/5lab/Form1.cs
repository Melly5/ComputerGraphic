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

namespace _5lab
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();
            Gl.glViewport(0, 0, simp.Width, simp.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            drawA();
            drawB();
            simp.Invalidate();
        }

        float[,] figure1 = { { -0.65f, 0.1f }, { -0.5f, 0.2f }, { -0.35f, 0.1f }, { -0.35f, -0.1f }, { -0.5f, -0.2f }, { -0.65f, -0.1f }, { -0.5f, 0f } };
        float[,] figure2 = { { -0.12f, 0.07f }, { 0.12f, 0.07f }, { 0.12f, -0.07f }, { -0.12f, -0.07f }, { -0.12f, 0.15f }, { -0.05f, 0.07f }, { 0.12f, -0.15f }, { 0.05f, -0.07f }, { 0f, 0f } };
        float angleA = 0, angleB = 0, dxA = 0, dyA = 0, dzA = 0, dxB = 0, dyB = 0, dzB = 0, sA = 1, sB = 1;
        /*
         Q - поворот по час фиг А
         Е - поворот против час фиг А
         a/w/s/d - движение А
         4/8/6/2 - движение Б
         1 - поворот по час А вокруг Б
         2 - поворот против час А вокруг Б
         3 - цикл А
         4 - увеличение А
         5 - уменьшение Б
         6 - поворот по час Б
         7 - поворот против час Б
         8 - увеличение Б
         9 - уменьшение Б

        */
        void drawA()
        {
            Gl.glColor4f(0, 1, 0, 0.2f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < 6; i++)
            {
                Gl.glVertex2f(figure1[i, 0], figure1[i, 1]);
            }
            Gl.glEnd();

            Gl.glColor4f(0, 0.7f, 0, 0.2f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 6; i++)
            {
                Gl.glVertex2f(figure1[i, 0], figure1[i, 1]);
            }
            Gl.glEnd();

            Gl.glPointSize(3f);
            Gl.glColor3f(0, 0, 0);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 6; i++)
            {
                Gl.glVertex2f(figure1[i, 0], figure1[i, 1]);
            }
            Gl.glEnd();

            Gl.glColor4f(0, 0.8f, 1, 0.2f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 1; i < 6; i = i + 2)
            {
                Gl.glVertex2f(figure1[i, 0], figure1[i, 1]);
            }
            Gl.glEnd();

            Gl.glColor4f(0, 0, 0.7f, 0.2f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 1; i < 6; i = i + 2)
            {
                Gl.glVertex2f(figure1[i, 0], figure1[i, 1]);
            }
            Gl.glEnd();

            Gl.glPointSize(4f);
            Gl.glColor3f(0, 0, 1);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2f(figure1[6, 0], figure1[6, 1]);
            Gl.glEnd();

            simp.Invalidate();
        }

        void drawB()
        {
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(2);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 4; i++)
            {
                Gl.glVertex2f(figure2[i, 0], figure2[i, 1]);
            }
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(figure2[0, 0], figure2[0, 1]);
            Gl.glVertex2f(figure2[4, 0], figure2[4, 1]);
            Gl.glVertex2f(figure2[5, 0], figure2[5, 1]);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(figure2[6, 0], figure2[6, 1]);
            Gl.glVertex2f(figure2[2, 0], figure2[2, 1]);
            Gl.glVertex2f(figure2[7, 0], figure2[7, 1]);
            Gl.glEnd();

            Gl.glPointSize(6f);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2f(figure2[8, 0], figure2[8, 1]);
            Gl.glEnd();

            simp.Invalidate();
        }

        private void simp_KeyDown(object sender, KeyEventArgs e)
		{

            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.E || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 || e.KeyCode == Keys.W || e.KeyCode == Keys.D || e.KeyCode == Keys.A || e.KeyCode == Keys.S)
            {
                Gl.glScaled(sB, sB, 1);
                Gl.glRotated(angleB, 0, 0, 1);
                Gl.glTranslatef(dxB, dyB, dzB);
                drawB();
                Gl.glPopMatrix();
                Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glScaled(sA, sA, 1);
                Gl.glRotated(angleA, 0, 0, 1);
                Gl.glTranslatef(dxA, dyA, dzA);
                drawA();
                Gl.glPopMatrix();
            }
            else
			{
                Gl.glScaled(sA, sA, 1);
                Gl.glRotated(angleA, 0, 0, 1);
                Gl.glTranslatef(dxA, dyA, dzA);
                drawA();
                Gl.glPopMatrix();
                Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glScaled(sB, sB, 1);
                Gl.glRotated(angleB, 0, 0, 1);
                Gl.glTranslatef(dxB, dyB, dzB);
                drawB();
                Gl.glPopMatrix();
            }
                

            
         
            if (e.KeyCode == Keys.D4)
			{
                sA += 0.1f;
            }
            if (e.KeyCode == Keys.D5)
            {
                sA -= 0.1f;
            }

            if (e.KeyCode == Keys.D8)
            {
                sB += 0.1f;
            }
            if (e.KeyCode == Keys.D9)
            {
                sB -= 0.1f;
            }

            if (e.KeyCode == Keys.D)
            {
                dxA += 0.1f;
            }
            if (e.KeyCode == Keys.A)
            {
                dxA -= 0.1f;
            }

            if (e.KeyCode == Keys.NumPad4)
            {
                dxB -= 0.1f;
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                dxB += 0.1f;
            }

            if (e.KeyCode == Keys.W)
			{
                dyA += 0.1f;
            }
            if (e.KeyCode == Keys.S)
            {
                dyA -= 0.1f;
            }

            if (e.KeyCode == Keys.NumPad8)
            {            
                dyB += 0.1f;
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                dyB -= 0.1f;
            }

            if (e.KeyCode == Keys.D1)
			{
                angleA += 10;
            }
            if (e.KeyCode == Keys.D2)
            {
                angleA -= 10;
            }

            if (e.KeyCode == Keys.D3)
			{
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                for (int i = 0; i < 160; i++)
                {
                    Gl.glPushMatrix();
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glScaled(sB, sB, 1);
                    Gl.glRotated(angleB, 0, 0, 1);
                    Gl.glTranslatef(dxB, dyB, dzB);
                    drawB();
                    Gl.glPopMatrix();
                    Gl.glPushMatrix();
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glScaled(sA, sA, 1);
                    Gl.glRotated(angleA, 0, 0, 1);
                    Gl.glTranslatef(dxA, dyA, dzA);
                    drawA();
                    Gl.glPopMatrix();
                    angleA += 40;
                }
            }
            if (e.KeyCode == Keys.D6)
            {
                angleB += 10;
            }
            if (e.KeyCode == Keys.D7)
            {
                angleB -= 10;
            }

            if (e.KeyCode == Keys.Q)
            {
                angleA += 10;
            }
            if (e.KeyCode == Keys.E)
            {
                angleA -= 10;
            }

            simp.Invalidate();
        }


	}
}
