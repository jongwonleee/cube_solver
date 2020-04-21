namespace Team_Projec
{
    partial class Solve_form
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.speedbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.but_next = new System.Windows.Forms.Label();
            this.but_back = new System.Windows.Forms.Label();
            this.but_auto = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.but_exit = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.display = new System.Windows.Forms.PictureBox();
            this.count = new System.Windows.Forms.Label();
            this.autoplaying = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedbar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.speedbar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(610, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 57);
            this.panel1.TabIndex = 6;
            // 
            // speedbar
            // 
            this.speedbar.Location = new System.Drawing.Point(9, 26);
            this.speedbar.Maximum = 30;
            this.speedbar.Minimum = 10;
            this.speedbar.Name = "speedbar";
            this.speedbar.Size = new System.Drawing.Size(223, 45);
            this.speedbar.SmallChange = 3;
            this.speedbar.TabIndex = 1;
            this.speedbar.TickFrequency = 3;
            this.speedbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedbar.Value = 10;
            this.speedbar.Scroll += new System.EventHandler(this.speedbar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "애니메이션 속도";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.but_next);
            this.panel2.Controls.Add(this.but_back);
            this.panel2.Controls.Add(this.but_auto);
            this.panel2.Location = new System.Drawing.Point(609, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 143);
            this.panel2.TabIndex = 7;
            // 
            // but_next
            // 
            this.but_next.BackColor = System.Drawing.SystemColors.Control;
            this.but_next.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.but_next.Location = new System.Drawing.Point(166, 6);
            this.but_next.Name = "but_next";
            this.but_next.Size = new System.Drawing.Size(70, 132);
            this.but_next.TabIndex = 2;
            this.but_next.Text = "▶";
            this.but_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.but_next.Click += new System.EventHandler(this.but_next_Click);
            // 
            // but_back
            // 
            this.but_back.BackColor = System.Drawing.SystemColors.Control;
            this.but_back.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.but_back.Location = new System.Drawing.Point(5, 6);
            this.but_back.Name = "but_back";
            this.but_back.Size = new System.Drawing.Size(70, 132);
            this.but_back.TabIndex = 1;
            this.but_back.Text = "◀";
            this.but_back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.but_back.Click += new System.EventHandler(this.but_back_Click);
            // 
            // but_auto
            // 
            this.but_auto.BackColor = System.Drawing.SystemColors.Control;
            this.but_auto.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.but_auto.Location = new System.Drawing.Point(80, 6);
            this.but_auto.Name = "but_auto";
            this.but_auto.Size = new System.Drawing.Size(80, 132);
            this.but_auto.TabIndex = 0;
            this.but_auto.Text = "자동";
            this.but_auto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.but_auto.Click += new System.EventHandler(this.but_auto_Click);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("굴림", 13F);
            this.status.ForeColor = System.Drawing.Color.Yellow;
            this.status.Image = global::Team_Projec.Properties.Resources.status;
            this.status.Location = new System.Drawing.Point(609, 232);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(241, 223);
            this.status.TabIndex = 8;
            this.status.Text = "안녕하세요";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_exit
            // 
            this.but_exit.Image = global::Team_Projec.Properties.Resources.back;
            this.but_exit.Location = new System.Drawing.Point(610, 116);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(240, 47);
            this.but_exit.TabIndex = 5;
            this.but_exit.TabStop = false;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Team_Projec.Properties.Resources.TItle;
            this.pictureBox2.Location = new System.Drawing.Point(609, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(241, 106);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // display
            // 
            this.display.Image = global::Team_Projec.Properties.Resources.display;
            this.display.Location = new System.Drawing.Point(3, 3);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(600, 600);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.BackColor = System.Drawing.Color.Transparent;
            this.count.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.count.Image = global::Team_Projec.Properties.Resources.display;
            this.count.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.count.Location = new System.Drawing.Point(1, 1);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(162, 48);
            this.count.TabIndex = 9;
            this.count.Text = "1 / 83";
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // autoplaying
            // 
            this.autoplaying.Interval = 500;
            this.autoplaying.Tick += new System.EventHandler(this.autoplaying_Tick);
            // 
            // Solve_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 606);
            this.Controls.Add(this.count);
            this.Controls.Add(this.status);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.display);
            this.Name = "Solve_form";
            this.Text = "Solve the Cube";
            this.Load += new System.EventHandler(this.Solve_form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedbar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox but_exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar speedbar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label but_next;
        private System.Windows.Forms.Label but_back;
        private System.Windows.Forms.Label but_auto;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Timer autoplaying;
    }
}