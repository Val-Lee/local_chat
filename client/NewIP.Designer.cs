/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 07.05.2016
 * Время: 12:49
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace client
{
	partial class NewIP
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button Connect;
		private System.Windows.Forms.TextBox NewIPBox;
		
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
            this.Connect = new System.Windows.Forms.Button();
            this.NewIPBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(26, 99);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(200, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Подключится!";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // NewIPBox
            // 
            this.NewIPBox.Location = new System.Drawing.Point(26, 63);
            this.NewIPBox.Name = "NewIPBox";
            this.NewIPBox.Size = new System.Drawing.Size(200, 20);
            this.NewIPBox.TabIndex = 1;
            this.NewIPBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewIPBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Мы не можем подключится к серверу!\r\nПожалуйста, укажите новый IP адрес!";
            // 
            // NewIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewIPBox);
            this.Controls.Add(this.Connect);
            this.Name = "NewIP";
            this.Text = "Подключение";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Label label1;
	}
}
