﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 21.04.2016
 * Время: 12:11
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace local_chat_v2.__
{
	partial class ServerForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hostServer;
		private System.Windows.Forms.RichTextBox HistoryBox;
		private System.Windows.Forms.ToolStripMenuItem stopServer;
		private System.Windows.Forms.ToolStripMenuItem exit;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostServer = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryBox = new System.Windows.Forms.RichTextBox();
            this.UserListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.SearchMsg});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(459, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostServer,
            this.stopServer,
            this.exit});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // hostServer
            // 
            this.hostServer.Name = "hostServer";
            this.hostServer.Size = new System.Drawing.Size(135, 22);
            this.hostServer.Text = "Запустить";
            this.hostServer.Click += new System.EventHandler(this.HostServerClick);
            // 
            // stopServer
            // 
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(135, 22);
            this.stopServer.Text = "Остановить";
            this.stopServer.Click += new System.EventHandler(this.StopServerClick);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(135, 22);
            this.exit.Text = "Выход";
            this.exit.Click += new System.EventHandler(this.ExitClick);
            // 
            // SearchMsg
            // 
            this.SearchMsg.Name = "SearchMsg";
            this.SearchMsg.Size = new System.Drawing.Size(108, 20);
            this.SearchMsg.Text = "Поиск сообщений";
            this.SearchMsg.Click += new System.EventHandler(this.SearchMsg_Click);
            // 
            // HistoryBox
            // 
            this.HistoryBox.BackColor = System.Drawing.SystemColors.Window;
            this.HistoryBox.Location = new System.Drawing.Point(12, 27);
            this.HistoryBox.Name = "HistoryBox";
            this.HistoryBox.ReadOnly = true;
            this.HistoryBox.Size = new System.Drawing.Size(227, 316);
            this.HistoryBox.TabIndex = 1;
            this.HistoryBox.Text = "";
            // 
            // UserListBox
            // 
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.Location = new System.Drawing.Point(279, 27);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(166, 316);
            this.UserListBox.TabIndex = 2;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 355);
            this.Controls.Add(this.UserListBox);
            this.Controls.Add(this.HistoryBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerForm";
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem SearchMsg;

	}
}
