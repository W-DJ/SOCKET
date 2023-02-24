using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace server
{
	public partial class login : Form
	{

		public struct cubridConn // cubrid 연결
		{
			public XmlDocument xmlConfig; // xml 설정 가져오기
			public string dbConnectString;
			public bool dbOpenState;
			public OdbcConnection dbConn;//큐브리드 연결.

		} 

		public cubridConn con = new cubridConn();
		public login()
		{
			InitializeComponent();
			Thread_CubridConnect();
		}

		private void login_Load(object sender, EventArgs e)
		{
			try
			{
				//xml 주소 
				con.xmlConfig = new XmlDocument();
				con.xmlConfig.Load(Application.StartupPath + "/login.xml"); // xml파일을 로드(시작점은 login.xml 파일로 부터)

				// database
				XmlNode dbConnectString = con.xmlConfig.SelectSingleNode("/DB_Connect");

				//xml노드 dbcon 은 cubrid. xml파일로드한 것. 
				con.dbConnectString = dbConnectString.InnerText;
			}
			catch (Exception)
			{

				MessageBox.Show("실행 파일 에러. 관리자에게 문의하세요.");
			}
		}
		
		private void Thread_CubridConnect()
		{
			System.Threading.Timer thTimer_DB = new System.Threading.Timer(DB_Connect);
			thTimer_DB.Change(0, 2000); //OK
		}

		private void DB_Connect(object sender)
		{
			try
			{
				if (!con.dbOpenState)
				{
					con.dbConn = new OdbcConnection(con.dbConnectString);
					con.dbConn.Open();
					con.dbOpenState = true;

				}
			}
			catch (OdbcException)
			{
				con.dbConn.Close();
				con.dbOpenState = false;
			}
			catch (Exception)
			{
				con.dbConn.Close();
				con.dbOpenState = false;
			}
		}

		private void button1_new_Click(object sender, EventArgs e)
		{
			string id = textBox1.Text;
			// 문자열 id 변수는 txtbox_id 의 텍스트값
			string pw = textBox2.Text;
			// 문자열 pw 변수는 txtbox_pw의 텍스트값

			OdbcCommand cmd = new OdbcCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "INSERT INTO dbcon (id, pw) VALUES id = '" + id + "',pw = '" + pw + "';";

			OdbcConnection conn = new OdbcConnection(con.dbConnectString);

			DataSet dataSet = new DataSet();

			try
			{
				if (con.dbOpenState)
				{
					cmd.Connection = con.dbConn;
					OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
					if (dataSet.Tables[0].Rows.Count!=0)
					{
						MessageBox.Show("오오오");
					}
					else
					{
						MessageBox.Show("가입되었습니다.");
					}

				}
			}
			catch (Exception)
			{
				conn.Close();
				throw;
			}
		}

	}
}
