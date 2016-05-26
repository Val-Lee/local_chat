/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 25.04.2016
 * Время: 12:33
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace client
{
	/// <summary>
	/// Description of connect.
	/// </summary>
	public partial class connect : Form
	{
		private ClientForm frm;
		public connect(ClientForm f)
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
		void ConnectBut_Click(object sender, EventArgs e)
		{
			try
            {
                if (Nickname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Введите ник!");
                    return;
                }
                string[] lof = Nickname.Text.Split('%');
                if (lof.Length > 1)
                {
                    MessageBox.Show("Ник не должен содержать символ %");
                    return;
                }
                frm.UserName = Nickname.Text;
            }
            catch
            {
                MessageBox.Show("Неверные значения");
                return;
            }
            frm.ConnectToServ();
            this.Close();
	
		}

        private void Nickname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConnectBut_Click(this, EventArgs.Empty);
            }
        }

        private void connect_Load(object sender, EventArgs e)
        {
            Nickname.Focus();
        }
	}
}
