﻿/*
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectBut
            // 
            this.ConnectBut.Location = new System.Drawing.Point(24, 72);
            this.ConnectBut.Name = "ConnectBut";
            this.ConnectBut.Size = new System.Drawing.Size(173, 23);
            this.ConnectBut.TabIndex = 0;
            this.ConnectBut.Text = "Подключиться!";
            this.ConnectBut.UseVisualStyleBackColor = true;
            this.ConnectBut.Click += new System.EventHandler(this.ConnectBut_Click);
            // 
            // Nickname
            // 
            this.Nickname.Location = new System.Drawing.Point(24, 37);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(173, 20);
            this.Nickname.TabIndex = 3;
            this.Nickname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nickname_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите ник";
            // 
            // connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.ConnectBut);
            this.Name = "connect";
            this.Text = "Подключение";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Label label1;
	}
}
