using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace Team_Projec
{

    /*
    http://rubiks-cube-solver.com/solution.php?cube=0******&x=1
    1 - 상
    2 - 좌
    3 - 앞
    4 - 우
    5 - 뒤
    6 - 하
     * */

    public partial class Main_form : Form
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth,
           int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool DeleteObject(IntPtr hObject);
        public enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }
        [DllImport("gdi32.dll")]
        static extern bool PlgBlt(IntPtr hdcDest, Point[] lpPoint, IntPtr hdcSrc,int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,int yMask);
        public Color[] col = new Color[6];
        public Bitmap[] side = new Bitmap[7];
        public int[,,] cube = new int[6,3,3];
        int[] insert = new int[3];
        int cnt = 0;
        int fcnt = 68;
        string[] fsol = new string[] { "B", "D2", "B", "U", "R2", "U2", "B", "L'", "B", "U", "B'", "U", "F", "U", "F2", "U'", "F", "U", "R'", "U'", "R", "D'", "R'", "U", "R", "D2", "F", "U", "F'", "U'", "L'", "U", "L", "D'", "U'", "L", "U", "L'", "U", "B'", "U", "B", "U", "L", "U'", "L'", "U2", "F", "U'", "B'", "U", "F'", "U'", "B", "F", "R", "F'", "L", "F", "R'", "F'", "U'", "R'", "U", "L'", "U'", "R", "U" };
        PictureBox[] color = new PictureBox[6];
        public string[] sol = new string[300];
        public Main_form()
        {
            
            InitializeComponent();
            //startparse("http://rubiks-cube-solver.com/solution.php?cube=0154112326456622241432134254566543111563654316525364332&x=1");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        cube[i, j, k] = -1;
                cube[i, 1, 1] = i;
                side[i] = new Bitmap(130, 130);       
            }
            side[6] = new Bitmap(Properties.Resources.pic);
        }
        private void display_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if(control.Enabled)
            {
                Bitmap bmp = new Bitmap(Properties.Resources.cube);
                IntPtr pTarget = e.Graphics.GetHdc();
                IntPtr pSource = CreateCompatibleDC(pTarget);
                IntPtr pOrig = SelectObject(pSource, bmp.GetHbitmap());
                fill(pTarget, insert[0]);

                BitBlt(pTarget, 105, 80, bmp.Width / 2, bmp.Height, pSource, bmp.Width / 2, 0, TernaryRasterOperations.SRCPAINT);
                BitBlt(pTarget, 105, 80, bmp.Width / 2, bmp.Height, pSource, 0, 0, TernaryRasterOperations.SRCAND);

                DeleteDC(pSource);
                e.Graphics.ReleaseHdc(pTarget);
            }

        }
        Point[] pnt(int x,int y,int type)
        {
            x += 105;
            y += 80;
            Point[] a = new Point[3];
            if (type == 1)
            {
                a[0] = new Point(x, y + 50);
                a[1] = new Point(x + 50, y);
                a[2] = new Point(x, y + 130);
            }else
            {
                a[0] = new Point(x + 50, y);
                a[1] = new Point(x + 130, y);
                a[2] = new Point(x, y + 50);
            }
            return a;
        }
        private void fill(IntPtr pt,int face)
        {
            int[] fc = new int[2];
            switch(face)
            {
                case 0:
                    fc[0] = 4;
                    fc[1] = 3;
                    break;
                case 1:
                    fc[0] = 0;
                    fc[1] = 2;
                    break;
                case 2:
                    fc[0] = 0;
                    fc[1] = 3;
                    break;
                case 3:
                    fc[0] = 0;
                    fc[1] = 4;
                    break;
                case 4:
                    fc[0] = 0;
                    fc[1] = 1;
                    break;
                case 5:
                    fc[0] = 2;
                    fc[1] = 3;
                    break;
            }
            IntPtr[] clr = new IntPtr[7];
            for(int i=0;i<7;i++)
            {
                clr[i] = CreateCompatibleDC(pt);
                IntPtr porig = SelectObject(clr[i], side[i].GetHbitmap());
            }
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    int x1 = 80 * j + 50 * (2 - i)-1 ;
                    int y1 = 50 * i;
                    int x2 = 241+ 50*j-1;
                    int y2 = 80*i + 50 * (2 - j)+1;
                    int x3 = 80 * j+105;
                    int y3 = 231 + 80 * i;
                    if(cube[fc[0], i, j]!=-1) PlgBlt(pt, pnt(x1, y1, 0), clr[cube[fc[0], i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);//상면
                    if (cube[fc[1], i, j] != -1)  PlgBlt(pt, pnt(x2, y2, 1), clr[cube[fc[1], i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);//우면
                    if (cube[face, i, j] != -1) BitBlt(pt, x3, y3, 80, 80, clr[cube[face, i, j]], 0, 0, TernaryRasterOperations.SRCCOPY);//정면
                }
            }
            int x = 80 * insert[2] + 105;
            int y = 231 + 80 * insert[1];
            BitBlt(pt, x, y, 80, 80, clr[6], 0, 0, TernaryRasterOperations.SRCCOPY);

        }
        void startparse(string site)
        {
            web.Navigate(site);
            
        }
        void resetcube()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                    for (int k = 0; k < 6; k++)
                        cube[i, j, k] = 0;
                cube[i, 2, 2] = i + 1;
            }
        }
        private void web_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            
            if (sol[0]==null)
            {
                startParsing();
            }
        }
        void startParsing()
        {
            
            mshtml.IHTMLDocument2 htmlDocument = web.Document as mshtml.IHTMLDocument2;
            mshtml.IHTMLElementCollection hec = (mshtml.IHTMLElementCollection)htmlDocument.all;
            
            cnt = 0;
            try
            {
                foreach (mshtml.IHTMLElement element in hec)
                {
                    if (element.tagName.Equals("SPAN"))
                    {
                        cnt++;
                        if (cnt > 2)
                            sol[cnt - 3] = element.outerHTML;
                    }


                }
                cnt -= 2;
                for (int i = 0; i < cnt; i++)
                {
                    sol[i] = sol[i].Substring(sol[i].LastIndexOf("<") - 2, 2);
                    if (sol[i].IndexOf(">") == 0)
                    {
                        sol[i] = sol[i].Substring(1);
                    }                      
                }
            }
            catch (WebException)
            {
                sol[0] = "Error Found";
            }
            catch (Exception)
            {

            }

            
        }
        private void clrbmp(Color clr,int x)
        {
            using (Graphics graph = Graphics.FromImage(side[x]))
            {
                graph.Clear(clr);
            }
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (colorpic.ShowDialog() == DialogResult.OK)
            {
                col[2] = colorpic.Color;
                pic_front.BackColor = col[2];
                col_front.BackColor = col[2];
                bool a = true;
                clrbmp(col[2], 2);
                for (int i = 1; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6;i++ )
                col[i] = Color.Transparent;
            control.Enabled = false;
            help.Text = "큐브의 색들을 입력해주세요";
        }

        private void pic_top_Click(object sender, EventArgs e)
        {
            if(colorpic.ShowDialog() ==DialogResult.OK)
            {
                col[0] = colorpic.Color;
                pic_top.BackColor = colorpic.Color;
                col_top.BackColor = col[0];
                clrbmp(col[0], 0);
                bool a = true;
                for (int i = 0; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }

        }

        private void pic_bot_Click(object sender, EventArgs e)
        {
            if(colorpic.ShowDialog() ==DialogResult.OK)
            {
                col[5] = colorpic.Color;
                pic_bot.BackColor = col[5];
                col_bot.BackColor = col[5];
                clrbmp(col[5], 5);
                bool a = true;
                for (int i = 0; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }
        }



        private void pic_left_Click_1(object sender, EventArgs e)
        {
            if (colorpic.ShowDialog() == DialogResult.OK)
            {
                col[1] = colorpic.Color;
                pic_left.BackColor = col[1];
                col_left.BackColor = col[1];
                clrbmp(col[1], 1);
                bool a = true;
                for (int i = 0; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }
        }
        private void pic_right_Click(object sender, EventArgs e)
        {
            if (colorpic.ShowDialog() == DialogResult.OK)
            {
                col[3] = colorpic.Color;
                pic_right.BackColor = col[3];
                col_right.BackColor = col[3];
                clrbmp(col[3], 3);
                bool a = true;
                for (int i = 1; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            if (colorpic.ShowDialog() == DialogResult.OK)
            {
                col[4] = colorpic.Color;
                pic_back.BackColor = col[4];
                col_back.BackColor = col[4];
                clrbmp(col[4], 4);
                bool a = true;
                for (int i = 1; i < 6; i++)
                    if (col[i] == Color.Transparent) a = false;
                if (a)
                {
                    if (control.Enabled == false)
                    {
                        control.Enabled = true;
                        help.Text = "윗면의 색을 입력 해주세요";
                    } 
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String path = Environment.CurrentDirectory+"\\save.dat";
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 6; i++)
                {
                    sw.WriteLine(col[i].R);
                    sw.WriteLine(col[i].G);
                    sw.WriteLine(col[i].B);
                }

                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            sw.WriteLine(cube[i, j, k]);
                sw.Close();
            }
            MessageBox.Show("저장완료");
        }
        private void control_EnabledChanged(object sender, EventArgs e)
        {
            if (control.Enabled)
            {
                display.Refresh();
                insert[0] = 0;
                insert[1] = 0;
                insert[2] = 0;
            }
        }
        void next(int type)
        {
            if(type==0)
            {
                insert[2]++;
                if (insert[2] == 3)
                {
                    insert[2] = 0;
                    insert[1]++;
                }
                if (insert[1] == 3)
                {
                    insert[1] = 0;
                    insert[0]++;
                    switch (insert[0])
                    {
                        case 0:
                            help.Text = "윗면의 색을 입력 해주세요";
                            break;
                        case 1:
                            help.Text = "좌측면의 색을 입력 해주세요";
                            break;
                        case 2:
                            help.Text = "앞면의 색을 입력 해주세요";
                            break;
                        case 3:
                            help.Text = "우측면의 색을 입력 해주세요";
                            break;
                        case 4:
                            help.Text = "뒷면의 색을 입력 해주세요";
                            break;
                        case 5:
                            help.Text = "아랫면의 색을 입력 해주세요";
                            break;
                    }
                    if(insert[0]==6)
                    {
                        insert[0] = 0;
                        insert[1] = 0;
                        insert[2] = 0;
                        help.Text = "윗면의 색을 입력 해주세요";
                    }
                }
                if (insert[1] == 1 && insert[2] == 1)
                    insert[2]++;
            }else
            {
                insert[2]--;
                if (insert[2] == -1)
                {
                    insert[2] = 2;
                    insert[1]--;
                }
                if (insert[1] == -1)
                {
                    insert[1] = 2;
                    insert[0]--;
                    switch (insert[0])
                    {
                        case 0:
                            help.Text = "윗면의 색을 입력 해주세요";
                            break;
                        case 1:
                            help.Text = "좌측면의 색을 입력 해주세요";
                            break;
                        case 2:
                            help.Text = "앞면의 색을 입력 해주세요";
                            break;
                        case 3:
                            help.Text = "우측면의 색을 입력 해주세요";
                            break;
                        case 4:
                            help.Text = "뒷면의 색을 입력 해주세요";
                            break;
                        case 5:
                            help.Text = "아랫면의 색을 입력 해주세요";
                            break;
                    }
                }
                if (insert[1] == 1 && insert[2] == 1)
                    insert[2]--;
            }
            if(insert[0]==5)
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; j < 3; j++)
                        {
                            if (cube[i, j, k] == -1)
                            {
                                a = 1;
                                break;
                            }
                        }
                    }
                }
                if (a == 0)
                    but_solve.Visible = true;
            }


        }
        private void col_top_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 0;
            next(0);
            display.Refresh();
        }
        private void col_left_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 1;
            next(0);
            display.Refresh();
        }

        private void col_front_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 2;
            next(0);
            display.Refresh();
        }

        private void col_right_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 3;
            next(0);
            display.Refresh();
        }

        private void col_back_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 4;
            next(0);
            display.Refresh();
        }
        private void col_bot_Click(object sender, EventArgs e)
        {
            cube[insert[0], insert[1], insert[2]] = 5;
            next(0);
            display.Refresh();
        }

        private void but_back_Click(object sender, EventArgs e)
        {
            next(1);
            display.Refresh();
        }

        private void but_next_Click(object sender, EventArgs e)
        {
            next(0);
            display.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Solve_form frm = new Solve_form(fsol, side, cube, fcnt);
            frm.Show();
        }

        private void but_solve_Click(object sender, EventArgs e)
        {
            string url = "http://rubiks-cube-solver.com/solution.php?cube=0";
            string add = "";
            int[] num = new int[] { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        add = add + Convert.ToString(cube[i, j, k] + 1);
                        num[cube[i, j, k]]++;
                    }
            bool tf = true;
            for (int i = 0; i < 6; i++)
                if (num[i] != 9)
                    tf = false;
            if(tf)
            {
                url = url + add + "&x=1";
                startparse(url);
                if (sol[0] == "Error Found")
                    MessageBox.Show("큐브 입력에 잘못된 부분이 있습니다.\n다시 한번 확인 해주세요.", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if(sol[0] == null)
                    {
                        MessageBox.Show("다시 한번 확인 해주세요.", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string lt = sol[0].Substring(0, 1);
                        if (lt == "L" || lt == "R" || lt == "F" || lt == "B" || lt == "D" || lt == "U")
                        {
                            try
                            {
                                Solve_form frm = new Solve_form(sol, side, cube,cnt);
                                frm.Owner = this;
                                frm.Show();
                            }catch(Exception)
                            {

                            }

                        }
                        else
                        {
                            MessageBox.Show("큐브 입력에 잘못된 부분이 있습니다.\n다시 한번 확인 해주세요.", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("큐브 입력에 잘못된 부분이 있습니다.\n다시 한번 확인 해주세요.", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader(Environment.CurrentDirectory+"\\save.dat"))
            {
                for(int i=0; i<6;i++)
                {
                    int r, g, b;
                    r = Convert.ToInt32(sr.ReadLine());
                    g = Convert.ToInt32(sr.ReadLine());
                    b = Convert.ToInt32(sr.ReadLine());
                    col[i] = Color.FromArgb(r,g,b);
                    clrbmp(col[i], i);
                }
                        
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            cube[i, j, k] = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
                int a = 0;
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; j < 3; j++)
                            if (cube[i, j, k] == -1)
                            {
                                a = 1;
                                break;
                            }
                if (a == 0)
                    but_solve.Visible = true;
            pic_top.BackColor = col[0];
            col_top.BackColor = col[0];
            pic_left.BackColor = col[1];
            col_left.BackColor = col[1];
            pic_front.BackColor = col[2];
            col_front.BackColor = col[2];
            pic_right.BackColor = col[3];
            col_right.BackColor = col[3];
            pic_back.BackColor = col[4];
            col_back.BackColor = col[4];
            pic_bot.BackColor = col[5];
            col_bot.BackColor = col[5];
            control.Enabled = true;
        }
    }


}
