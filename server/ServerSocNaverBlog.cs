using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //추가
using System.Net;//추가
using System.Net.Sockets;//추가
using System.IO;//추가
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;

namespace server
{
	public partial class Server : Form
	{

		private Socket acceptSocket; // 소켓 접속 위한. 서버에서만 존재
		private Socket dataSocket;
		private byte[] buffer;
		private bool isServerOpen; // Close 변수
		private bool isOpen;

		public Server()
		{
			InitializeComponent();
		}

		private void Server_Load(object sender, EventArgs e)
		{

		}
	
		private void btnOpen_Click(object sender, EventArgs e)
		{
			try
			{
				if (isServerOpen == true && acceptSocket.IsBound)
				{
					MessageBox.Show("서버 소켓이 이미 열려 있습니다..");

					return;
				}

				isServerOpen= true;
				acceptSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.IP);
				acceptSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse("5000")));
				acceptSocket.Listen(1);
				acceptSocket.BeginAccept(OnAccept, null);
				MessageBox.Show("서버 소켓이 열렸다");
			}
			catch (Exception)
			{
				MessageBox.Show("서버 소켓을 열수 없다.");
			}


		}

		private void OnAccept(IAsyncResult ar)
		{
			if (!isServerOpen) //! 의 의미는 bool타입 반대
			{
				return;
			}
			if (dataSocket == null) {
				//MessageBox.Show("OnAccept 1");
				buffer = new byte[1024];
				dataSocket = acceptSocket.EndAccept(ar);
				dataSocket.BeginReceive(buffer, 0, buffer.Length, 0, OnReceive, null);
				acceptSocket.BeginAccept(OnAccept,null);
			}
			else
			{
				MessageBox.Show("소켓 모두 연결되어있습니다.");
			}
		}

		private void OnReceive(IAsyncResult ar)// 데이터 받기
		{
			if (!dataSocket.Connected || dataSocket.EndReceive(ar) <= 0)
			{
				btnClose_Click(this, null);
				return;
			}
		string data = Encoding.Default.GetString(buffer);
			dataSocket.BeginReceive(buffer,0,buffer.Length, 0, OnReceive, null);
			listChat.Invoke(new Action(delegate ()
			{
				
				listChat.Items.Add(" 회원 :"+ data ); //받은 데이터 출력
				//listChat.Items.Add("recv: " + data);
			}));
		}

		
		private void btnClose_Click(object sender, EventArgs e)
		{
			if (!isServerOpen)
			{
				MessageBox.Show("서버 소켓이 열려있지 않습니다.");
				return;
			}

			isServerOpen = false;

			acceptSocket.Close();
			acceptSocket = null;
			MessageBox.Show("서버 소켓을 닫았습니다.");


			if (dataSocket != null)
			{
				dataSocket.Close();
				dataSocket = null;
			}
			


		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (isOpen)
			{
				MessageBox.Show("소켓이 열려있지 않습니다.");
				return;
			}
			string msg = textBox3.Text;
			dataSocket.Send(Encoding.Default.GetBytes(msg));
			//MessageBox.Show("보낸 메세지:" + msg);

			textBox3.Text = "";   //엔터 누르면 메세지 안보임 
		




		}

		private void txtSend_KeyDown(object sender, KeyEventArgs e)  //엔터키 누르면 전송되게 하기
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				btnSend_Click(sender, null);
			}
		}
		


	}



}

