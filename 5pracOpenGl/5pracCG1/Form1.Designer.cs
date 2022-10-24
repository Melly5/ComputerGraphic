namespace _5pracCG1
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.simp = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.poligonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// simp
			// 
			this.simp.AccumBits = ((byte)(0));
			this.simp.AutoCheckErrors = false;
			this.simp.AutoFinish = false;
			this.simp.AutoMakeCurrent = true;
			this.simp.AutoSwapBuffers = true;
			this.simp.BackColor = System.Drawing.Color.Black;
			this.simp.ColorBits = ((byte)(32));
			this.simp.DepthBits = ((byte)(16));
			this.simp.Location = new System.Drawing.Point(12, 42);
			this.simp.Name = "simp";
			this.simp.Size = new System.Drawing.Size(648, 460);
			this.simp.StencilBits = ((byte)(0));
			this.simp.TabIndex = 0;
			this.simp.Paint += new System.Windows.Forms.PaintEventHandler(this.simp_Paint);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(675, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linesToolStripMenuItem,
            this.poligonToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// linesToolStripMenuItem
			// 
			this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
			this.linesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.linesToolStripMenuItem.Text = "Lines";
			this.linesToolStripMenuItem.Click += new System.EventHandler(this.linesToolStripMenuItem_Click);
			// 
			// poligonToolStripMenuItem
			// 
			this.poligonToolStripMenuItem.Name = "poligonToolStripMenuItem";
			this.poligonToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.poligonToolStripMenuItem.Text = "Polygon";
			this.poligonToolStripMenuItem.Click += new System.EventHandler(this.poligonToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 512);
			this.Controls.Add(this.simp);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Tao.Platform.Windows.SimpleOpenGlControl simp;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem poligonToolStripMenuItem;
	}
}

