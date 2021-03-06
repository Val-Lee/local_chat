﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 25.04.2016
 * Время: 11:58
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace client
{
	partial class ClientForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox HistoryBox;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		//private System.Windows.Forms.ToolStripMenuItem ConnectToServ;
		private System.Windows.Forms.Button SendBut;
		private System.Windows.Forms.RichTextBox SendBox;
		private System.Windows.Forms.ToolStripMenuItem connectToServer;
		private System.Windows.Forms.ToolStripMenuItem disconnect;
        private System.Windows.Forms.ListBox UserListBox;
		
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
            this.components = new System.ComponentModel.Container();
            this.HistoryBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.SendBut = new System.Windows.Forms.Button();
            this.SendBox = new System.Windows.Forms.RichTextBox();
            this.UserListBox = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HistoryBox
            // 
            this.HistoryBox.BackColor = System.Drawing.SystemColors.Window;
            this.HistoryBox.Location = new System.Drawing.Point(12, 38);
            this.HistoryBox.Name = "HistoryBox";
            this.HistoryBox.ReadOnly = true;
            this.HistoryBox.Size = new System.Drawing.Size(292, 253);
            this.HistoryBox.TabIndex = 3;
            this.HistoryBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToServer,
            this.disconnect,
            this.выходToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // connectToServer
            // 
            this.connectToServer.Name = "connectToServer";
            this.connectToServer.Size = new System.Drawing.Size(156, 22);
            this.connectToServer.Text = "Подключиться";
            this.connectToServer.Click += new System.EventHandler(this.connectToServer_Click);
            // 
            // disconnect
            // 
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(167, 22);
            this.disconnect.Text = "Отключиться";
            this.disconnect.Click += new System.EventHandler(this.DisconnectClick);
            // 
            // SendBut
            // 
            this.SendBut.Location = new System.Drawing.Point(336, 297);
            this.SendBut.Name = "SendBut";
            this.SendBut.Size = new System.Drawing.Size(75, 42);
            this.SendBut.TabIndex = 5;
            this.SendBut.Text = "Отправить";
            this.SendBut.UseVisualStyleBackColor = true;
            this.SendBut.Click += new System.EventHandler(this.SendBut_Click);
            // 
            // SendBox
            // 
            this.SendBox.Location = new System.Drawing.Point(12, 297);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(292, 42);
            this.SendBox.TabIndex = 4;
            this.SendBox.Text = "";
            this.SendBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SendBoxKeyUp);
            // 
            // UserListBox
            // 
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.Location = new System.Drawing.Point(336, 38);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(166, 251);
            this.UserListBox.TabIndex = 6;
            this.UserListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UserListBox_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 344);
            this.Controls.Add(this.UserListBox);
            this.Controls.Add(this.SendBut);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.HistoryBox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ClientForm";
            this.Text = "Local Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
	}
}
