using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Remoting.Contexts;


namespace client
{
	public partial class Client : Form
	{

		private Socket dataSocket; //연결 소켓
		private bool isOpen; // 연결 확인
		private byte[] buffer; // 메모리

		public Client()
		{
			InitializeComponent();
		}
		private void Client_Load(object sender, EventArgs e)
		{
			dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP); //왜 IP로 하지
		}
		private void button1_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (isOpen && dataSocket.Connected)
				{
					MessageBox.Show("소켓이 이미열려있음");
					return;
				}
				isOpen = true;

				dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
				dataSocket.Connect("10.10.10.60", int.Parse("5000"));
				buffer = new byte[1024];
				dataSocket.BeginReceive(buffer, 0, buffer.Length, 0, OnReceive, null);
				MessageBox.Show("소켓이 열렸습니다.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("소켓을 열 수 없습니다.");
				MessageBox.Show(ex.Message);
			}
			
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (!isOpen)
			{
				MessageBox.Show("소켓이 안 열려있음");
				return;   //돌려보내기
			} 
			string msg = textBox3.Text; // 보내는 msg
			dataSocket.Send(Encoding.Default.GetBytes(msg)); //데이터 소켓은 보낸다 (인코딩해서 기본적인 ms 바이트를 .
			MessageBox.Show("보낸 메시지 : " + msg);

			dataSocket.Close();
			dataSocket= null;
			MessageBox.Show("소켓을 닫았음");
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (!isOpen)
			{
				MessageBox.Show("소켓 열어!");
				return;

			}

			string msg = textBox3.Text;
			dataSocket.Send(Encoding.Default.GetBytes(msg));
			//MessageBox.Show("보낸 메시지 : " + msg);
			textBox3.Text = "";

		}

		private void OnReceive(IAsyncResult ar)//받기 IA 싱크 결과값을 ar로 받는다.
		{
			int received = dataSocket.EndReceive(ar); //받으면 1인가.
			string data = Encoding.Default.GetString(buffer); // 버퍼 메모리를 스트링으로 변환하여 data에 저장

			dataSocket.BeginReceive(buffer, 0, buffer.Length, 0, OnReceive, null);

			listChat.Invoke(new Action(delegate ()
			{
				listChat.Items.Add(" 관리자 :"+data);
			}));


		}

		private void log(string msg)
		{
			listChat.Invoke(new Action(delegate ()  
			{ listChat.Items.Add(msg); }));

		}

		private void txtsend_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				btnSend_Click(sender, e);
			}
		}
	}
}
