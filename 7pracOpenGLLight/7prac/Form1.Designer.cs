namespace _7prac
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
			this.components = new System.ComponentModel.Container();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.ambientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diffuseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.specularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.simp = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 27);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ambientToolStripMenuItem,
            this.diffuseToolStripMenuItem,
            this.specularToolStripMenuItem,
            this.emissionToolStripMenuItem});
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 24);
			this.toolStripDropDownButton1.Text = "Material";
			// 
			// ambientToolStripMenuItem
			// 
			this.ambientToolStripMenuItem.Name = "ambientToolStripMenuItem";
			this.ambientToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.ambientToolStripMenuItem.Text = "Ambient";
			this.ambientToolStripMenuItem.Click += new System.EventHandler(this.ambientToolStripMenuItem_Click);
			// 
			// diffuseToolStripMenuItem
			// 
			this.diffuseToolStripMenuItem.Name = "diffuseToolStripMenuItem";
			this.diffuseToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.diffuseToolStripMenuItem.Text = "Diffuse";
			this.diffuseToolStripMenuItem.Click += new System.EventHandler(this.diffuseToolStripMenuItem_Click);
			// 
			// specularToolStripMenuItem
			// 
			this.specularToolStripMenuItem.Name = "specularToolStripMenuItem";
			this.specularToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.specularToolStripMenuItem.Text = "Specular";
			this.specularToolStripMenuItem.Click += new System.EventHandler(this.specularToolStripMenuItem_Click);
			// 
			// emissionToolStripMenuItem
			// 
			this.emissionToolStripMenuItem.Name = "emissionToolStripMenuItem";
			this.emissionToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.emissionToolStripMenuItem.Text = "Emission";
			this.emissionToolStripMenuItem.Click += new System.EventHandler(this.emissionToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(56, 24);
			this.toolStripDropDownButton2.Text = "Light";
			this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click_1);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
			this.toolStripMenuItem1.Text = "X";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
			this.toolStripMenuItem2.Text = "Y";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
			this.toolStripMenuItem3.Text = "Z";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
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
			this.simp.Location = new System.Drawing.Point(12, 30);
			this.simp.Name = "simp";
			this.simp.Size = new System.Drawing.Size(776, 482);
			this.simp.StencilBits = ((byte)(0));
			this.simp.TabIndex = 1;
			this.simp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simp_KeyDown);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 524);
			this.Controls.Add(this.simp);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem ambientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem diffuseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem specularToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emissionToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private Tao.Platform.Windows.SimpleOpenGlControl simp;
		private System.Windows.Forms.Timer timer1;
	}
}

