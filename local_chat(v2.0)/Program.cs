/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 21.04.2016
 * Время: 12:11
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;

namespace local_chat_v2.__
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        //client.ClientForm cf;
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //client.ClientForm a = new client.ClientForm();
          //  Application.Run(new ServerForm(a));
            Application.Run(new ServerForm());


        }
    }
}