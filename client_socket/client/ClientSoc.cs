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
		public Client()
		{
			InitializeComponent();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Thread thread1 = new Thread(start);
			thread1.IsBackground = true;
			thread1.Start();
		}

		static byte[] receiveBytes = new byte[1024];
		static byte[] sendBytes = new byte[1024];
		private void start()
		{
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.10.10.60"), 5000);
			sock.Connect(ep);

			sock.Send(Encoding.UTF8.GetBytes("fasdfadsf"));

			sock.Send(sendBytes);

			
			
			sock.Receive(receiveBytes);

			Console.WriteLine(Encoding.Default.GetString(receiveBytes));

			
			

			
		/*	try
			{
				//종료되면 자동 클라이언트 종료
				//무한 루프
				while (true)
				{
					var binary = new byte[1024];

					sock.Receive(binary);

					var data = Encoding.ASCII.GetString(binary).Trim(); //서버로 부터 받은 내용을 str로 변환

					MessageBox.Show(data);

					if (String.IsNullOrEmpty(data))
					{
						continue;
					} 
					writeRichTextBox(data); //출력

					
				}
			}
			catch (Exception)
			{

				//접속이 끊기면 예외발생

			}
			*/
			
			

			
			
			
			
			
		


		}

	

		private void writeRichTextBox(string data) //richTextBox1에 쓰기 함수


		{
			richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(data + "\r\n"); });
			//데이터를 수신창에 표시, 반드시 Invoke를 사용하여 충돌을 피함
			richTextBox1.Invoke((MethodInvoker)(delegate { richTextBox1.ScrollToCaret(); }));
		}
		private void button2_Click(object sender, EventArgs e)
		{
			string sendData = textBox3.Text; //textBox3의 텍스트를 sendData1에 담는다.
			textBox3.Clear();
			


		}
		/*StreamReader streamReader;
		StreamWriter streamWriter;
*/
		/*private void button1_Click(object sender, EventArgs e)
		{
			Thread thread1 = new Thread(Connect);
			thread1.IsBackground= true;
			thread1.Start();

		}*/

		/*private void Connect()
		{
			TcpClient tcpClient1 = new TcpClient(); //Tcp 통신 객체 생성

			IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text)); //입력 받은 IP, Port 번호를 ipEnd에 저장
			
			tcpClient1.Connect(ipEnd); // ipEnd에 저장된 IP,port 번호로 연결

			
			writeRichTextBox("서버에 연결됨"); // richTextBox에 나타냄

			streamReader = new StreamReader(tcpClient1.GetStream()); //읽기 스트림 연결
			streamWriter = new StreamWriter(tcpClient1.GetStream());
			streamWriter.AutoFlush = true;  //쓰기 버퍼 자동으로 뭔가 처리. 사용시 true 버퍼가 가득차면 내용을 전송하고 버퍼를 비움 false: 버퍼가 가득차면 작업중지, 에러페이지 출력

			while (tcpClient1.Connected)
			{
				string receiveData1 = streamReader.ReadLine(); // receiveData1라는 변수에 수신 데이터를 읽어서 저장.
				receiveData1= receiveData1.Trim(); 
				writeRichTextBox(receiveData1+ "\r\n"); //데이터를 수신창에 나타냄

			}
		}

		private void writeRichTextBox(string data) //richTextBox1에 쓰기 함수
			

		{
			richTextBox1.Invoke((MethodInvoker) delegate { richTextBox1.AppendText(data + "\r\n"); });
			//데이터를 수신창에 표시, 반드시 Invoke를 사용하여 충돌을 피함
			richTextBox1.Invoke((MethodInvoker)(delegate { richTextBox1.ScrollToCaret(); }) );
		} 
		private void button2_Click(object sender, EventArgs e)
		{
			string sendData1 = textBox3.Text; //textBox3의 텍스트를 sendData1에 담는다.
			textBox3.Clear();
			writeRichTextBox(sendData1+ "\r\n"); //보내는 내용도 텍스트 박스에 나오게 한다.!!
			streamWriter.WriteLine(sendData1); // streamWriter로 sendData1를 전송한다.
			


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
