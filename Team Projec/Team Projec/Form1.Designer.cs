namespace Team_Projec
{
    partial class Main_form
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.colorpic = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_back = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pic_front = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pic_right = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pic_left = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pic_bot = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_top = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.control = new System.Windows.Forms.Panel();
            this.but_next = new System.Windows.Forms.Label();
            this.but_back = new System.Windows.Forms.Label();
            this.col_right = new System.Windows.Forms.PictureBox();
            this.col_left = new System.Windows.Forms.PictureBox();
            this.col_front = new System.Windows.Forms.PictureBox();
            this.col_bot = new System.Windows.Forms.PictureBox();
            this.col_top = new System.Windows.Forms.PictureBox();
            this.col_back = new System.Windows.Forms.PictureBox();
            this.web = new AxSHDocVw.AxWebBrowser();
            this.but_solve = new System.Windows.Forms.PictureBox();
            this.display = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.help = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_top)).BeginInit();
            this.control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.col_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_bot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.web)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_solve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pic_back);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pic_front);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pic_right);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pic_left);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pic_bot);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pic_top);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(613, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 180);
            this.panel1.TabIndex = 1;
            // 
            // pic_back
            // 
            this.pic_back.BackColor = System.Drawing.SystemColors.Control;
            this.pic_back.Location = new System.Drawing.Point(143, 122);
            this.pic_back.Name = "pic_back";
            this.pic_back.Size = new System.Drawing.Size(89, 50);
            this.pic_back.TabIndex = 17;
            this.pic_back.TabStop = false;
            this.pic_back.Click += new System.EventHandler(this.pic_back_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "뒤";
            // 
            // pic_front
            // 
            this.pic_front.BackColor = System.Drawing.SystemColors.Control;
            this.pic_front.Location = new System.Drawing.Point(34, 122);
            this.pic_front.Name = "pic_front";
            this.pic_front.Size = new System.Drawing.Size(85, 50);
            this.pic_front.TabIndex = 15;
            this.pic_front.TabStop = false;
            this.pic_front.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "앞";
            // 
            // pic_right
            // 
            this.pic_right.BackColor = System.Drawing.SystemColors.Control;
            this.pic_right.Location = new System.Drawing.Point(142, 66);
            this.pic_right.Name = "pic_right";
            this.pic_right.Size = new System.Drawing.Size(89, 50);
            this.pic_right.TabIndex = 13;
            this.pic_right.TabStop = false;
            this.pic_right.Click += new System.EventHandler(this.pic_right_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "우";
            // 
            // pic_left
            // 
            this.pic_left.BackColor = System.Drawing.SystemColors.Control;
            this.pic_left.Location = new System.Drawing.Point(33, 66);
            this.pic_left.Name = "pic_left";
            this.pic_left.Size = new System.Drawing.Size(85, 50);
            this.pic_left.TabIndex = 11;
            this.pic_left.TabStop = false;
            this.pic_left.Click += new System.EventHandler(this.pic_left_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "좌";
            // 
            // pic_bot
            // 
            this.pic_bot.BackColor = System.Drawing.SystemColors.Control;
            this.pic_bot.Location = new System.Drawing.Point(142, 10);
            this.pic_bot.Name = "pic_bot";
            this.pic_bot.Size = new System.Drawing.Size(89, 50);
            this.pic_bot.TabIndex = 9;
            this.pic_bot.TabStop = false;
            this.pic_bot.Click += new System.EventHandler(this.pic_bot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "하";
            // 
            // pic_top
            // 
            this.pic_top.BackColor = System.Drawing.SystemColors.Control;
            this.pic_top.Location = new System.Drawing.Point(33, 10);
            this.pic_top.Name = "pic_top";
            this.pic_top.Size = new System.Drawing.Size(85, 50);
            this.pic_top.TabIndex = 7;
            this.pic_top.TabStop = false;
            this.pic_top.Click += new System.EventHandler(this.pic_top_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "상";
            // 
            // control
            // 
            this.control.BackColor = System.Drawing.SystemColors.ControlLight;
            this.control.Controls.Add(this.but_next);
            this.control.Controls.Add(this.but_back);
            this.control.Controls.Add(this.col_right);
            this.control.Controls.Add(this.col_left);
            this.control.Controls.Add(this.col_front);
            this.control.Controls.Add(this.col_bot);
            this.control.Controls.Add(this.col_top);
            this.control.Controls.Add(this.col_back);
            this.control.Location = new System.Drawing.Point(613, 380);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(240, 175);
            this.control.TabIndex = 2;
            this.control.EnabledChanged += new System.EventHandler(this.control_EnabledChanged);
            // 
            // but_next
            // 
            this.but_next.BackColor = System.Drawing.SystemColors.Control;
            this.but_next.Font = new System.Drawing.Font("굴림", 30F);
            this.but_next.Location = new System.Drawing.Point(180, 7);
            this.but_next.Name = "but_next";
            this.but_next.Size = new System.Drawing.Size(52, 162);
            this.but_next.TabIndex = 7;
            this.but_next.Text = "▶";
            this.but_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.but_next.Click += new System.EventHandler(this.but_next_Click);
            // 
            // but_back
            // 
            this.but_back.BackColor = System.Drawing.SystemColors.Control;
            this.but_back.Font = new System.Drawing.Font("굴림", 30F);
            this.but_back.Location = new System.Drawing.Point(10, 7);
            this.but_back.Name = "but_back";
            this.but_back.Size = new System.Drawing.Size(52, 162);
            this.but_back.TabIndex = 6;
            this.but_back.Text = "◀";
            this.but_back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.but_back.Click += new System.EventHandler(this.but_back_Click);
            // 
            // col_right
            // 
            this.col_right.BackColor = System.Drawing.SystemColors.Control;
            this.col_right.Location = new System.Drawing.Point(124, 63);
            this.col_right.Name = "col_right";
            this.col_right.Size = new System.Drawing.Size(50, 50);
            this.col_right.TabIndex = 5;
            this.col_right.TabStop = false;
            this.col_right.Click += new System.EventHandler(this.col_right_Click);
            // 
            // col_left
            // 
            this.col_left.BackColor = System.Drawing.SystemColors.Control;
            this.col_left.Location = new System.Drawing.Point(68, 63);
            this.col_left.Name = "col_left";
            this.col_left.Size = new System.Drawing.Size(50, 50);
            this.col_left.TabIndex = 4;
            this.col_left.TabStop = false;
            this.col_left.Click += new System.EventHandler(this.col_left_Click);
            // 
            // col_front
            // 
            this.col_front.BackColor = System.Drawing.SystemColors.Control;
            this.col_front.Location = new System.Drawing.Point(67, 119);
            this.col_front.Name = "col_front";
            this.col_front.Size = new System.Drawing.Size(50, 50);
            this.col_front.TabIndex = 3;
            this.col_front.TabStop = false;
            this.col_front.Click += new System.EventHandler(this.col_front_Click);
            // 
            // col_bot
            // 
            this.col_bot.BackColor = System.Drawing.SystemColors.Control;
            this.col_bot.Location = new System.Drawing.Point(124, 7);
            this.col_bot.Name = "col_bot";
            this.col_bot.Size = new System.Drawing.Size(50, 50);
            this.col_bot.TabIndex = 2;
            this.col_bot.TabStop = false;
            this.col_bot.Click += new System.EventHandler(this.col_bot_Click);
            // 
            // col_top
            // 
            this.col_top.BackColor = System.Drawing.SystemColors.Control;
            this.col_top.Location = new System.Drawing.Point(68, 7);
            this.col_top.Name = "col_top";
            this.col_top.Size = new System.Drawing.Size(50, 50);
            this.col_top.TabIndex = 1;
            this.col_top.TabStop = false;
            this.col_top.Click += new System.EventHandler(this.col_top_Click);
            // 
            // col_back
            // 
            this.col_back.BackColor = System.Drawing.SystemColors.Control;
            this.col_back.Location = new System.Drawing.Point(124, 119);
            this.col_back.Name = "col_back";
            this.col_back.Size = new System.Drawing.Size(50, 50);
            this.col_back.TabIndex = 0;
            this.col_back.TabStop = false;
            this.col_back.Click += new System.EventHandler(this.col_back_Click);
            // 
            // web
            // 
            this.web.Enabled = true;
            this.web.Location = new System.Drawing.Point(286, 26);
            this.web.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("web.OcxState")));
            this.web.Size = new System.Drawing.Size(300, 390);
            this.web.TabIndex = 10;
            this.web.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.web_DocumentComplete);
            // 
            // but_solve
            // 
            this.but_solve.Image = global::Team_Projec.Properties.Resources.solve;
            this.but_solve.Location = new System.Drawing.Point(404, 453);
            this.but_solve.Name = "but_solve";
            this.but_solve.Size = new System.Drawing.Size(202, 102);
            this.but_solve.TabIndex = 19;
            this.but_solve.TabStop = false;
            this.but_solve.Visible = false;
            this.but_solve.Click += new System.EventHandler(this.but_solve_Click);
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.White;
            this.display.Image = global::Team_Projec.Properties.Resources.background;
            this.display.Location = new System.Drawing.Point(6, 5);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(600, 550);
            this.display.TabIndex = 8;
            this.display.TabStop = false;
            this.display.WaitOnLoad = true;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Team_Projec.Properties.Resources.TItle;
            this.pictureBox1.Location = new System.Drawing.Point(612, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 106);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Team_Projec.Properties.Resources.load;
            this.pictureBox3.Location = new System.Drawing.Point(733, 116);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 30);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Team_Projec.Properties.Resources.save;
            this.pictureBox2.Location = new System.Drawing.Point(612, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 30);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Black;
            this.help.Font = new System.Drawing.Font("굴림", 13F);
            this.help.ForeColor = System.Drawing.Color.Yellow;
            this.help.Image = global::Team_Projec.Properties.Resources.HELP;
            this.help.Location = new System.Drawing.Point(613, 150);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(240, 40);
            this.help.TabIndex = 4;
            this.help.Text = "안녕하세요";
            this.help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 560);
            this.Controls.Add(this.but_solve);
            this.Controls.Add(this.display);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.help);
            this.Controls.Add(this.control);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.web);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main_form";
            this.Text = "Solve the Cube";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_bot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_top)).EndInit();
            this.control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.col_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_bot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.web)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_solve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorpic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel control;
        private System.Windows.Forms.PictureBox col_right;
        private System.Windows.Forms.PictureBox col_left;
        private System.Windows.Forms.PictureBox col_front;
        private System.Windows.Forms.PictureBox col_bot;
        private System.Windows.Forms.PictureBox col_top;
        private System.Windows.Forms.PictureBox col_back;
        private System.Windows.Forms.PictureBox pic_front;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pic_right;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic_left;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_bot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_back;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label but_next;
        private System.Windows.Forms.Label but_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox display;
        private AxSHDocVw.AxWebBrowser web;
        private System.Windows.Forms.PictureBox but_solve;
    }
}

