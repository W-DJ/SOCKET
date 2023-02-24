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

namespace server
{
	public partial class Server : Form
	{


		public Server()
		{
			InitializeComponent();
		}


		/*StreamWriter streamWriter1; // 데이터를 쓰기 위한 스트림 롸이터
		StreamReader streamReader1; // 데이터를 읽기 위한 스트림 리더 */


		private void Form1_Load(object sender, EventArgs e)
		{
			


		}
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		private void button1_Click(object sender, EventArgs e)
		{
			Thread thread1 = new Thread(start);
			thread1.IsBackground= true;	
			thread1.Start();

		}

		private void start()
		{

			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.10.10.60"), 5000);
			
			sock.Bind(ep);

			sock.Listen(1000);

			writeRichTextbox("서버 준비... 클라이언트 기다리는 중");

			Socket ClientSock = sock.Accept(); //클라이언트 소켓 접근
			ClientSock.Send(Encoding.ASCII.GetBytes("Welcome server!!"));

			var sb = new StringBuilder(); //메시지 버퍼

			byte[] buffer = new byte[8192]; //버퍼 크기

			while (true)
			{
				ClientSock.Receive(buffer); //클라이언트로 부터 버퍼를 받는다

				ClientSock.BeginSend(buffer, 0, 20, SocketFlags.None,new AsyncCallback(sendStr), ClientSock);

				ClientSock.BeginReceive(buffer,0,20,SocketFlags.None, new AsyncCallback(receiveStr), ClientSock);

				var data = Encoding.ASCII.GetString(buffer); //클라이언트로 받은 메시지를 string으로 변환

				

				sb.Append(data.Trim('\0')); //공백 제거

				if (sb.Length > 2) {
				data = sb.ToString();
					if (String.IsNullOrEmpty(data))
					{
						continue;
					}

					if (data == "Exit")
					{
						break;
					}

					writeRichTextbox("회원 : " + data);
					sb.Clear();

					var sendMsg = Encoding.ASCII.GetBytes("Echo : " + "\r\n");

					ClientSock.Send(sendMsg);

					

				}

			}

			


		}

		static void sendStr(IAsyncResult ar)
		{
			Socket ClientSock = (Socket)ar.AsyncState; //연결된 소켓 파라미터를 가져옴
			int strLength = ClientSock.EndSend(ar); // 반환값으로 전송한 데이터의 크기를 되돌려 받음.
		}

		static byte[] receiveBytes = new byte[1024];
		static void receiveStr(IAsyncResult ar)
		{
			Socket ClientSock = (Socket)ar.AsyncState;
			int receiveStr = ClientSock.EndReceive(ar);
			
			MessageBox.Show(Encoding.ASCII.GetString(receiveBytes));


		}
		private void writeRichTextbox(string str) // rechTextbox1에 쓰기 함수
		{
			richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(str + "\r\n"); }); //데이터를 수신창에 표시ㅡ 반드시 
																									 //invoke를 사용하여 충돌을 피함.
			richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.ScrollToCaret(); }); //스크롤을 제일 밑으로.


		}

		private void button2_Click(object sender, EventArgs e)
		{
			button2_Click(sender, e, sock);
		}

		private void button2_Click(object sender, EventArgs e, Socket sock)
		{
			string sendData1 = textBox3.Text; // textBox3의 내용을 sendData1에 담는다.
			textBox3.Clear(); // 다시 타자를 칠 수 있도록 빈칸으로 만든다.
			writeRichTextbox(sendData1 + "\r\n");   // 보내는 내용도 텍스트박스에 나오게 한다.
			

		}
		/*
private void button1_Click(object sender, EventArgs e) //버튼을 클릭하면
{
Thread thread1 = new Thread(connect); // Thread 객체 생성을 하고 Form과는 별도로 쓰레드에서 connect 함수 실행
thread1.IsBackground = true;        //Form이 종료되면 thread1도 종료
thread1.Start();                    // thread1 시작.
}

private void connect() //thread1에 연결된 함수. 메인 폼과 별도로 실행
{
TcpListener tcpListener1 = new TcpListener(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text)); //서버 객체 생성 및 
																								 //IP주소와 port번호를 넣어줌
tcpListener1.Start();  //tcpListener 서버 시작

writeRichTextbox("서버 준비...클라이언트 기다리는 중");

TcpClient tcpClient1 = tcpListener1.AcceptTcpClient(); //클라이언트 접속 확인

writeRichTextbox("클라이언트 연결됨");

streamReader1 = new StreamReader(tcpClient1.GetStream()); //읽기 스트림 연결
streamWriter1 = new StreamWriter(tcpClient1.GetStream()); // 쓰기 스트림 연결
streamWriter1.AutoFlush = true;  // 쓰기 버퍼 자동으로 버퍼가 가득차면 전송 후 비움.

while (tcpClient1.Connected) //클라이언트가 연결된 동안에
{
string receiveData1 = streamReader1.ReadLine(); //수신 데이터를 읽어서 receiveData1 변수에 저장.


writeRichTextbox(receiveData1 + "\r\n"); //데이터를 수신창에 쓰기.

}

}
private void writeRichTextbox(string str) // rechTextbox1에 쓰기 함수
{
richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(str + "\r\n"); }); //데이터를 수신창에 표시ㅡ 반드시 
																					//invoke를 사용하여 충돌을 피함.
richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.ScrollToCaret(); }); //스크롤을 제일 밑으로.


}

private void button2_Click(object sender, EventArgs e) //보내기 버튼을 클릭하면
{
string sendData1 = textBox3.Text; // textBox3의 내용을 sendData1에 담는다.
textBox3.Clear(); // 다시 타자를 칠 수 있도록 빈칸으로 만든다.
writeRichTextbox(sendData1 + "\r\n");   // 보내는 내용도 텍스트박스에 나오게 한다.
streamWriter1.WriteLine(sendData1); //streamWriter1을 통해 데이터를 전송하여 나타낸다.

}

private void Entered(object sender, KeyEventArgs e)
{
if (e.KeyCode == Keys.Enter)
{
button2_Click(this, EventArgs.Empty);
}
}*/
	}
}
