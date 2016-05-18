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
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace local_chat_v2.__
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class ServerForm : Form
	{
		//VARS
		public string  servName, IPsr, UserName;
		public Socket[] client;
		Socket newsock;
		IPEndPoint iep;
		int NumCl;
		public int MxUsr, PORTsr;
		public string[] userlist;
		public Socket ClToSr;
		public bool CONNECTED = false, ISCLIENT;
		delegate void SetTextCallback(string text);
		delegate void MovTextCallback();
		delegate void UpdUserList();
		
		public ServerForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			StatusCHange();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void HostServerClick(object sender, EventArgs e)
		{
			try {
				MxUsr = 15;
				client = new Socket[15];
				userlist = new string[15];
				MakeServerStart();
				AddHist("\n" + "Сервер запущен.");
			} catch (Exception x) {
				MessageBox.Show(x.Message);
			}
		}
		void StopServerClick(object sender, EventArgs e)
		{
			CONNECTED = false;
			if (ISCLIENT)
			{
				try
				{
					ClToSr.Close();
				}
				catch { }
				try
				{
					ClToSr = null;
				}
				catch { }
				AddHist("\nОтключены успешно");
			}
			else
			{
				int nwU = 0;
				while (MxUsr > nwU) {
					if (client[nwU] != null) {
						try {
							client[nwU].Close();
						} catch {
						}
						try {
							client[nwU] = null;
						} catch {
						}
					}
					nwU++;
				}
				try {
					newsock.Close();
				} catch {
				}
				try {
					newsock = null;
				} catch {
				}
			}
			CONNECTED = false;
			StatusCHange();
		}
		void ExitClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		public void MakeServerStart()
		{
			CONNECTED = true;
			StatusCHange();
			newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			iep = new IPEndPoint(IPAddress.Any, 9050);
			newsock.Bind(iep);
			newsock.Listen(5);
			newsock.BeginAccept(new AsyncCallback(AcceptConn), newsock);
			//	UpdateUserList();
			
		}
		
		
		void StatusCHange()
		{
			if (CONNECTED)
			{
				hostServer.Enabled = false;
				stopServer.Enabled = true;

			}
			else
			{
				stopServer.Enabled = false;
				hostServer.Enabled = true;
				
			}
		}
		
		
		void AcceptConn(IAsyncResult iar)
		{
			NumCl = 0;
			string usrName;
			if (CONNECTED)
			{
				Socket oldserver = (Socket)iar.AsyncState;
				while (client[NumCl] != null)
				{
					NumCl++;
					if (NumCl > MxUsr - 1)
					{
						NumCl = -1;
						break;
					}
				}
				if (NumCl == -1)
				{
					oldserver.Close();
					MakeServerStart();
				}
				else
				{
					try
					{
						client[NumCl] = oldserver.EndAccept(iar);
					}
					catch
					{
					}
					oldserver.Close();


					byte[] data = new byte[1024];
					int recv;

					try
					{
						recv = client[NumCl].Receive(data);
					}
					catch
					{
						AddHist("\nОшибка соединения с клиентом");
						client[NumCl] = null;
						MakeServerStart();
						return;
					}

					usrName = Encoding.UTF8.GetString(data, 0, recv);

					int nwUsr = 0;
					while (MxUsr > nwUsr)
					{
						if (userlist[nwUsr] != null)
						{
							if (userlist[nwUsr].Trim() == usrName.Trim())
							{
								byte[] message = Encoding.UTF8.GetBytes("Пользователь с таким ником уже существует");
								client[NumCl].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataEnd), client[NumCl]);
								client[NumCl].Close();
								client[NumCl] = null;
								//MakeServerStart();
								return;
							}
						}
						nwUsr++;
					}

					userlist[NumCl] = usrName;

					AddHist("\nПодключён: " + client[NumCl].RemoteEndPoint.ToString() + " : " + userlist[NumCl]);
					SendToAll("\nПодключён: " + userlist[NumCl], NumCl);
					
					Thread receiver = new Thread(ReceiveData);
					receiver.IsBackground = true;
					receiver.Start(NumCl);
					MakeServerStart();
					UpdateUserList();
				}
			} 
			else
			{
				AddHist("\nСервер ушел спать");
			}
		}
		
		
		public void AddHist(string text)
		{
			if (this.HistoryBox.InvokeRequired) {

				SetTextCallback d = new SetTextCallback(AddHist);
				this.Invoke(d, new object[] { text });
			} else {
				HistoryBox.Text += text;
				HistoryBox.SelectionStart = HistoryBox.TextLength;
				HistoryBox.ScrollToCaret();
			}
		}
		public void MoveHist()
		{
			if (this.HistoryBox.InvokeRequired) {

				MovTextCallback d = new MovTextCallback(MoveHist);
				this.Invoke(d, new object[] { });
			} else {
				HistoryBox.SelectionStart = HistoryBox.TextLength;
				HistoryBox.ScrollToCaret();
			}
		}
		
		public void SendDataEnd(IAsyncResult iar)
		{
			try {
				Socket remote = (Socket)iar.AsyncState;
				int sent = remote.EndSend(iar);
			} catch {
			}
		}
		
		void ReceiveData(object nm)
		{
			byte[] data = new byte[1024];
			int Clnm = (int)nm;
			int recv = 0;
			string stringData = "", stData = "", userNM = userlist[Clnm];


			while (true) {
				try {
					Thread sendall = new Thread(delegate() {
					                            	SendToAll(stringData, Clnm);
					                            });
					sendall.IsBackground = true;

					Thread Privat = new Thread(delegate() {
					                           	PrivatMessage(stData);
					                           });
					Privat.IsBackground = true;

					recv = client[Clnm].Receive(data);

					if (Encoding.UTF8.GetString(data, 0, recv) == "*get_all_users_tocl*")
					{
						Thread getlist = new Thread(delegate() {
						                            	GenUserList(Clnm);
						                            });
						getlist.IsBackground = true;
						getlist.Start();
						stringData = "*get_all_users_tocl*";
				 	}
					else
					{
						string ttt = Encoding.UTF8.GetString(data, 0, recv);
						//if (ttt.Substring((userlist[Clnm].Length + 3)).Length >= 4)
						//{
							if (ttt.Contains("%пр%"))
							{
								stData = Encoding.UTF8.GetString(data, 0, recv);
								Privat.Start();
								stringData = "*get_all_users_tocl*";
							}
							else
							{
								stringData = Encoding.UTF8.GetString(data, 0, recv);
								sendall.Start();
							}
						//}
                        //else
                        //{
                        //    stringData = Encoding.UTF8.GetString(data, 0, recv);
                        //    sendall.Start();
                        //}
					}

				}
				catch {
					
					AddHist("\nПользователь \"" + userNM + "\" отключился.");
					SendToAll("\nПользователь \"" + userNM + "\" отключился.", Clnm);
					
					break;
				}
				if (stringData != "*get_all_users_tocl*") {
					AddHist(stringData);
					MoveHist();
				}
			}
			try {
				client[Clnm].Close();
			} catch {
			}
			client[Clnm] = null;
			userlist[Clnm] = null;
			UpdateUserList();
		}
		void SendToAll(string mess, int clSNDD)
		{
			int i = 0;
			while (i < MxUsr) {
				if ((clSNDD != i) && (client[i] != null)) {
					byte[] message = Encoding.UTF8.GetBytes(mess);
					client[i].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), client[i]);
				}
				i++;
			}
		}
		void SendData(IAsyncResult iar)
		{
			Socket remote = (Socket)iar.AsyncState;
			int sent = remote.EndSend(iar);
		}
		
		void PrivatMessage(string text)
		{
			string[] txtC = text.Split('%');
			int mxI = txtC.Length, now = 0;
            string curTimeLong = DateTime.Now.ToLongTimeString();
			string Tsend = "";
			string User = "";//from
			string UtS = "";//to
			try {
				UtS = txtC[2];
				Tsend = "\n" + curTimeLong + " Приват от \"" + User + "\": " + text.Substring(txtC[0].Length + txtC[1].Length + txtC[2].Length + 3);

				if (User != UtS) {
					
						while (MxUsr > now) {
							if (userlist[now] == UtS) {
								try {
									byte[] message = Encoding.UTF8.GetBytes(Tsend);
									client[now].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), client[now]);
								} 
                                catch 
                                {}
								break;

							}
							now++;
						}
                        if (now == MxUsr)
                        {
                            now = 0;

                            while (MxUsr > now)
                            {
                                if (userlist[now] == User || userlist[now] != UtS)
                                {
                                    try
                                    {
                                        byte[] message = Encoding.UTF8.GetBytes("\nПользователь \"" + UtS + "\" не найден.");
                                        client[now].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), client[now]);
                                    }
                                    catch { }
                                    break;
                                }
                                now++;

                            }
                        }
				}
			} catch {
				try {
					byte[] message = Encoding.UTF8.GetBytes("\nПользователь \"" + UtS + "\" не найден.");
					client[now].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), client[now]);
				} catch {
				}
			}

		}
		
		void GenUserList(int usrID)
		{
			byte[] data = new byte[1024];
			int nowu = 0;
			byte[] message;
			string usLi = "";
			message = Encoding.UTF8.GetBytes(" ");
			client[usrID].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataEnd), client[usrID]);
			
			while (nowu < MxUsr)
			{
				if (userlist[nowu] != null) {
					usLi += "%" + userlist[nowu];
				}
				nowu++;
			}
			message = Encoding.UTF8.GetBytes(usLi);
			client[usrID].BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendDataEnd), client[usrID]);
		}

		void UpdateUserList()
		{
			if (UserListBox.InvokeRequired)
			{
				
				UpdUserList d = new UpdUserList(UpdateUserList);
				this.Invoke(d, new object[] { });
			}
			else
			{
				UserListBox.Items.Clear();
				int curusr = 0;
				while (MxUsr > curusr)
				{
					if (userlist[curusr] != null)
					{
						UserListBox.Items.Add(userlist[curusr] + " : " + client[curusr].RemoteEndPoint.ToString());
					}
					curusr++;
				}
			}
		}



		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
		}

		void MainFormLoad(object sender, EventArgs e)
		{
		}



		


	}
	
}
