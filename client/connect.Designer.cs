/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 25.04.2016
 * Время: 12:33
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace client
{
	partial class connect
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button ConnectBut;
		private System.Windows.Forms.TextBox Nickname;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ConnectBut = new System.Windows.Forms.Button();
			this.Nickname = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ConnectBut
			// 
			this.ConnectBut.Location = new System.Drawing.Point(86, 163);
			this.ConnectBut.Name = "ConnectBut";
			this.ConnectBut.Size = new System.Drawing.Size(75, 23);
			this.ConnectBut.TabIndex = 0;
			this.ConnectBut.Text = "button1";
			this.ConnectBut.UseVisualStyleBackColor = true;
			this.ConnectBut.Click += new System.EventHandler(this.ConnectBut_Click);
			// 
			// Nickname
			// 
			this.Nickname.Location = new System.Drawing.Point(86, 109);
			this.Nickname.Name = "Nickname";
			this.Nickname.Size = new System.Drawing.Size(100, 20);
			this.Nickname.TabIndex = 3;
			// 
			// connect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 310);
			this.Controls.Add(this.Nickname);
			this.Controls.Add(this.ConnectBut);
			this.Name = "connect";
			this.Text = "connect";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
