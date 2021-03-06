﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Света
 * Дата: 25.04.2016
 * Время: 11:58
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace client
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public string adminName, servName, UserName;
		public string IPsr = "192.168.1.2";
		
		public int PortSr = 9050;
		public Socket[] client;
		public int MxUsr;
		public string[] userlist;

		public bool CONNECTED, ISCLIENT,micON;
		delegate void SetTextCallback(string text);
		delegate void MovTextCallback();
		public Thread receiverЫ;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		public Socket ClToSr;
		public void ConnectToServ()
		{
			ISCLIENT = true;
			CONNECTED = true;
			// StatusCHange();
			AddHist("\nСоединение...");
			ClToSr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IPsr), PortSr);
			
			ClToSr.BeginConnect(iep, new AsyncCallback(ConnectedToSr), ClToSr);
		}
		public void AddHist(string text)
		{
			if (this.HistoryBox.InvokeRequired)
			{

				SetTextCallback d = new SetTextCallback(AddHist);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				HistoryBox.Text += text;
				HistoryBox.SelectionStart = HistoryBox.TextLength;
				HistoryBox.ScrollToCaret();
			}
		}
		
		void ConnectedToSr(IAsyncResult iar)
		{
			try
			{

				ClToSr.EndConnect(iar);
				AddHist("\nУспешно подключены к: " + ClToSr.RemoteEndPoint.ToString());

				byte[] message = Encoding.UTF8.GetBytes(UserName);
				ClToSr.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataSr), ClToSr);

				receiverЫ = new Thread(new ThreadStart(ReceiveDataToSr));
				receiverЫ.Name = "RforCL";
				receiverЫ.IsBackground = true;
				receiverЫ.Start();

			}
			catch (SocketException)
			{
				CONNECTED = false;
				AddHist("\nОшибка соединения! Возможно сервер переполнен либо нет связи.");
				NewIPYo();
				
				// StatusCHange();
			}

		}
		
		void NewIPYo()
		{
			NewIP a = new NewIP(this);
			a.ShowDialog();
		}
		void SendDataSr(IAsyncResult iar)
		{
			Socket remote = (Socket)iar.AsyncState;
			int sent = remote.EndSend(iar);
		}
				
		void ReceiveDataToSr()
		{
			byte[] data = new byte[1024];
			int recv;
			string stringData;
			while (true)
			{
				try
				{
					recv = ClToSr.Receive(data);
				}
				catch { break; }
				stringData = Encoding.UTF8.GetString(data, 0, recv);
				AddHist(stringData);
				//                if (micON)
				//                {
				//                    aud.CurrentPosition = 0.0f;
				//                    aud.Play();
				//                }
				MoveHist();
			}
			ClToSr.Close();
			AddHist("\nСоединение c сервером было разорвано.");
			CONNECTED = false;
			//StatusCHange();
			return;
		}
		
		public void MoveHist()
		{
			if (this.HistoryBox.InvokeRequired)
			{

				MovTextCallback d = new MovTextCallback(MoveHist);
				this.Invoke(d, new object[] { });
			}
			else
			{
				HistoryBox.SelectionStart = HistoryBox.TextLength;
				HistoryBox.ScrollToCaret();
			}
		}
		void SendBut_Click(object sender, EventArgs e)
		{

			SendToSr(false);


		}
		void SendBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (e.Shift)
				{ return; }
				else
				{
					if (CONNECTED)
					{
						SendToSr(true);
					}
				}
			}
		}
		
		//void SendToSr(bool Ent)
		void SendToSr(bool Ent)
		{
			string RedY,priv=null;
			string curTimeLong = DateTime.Now.ToLongTimeString();
			if (SendBox.Text.Trim().Length > 0)
			{
				if (Ent)
					RedY = ("\n" + curTimeLong + " - " + UserName + ": " + SendBox.Text.Substring(0, SendBox.Text.Length - 1));
				else
					RedY = ("\n" + curTimeLong + " - " + UserName + ": " + SendBox.Text);

				byte[] message = Encoding.UTF8.GetBytes(RedY);

				if (SendBox.Text.Length >= 4)
				{
					if (SendBox.Text.Substring(0, 4) == "%пр%")
					{
						if (Ent)
							priv = ("\n" + curTimeLong + " - " + UserName + ": " + SendBox.Text.Substring(3, SendBox.Text.Length - 4));
						else
							priv = ("\n" + curTimeLong + " - " + UserName + ": " + SendBox.Text.Substring(3));
					}
				}
				if (priv != null)
				{
					AddHist(priv);
					MoveHist();

					SendBox.Clear();
					priv = null;
				}
				else
				{
					AddHist(RedY);
					MoveHist();

					SendBox.Clear();
				}

				ClToSr.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataSr), ClToSr);

			}
			else { SendBox.Clear(); }
		}
		void connectToServer_Click(object sender, EventArgs e)
		{
			connect con = new connect(this);
			con.ShowDialog();
			
		}
		void DisconnectClick(object sender, EventArgs e)
		{
			ClToSr.Close();
			CONNECTED = false;
			AddHist("Отключены успешно");
			
		}
        void UpdateUserList()
        {

            UserListBox.Items.Clear();

                string USERS = "";
                try
                {

                    byte[] data = new byte[1024];
                    int recv = 0;
                    byte[] message = Encoding.UTF8.GetBytes("*get_all_users_tocl*");
                    ClToSr.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataSr), ClToSr);

                    recv = ClToSr.Receive(data);

                    USERS = Encoding.UTF8.GetString(data, 0, recv);

                    string[] users = USERS.Split('%');

                    int mxvl = users.Length, nowl = 0;
                    while (mxvl > nowl)
                    {
                        if (users[nowl] == UserName)
                        {
                            users[nowl] = "[ " + users[nowl] + " ]";
                        }
                        UserListBox.Items.Add(users[nowl]);
                        nowl++;
                    }

                }
                catch { }
            
        }
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
		}
		void MainFormLoad(object sender, EventArgs e)
		{
//						System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
//            t.Tick += new EventHandler(Timer1Tick) ;
//            
//			t.Interval = 1000;
//			t.Start();
//			
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			//UpdateUserList();
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			UpdateUserList();
		}


		
	}
}
