namespace server
{
	partial class login
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1_new = new System.Windows.Forms.Button();
			this.button1_login = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(287, 233);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 17;
			this.label2.Text = "비밀번호";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(287, 182);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 16;
			this.label1.Text = "아이디";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(289, 248);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 21);
			this.textBox2.TabIndex = 15;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(289, 197);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 21);
			this.textBox1.TabIndex = 14;
			// 
			// button1_new
			// 
			this.button1_new.Location = new System.Drawing.Point(404, 182);
			this.button1_new.Margin = new System.Windows.Forms.Padding(0);
			this.button1_new.Name = "button1_new";
			this.button1_new.Size = new System.Drawing.Size(110, 37);
			this.button1_new.TabIndex = 13;
			this.button1_new.Text = "가입하기";
			this.button1_new.UseVisualStyleBackColor = true;
			this.button1_new.Click += new System.EventHandler(this.button1_new_Click);
			// 
			// button1_login
			// 
			this.button1_login.Location = new System.Drawing.Point(404, 233);
			this.button1_login.Margin = new System.Windows.Forms.Padding(0);
			this.button1_login.Name = "button1_login";
			this.button1_login.Size = new System.Drawing.Size(110, 37);
			this.button1_login.TabIndex = 18;
			this.button1_login.Text = "로그인";
			this.button1_login.UseVisualStyleBackColor = true;
			// 
			// login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1_login);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1_new);
			this.Name = "login";
			this.Text = "login";
			this.Load += new System.EventHandler(this.login_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1_new;
		private System.Windows.Forms.Button button1_login;
	}
}