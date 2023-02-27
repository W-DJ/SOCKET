namespace server
{
	partial class Server
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOpen = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.listChat = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(157, 30);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(106, 39);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "연결하기";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(83, 223);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(243, 21);
			this.textBox3.TabIndex = 6;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(354, 223);
			this.btnSend.Margin = new System.Windows.Forms.Padding(0);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(106, 21);
			this.btnSend.TabIndex = 7;
			this.btnSend.Text = "보내기";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(288, 30);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(106, 39);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "연결끊기";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// listChat
			// 
			this.listChat.FormattingEnabled = true;
			this.listChat.ItemHeight = 12;
			this.listChat.Location = new System.Drawing.Point(83, 75);
			this.listChat.Name = "listChat";
			this.listChat.Size = new System.Drawing.Size(377, 136);
			this.listChat.TabIndex = 9;
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listChat);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.btnOpen);
			this.Name = "Server";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.Server_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ListBox listChat;
	}
}

