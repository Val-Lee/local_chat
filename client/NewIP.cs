/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 07.05.2016
 * Время: 12:49
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace client
{
	/// <summary>
	/// Description of NewIP.
	/// </summary>
	public partial class NewIP : Form
	{
		private ClientForm frm;
		public NewIP(ClientForm f)
		{
			frm = f;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Connect_Click(object sender, EventArgs e)
		{
			frm.IPsr = NewIPBox.Text;
			frm.ConnectToServ();
			this.Close();
	
		}
	}
}
