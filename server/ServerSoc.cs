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
			thread1.IsBackground = true;

			thread1.Start();

		}


			byte[] buffer = new byte[8192]; //버퍼 크기

		private void start()
		{

			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.10.10.60"), 5000);

			sock.Bind(ep); //소켓을 주소로 묶음

			sock.Listen(1000); // 소켓으로 받아요



			Socket ClientSock = sock.Accept(); //클라이언트 소켓 접근

			ClientSock.Send(Encoding.ASCII.GetBytes("안녕하세요"));
			/*while (true) {
				int receiveData1 = 0;
				receiveData1 = ClientSock.Receive(buffer);

			}
*/








			int n = ClientSock.Receive(buffer);

			string data = Encoding.UTF8.GetString(buffer, 0, n);


			ClientSock.Send(buffer, 0, n, SocketFlags.None); //echo
			
			//ClientSock.Close();
			//sock.Close();
		}

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

