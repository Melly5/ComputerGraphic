namespace _6lab
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
			this.simp = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
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
			this.simp.Location = new System.Drawing.Point(5, 4);
			this.simp.Name = "simp";
			this.simp.Size = new System.Drawing.Size(793, 508);
			this.simp.StencilBits = ((byte)(0));
			this.simp.TabIndex = 0;
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
			this.ClientSize = new System.Drawing.Size(800, 519);
			this.Controls.Add(this.simp);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private Tao.Platform.Windows.SimpleOpenGlControl simp;
		private System.Windows.Forms.Timer timer1;
	}
}

