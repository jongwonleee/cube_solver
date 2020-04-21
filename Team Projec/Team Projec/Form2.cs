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
using System.Runtime.InteropServices;

namespace Team_Projec
{
    public partial class Solve_form : Form
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
        static extern bool PlgBlt(IntPtr hdcDest, Point[] lpPoint, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask, int yMask);
        Bitmap[] side = new Bitmap[7];
        Bitmap[,] bone = new Bitmap[3, 4];
        int[, ,] cube = new int[6, 3, 3];
        string[] sol;
        bool auto = false;
        int cnt,speed;
        int cnt2=1;
        public Solve_form(string[] _sol, Bitmap[] _side, int[,,] _cube, int _cnt)
        {
            InitializeComponent();
            speedbar.Value = 20;
            side = _side;
            cube = _cube;
            sol = new string[_cnt];
            for (int i = 0; i < _cnt; i++)
                sol[i] = _sol[i];
                speed = 2;
            int len = _sol.Length;
            using (Graphics graph = Graphics.FromImage(side[6]))
            {
                graph.Clear(Color.White);
            }
            cnt = 0;
            bone[0, 0] = Properties.Resources.l0;
            bone[0, 1] = Properties.Resources.l1;
            bone[0, 2] = Properties.Resources.l2;
            bone[0, 3] = Properties.Resources.l3;
            bone[1, 0] = Properties.Resources.r0;
            bone[1, 1] = Properties.Resources.r1;
            bone[1, 2] = Properties.Resources.r2;
            bone[1, 3] = Properties.Resources.r3;
            bone[2, 0] = Properties.Resources.c0;
            bone[2, 1] = Properties.Resources.c1;
            bone[2, 2] = Properties.Resources.c2;
            bone[2, 3] = Properties.Resources.c3;
            count.Text = (cnt + 1).ToString() + " / " + _cnt.ToString();
        }  

        private void but_auto_Click(object sender, EventArgs e)
        {
            if(auto)
            {
                auto = false;
                but_back.Enabled = true;
                but_next.Enabled = true;
                but_auto.BackColor = SystemColors.Control;
            }
            else
            {
                auto = true;
                autoplaying.Enabled = auto;
                but_back.Enabled = false;
                but_next.Enabled = false ;
                but_auto.BackColor = SystemColors.ControlDark;
            }
            
        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void count_Click(object sender, EventArgs e)
        {

        }

        private void Solve_form_Load(object sender, EventArgs e)
        {

        }


        private void speedbar_Scroll(object sender, EventArgs e)
        {
            speed = speedbar.Value;
            autoplaying.Interval= (40-speed) * 50;
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            IntPtr pTarget = e.Graphics.GetHdc();

            switch (sol[cnt])
            {
                case "L":
                    status.Text = "좌측면 끝줄을 아래쪽으로 한번 돌려주세요";
                    ani(pTarget,0);           
                    break;
                case "L'":
                    status.Text = "좌측면 끝줄을 위쪽으로 한번 돌려주세요";
                    ani(pTarget, 1);   
                    break;
                case "L2":
                    status.Text = "좌측면 끝줄을 아래쪽으로 두번 돌려주세요";
                    ani( pTarget, 0);
                    break;
                case "R":
                    status.Text = "좌측면 앞줄을 위쪽으로 한번 돌려주세요";
                    ani( pTarget, 2);
                    break;
                case "R'":
                    status.Text = "좌측면 앞줄을 아래쪽으로 한번 돌려주세요";
                    ani( pTarget, 3);
                    break;
                case "R2":
                    status.Text = "좌측면 앞줄을 위쪽으로 두번 돌려주세요";
                    ani( pTarget, 2);
                    break;
                case "F":
                    status.Text = "우측면 앞줄을 아래쪽으로 한번 돌려주세요";
                    ani( pTarget, 4);
                    break;
                case "F'":
                    status.Text = "우측면 앞줄을 위쪽으로 한번 돌려주세요";
                    ani( pTarget, 5);
                    break;
                case "F2":
                    status.Text = "우측면 앞줄을 아래쪽으로 두번 돌려주세요";
                    ani( pTarget, 4);
                    break;
                case "B":
                    status.Text = "우측면 끝줄을 위쪽으로 한번 돌려주세요";
                    ani( pTarget, 6);
                    break;
                case "B'":
                    status.Text = "우측면 끝줄을 아래쪽으로 한번 돌려주세요";
                    ani( pTarget, 7);
                    break;
                case "B2":
                    status.Text = "우측면 끝줄을 위쪽으로 두번 돌려주세요";
                    ani( pTarget, 6);
                    break;
                case "D":
                    status.Text = "밑면을 오른쪽으로 한번 돌려주세요";
                    ani( pTarget, 8);
                    break;
                case "D'":
                    status.Text = "밑면을 왼쪽으로 한번 돌려주세요";
                    ani( pTarget, 9);
                    break;
                case "D2":
                    status.Text = "밑면을 오른쪽으로 두번 돌려주세요";
                    ani( pTarget, 8);
                    break;
                case "U":
                    status.Text = "윗면을 왼쪽으로 한번 돌려주세요";
                    ani( pTarget, 10);
                    break;
                case "U'":
                    status.Text = "윗면을 오른쪽으로 한번 돌려주세요";
                    ani( pTarget, 11);
                    break;
                case "U2":
                    status.Text = "윗면을 왼쪽으로 두번 돌려주세요";
                    ani( pTarget, 10);
                    break;
            }
            e.Graphics.ReleaseHdc(pTarget);
            

        }
        Point[] pntu(int x,int y,int tp1,int tp2)//tp1 = 애니메이션 모양, tp2 = 블리팅 이미지
        {
            Point[] pt = new Point[3];
                pt[0] = new Point(x, y);
            switch(tp2)
            {
                case 0:
                case 1:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point( x + 79, y + 51); 
                            pt[2] = new Point( x + 79, y-51);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point( x + 79, y + 51); 
                            pt[2] = new Point( x + 79, y-51);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point( x + 80, y + 50); 
                            pt[2] = new Point( x + 80, y-50);
                            break;
                    }
                    break;
                case 2:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point( x + 79, y + 51);
                            pt[2] = new Point( x + 68, y-82);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point( x + 68, y + 80);
                            pt[2] = new Point( x + 80, y-51);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point( x + 50, y + 61);
                            pt[2] = new Point( x + 96, y-27);
                            break;
                    }
                    break;
                case 3:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point( x + 80, y + 51);
                            pt[2] = new Point( x + 75, y-5);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point( x + 72, y + 3);
                            pt[2] = new Point( x + 81, y-52);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point( x + 98, y + 28);
                            pt[2] = new Point( x + 50, y-60);
                            break;
                    }
                    break;
            }
            return pt;
        }
        Point[] pntl(int x, int y, int tp1, int tp2)//tp1 = 애니메이션 모양, tp2 = 블리팅 이미지
        {
            Point[] pt = new Point[3];
                pt[0] = new Point(x, y);
            switch (tp2)
            {
                case 0:
                case 1:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 80, y + 50);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 80, y + 50);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 80, y + 50);
                            break;
                    }
                    break;
                case 2:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x + 26, y + 58);
                            pt[2] = new Point(x + 80, y + 50);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x - 28, y + 59);
                            pt[2] = new Point(x + 67, y + 81);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 80);
                            pt[2] = new Point(x + 49, y + 59);
                            break;
                    }
                    break;
                case 3:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x - 20, y + 85);
                            pt[2] = new Point(x + 80, y + 52);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x + 19, y + 84);
                            pt[2] = new Point(x + 72, y + 2);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 80);
                            pt[2] = new Point(x + 97, y + 27);
                            break;
                    }
                    break;
            }
            return pt;
        }
        Point[] pntr(int x, int y, int tp1, int tp2)//tp1 = 애니메이션 모양, tp2 = 블리팅 이미지
        {
            Point[] pt = new Point[3];
                pt[0] = new Point(x, y);
            switch (tp2)
            {
                case 0:
                case 1:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 80, y - 51);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x, y + 79);
                            pt[2] = new Point(x + 80, y - 50);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 80, y - 50);
                            break;
                    }
                    break;
                case 2:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x + 28, y + 58);
                            pt[2] = new Point(x + 69, y - 82);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x - 26, y + 59);
                            pt[2] = new Point(x + 80, y - 50);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 80);
                            pt[2] = new Point(x + 97, y - 26);
                            break;
                    }
                    break;
                case 3:
                    switch (tp1)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            pt[1] = new Point(x - 19, y + 84);
                            pt[2] = new Point(x + 74, y - 3);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            pt[1] = new Point(x + 18, y + 84);
                            pt[2] = new Point(x + 80, y - 52);
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            pt[1] = new Point(x, y + 78);
                            pt[2] = new Point(x + 50, y - 60);
                            break;
                    }
                    break;
            }
            return pt;
        }
        int[] getxy(int i, int j, int tp1, int tp2, char tp3)//tp1 = 애니메이션 모양, tp2 = 블리팅 이미지,tp3 = ulr
        {
            int[] xy = new int[2];
            switch(tp1)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    switch(tp2)
                    {
                        case 0:
                            switch(tp3)
                            {
                                case 'u':
                                    xy[0] = 79 * i + 79 * j + 1;
                                    xy[1] = 50 * i + -52 * j + 154;

                                    break;
                                case 'l':
                                    xy[0] = 0 * i + 79 * j + 1;
                                    xy[1] = 78 * i + 50 * j + 154;
                                    break;
                                case 'r':
                                    xy[0] = 0 * i + 80 * j + 160;
                                    xy[1] = 78 * i + -51 * j + 255;

                                    break;
                            }
                            break;
                        case 1:
                            switch(tp3)
                            {
                                case 'u':
                                    xy[0] =  79 * j + 41;
                                    xy[1] = -51 * j + 178;
                                    break;
                                case 'l':
                                    xy[0] = 41;
                                    xy[1] = 77 * i + 179;
                                    break;
                                case 'r':
                                    xy[0] = 80 * j + 120;
                                    xy[1] = 77 * i + -50 * j + 228;
                                    break;
                            }
                            break;
                        case 2:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] =  68 * j + 2;
                                    xy[1] = -82 * j + 246;
                                    break;
                                case 'l':
                                    xy[0] = 26 * i + 2;
                                    xy[1] = 58 * i + 247;
                                    break;
                                case 'r':
                                    xy[0] = 28 * i + 69 * j + 82;
                                    xy[1] = 59 * i + -81 * j + 297;
                                    break;
                            }
                            break;
                        case 3:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 75 * j + 64;
                                    xy[1] = -5 * j + 87;
                                    break;
                                case 'l':
                                    xy[0] = -20 * i + 80 * j + 65;
                                    xy[1] = 84 * i + 52 * j + 87;
                                    break;
                                case 'r':
                                    xy[0] = -19 * i + 74 * j + 145;
                                    xy[1] = 84 * i + -4 * j + 139;
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    switch(tp2)
                    {
                        case 0:
                            switch(tp3)
                            {
                                case 'u':
                                    xy[0] = 78 * i + 79 * j + 1;
                                    xy[1] = 50 * i + -52 * j + 103;
                                    break;
                                case 'l':
                                    xy[0] = 79 * j;
                                    xy[1] = 79 * i + 50 * j + 103;
                                    break;
                                case 'r':
                                    xy[0] = 79 * j + 240;
                                    xy[1] = 78 * i + -50 * j + 255;
                                    break;
                            }
                            break;
                        case 1:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 80 * i + 10;
                                    xy[1] = 50 * i +76;
                                    break;
                                case 'l':
                                    xy[0] = 80 * j + 10;
                                    xy[1] = 78 * i + 50 * j + 76;
                                    break;
                                case 'r':
                                    xy[0] = 0 * i + 250;
                                    xy[1] = 77 * i + 229;
                                    break;
                            }
                            break;
                        case 2:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 68 * i + 82;
                                    xy[1] = 80 * i +  53;
                                    break;
                                case 'l':
                                    xy[0] = -28 * i + 67 * j + 82;
                                    xy[1] = 59 * i + 80 * j + 54;
                                    break;
                                case 'r':
                                    xy[0] = -26 * i + 287;
                                    xy[1] = 59 * i + 297;
                                    break;
                            }
                            break;
                        case 3:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 72 * i +  7;
                                    xy[1] = 3 * i + 129;

                                    break;
                                case 'l':
                                    xy[0] = 19 * i + 72 * j + 6;
                                    xy[1] = 84 * i + 2 * j + 130;

                                    break;
                                case 'r':
                                    xy[0] = 18 * i + 226;
                                    xy[1] = 84 * i + 139;
                                    break;
                            }
                            break;
                    }              
                    break;
                case 8:
                case 9:
                case 10:
                case 11:
                     switch(tp2)
                    {
                        case 0:
                            switch(tp3)
                            {
                                case 'u':
                                    xy[0] = 80 * i + 80 * j + 0;
                                    xy[1] = 51 * i + -51 * j + 153;
                                    break;
                                case 'l':
                                    xy[0] = 79 * j + 1;
                                    xy[1] = 79 * i + 49 * j + 154;

                                    break;
                                case 'r':
                                    xy[0] = 79 * j + 240;
                                    xy[1] = 80*i -50 * j + 305;
                                    break;
                            }
                            break;
                        case 1:
                            switch(tp3)
                            {
                                case 'u':
                                    xy[0] = 80 * i + 80 * j + 0;
                                    xy[1] = 51 * i + -51 * j + 153;   
                                    break;
                                case 'l':
                                    xy[0] = 79 * j + 1;
                                    xy[1] = 49 * j + 154;

                                    break;
                                case 'r':
                                    xy[0] = 79 * j + 240;
                                    xy[1] = -50 * j + 305;
                                    break;
                            }
                            break;
                        case 2:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 50 * i + 96 * j + 26;
                                    xy[1] = 61 * i + -27 * j + 125;
                                    break;
                                case 'l':
                                    xy[0] = 49 * j + 26;
                                    xy[1] = 58 * j + 127;
                                    break;
                                case 'r':
                                    xy[0] = 97 * j + 176;
                                    xy[1] = -25 * j + 307;
                                    break;
                            }
                            break;
                        case 3:
                            switch (tp3)
                            {
                                case 'u':
                                    xy[0] = 98 * i + 50 * j + 10;
                                    xy[1] = 28 * i + -60 * j + 226;
                                    break;
                                case 'l':
                                    xy[0] = 97 * j + 10;
                                    xy[1] = 27 * j + 227;

                                    break;
                                case 'r':
                                    xy[0] = 50 * j + 303;
                                    xy[1] = -60 * j + 307;
                                    break;
                            }
                            break;
                    }              
                    break;
            }
            xy[0] += 60;
            xy[1] += 27;
            switch (tp1)
            {
                case 0:
                case 1://L
                    xy[0] -= 39;
                    xy[1] -= 24;
                    if (tp2 == 0)
                    {
                        xy[0] += 120;
                        xy[1] += 75;
                    }
                    break;
                case 2:
                case 3://R
                    if (tp2 > 0)
                    {
                        xy[0] += 120;
                        xy[1] += 78;
                    }
                    break;
                case 4:
                case 5://F
                    xy[0] -= 9;
                    if (tp2 == 0) xy[0] += 90;
                    else xy[1] += 78;
                    break;
                case 6:
                case 7://B
                    xy[1] -= 24;
                    if (tp2 == 0) xy[1] += 75;
                    else xy[0] += 150;
                    break;
                case 8:
                case 9://D               
                    if (tp2 >0) xy[1] += 158;
                    break;
                case 10:
                case 11://U         
                    if (tp2 ==0) xy[1] += 79;
                    break;
                default:
                    break;
            }
            return xy;
        }
        int[,,,] ptlim(int tp)
        {
            int[, , ,] lim = new int[4, 3, 2, 2];
            switch (tp)
            {
                case 0://L
                case 1:
                    lim[0, 0, 0, 0] = 1;
                    lim[0, 0, 0, 1] = 2;
                    lim[0, 0, 1, 0] = 0;
                    lim[0, 0, 1, 1] = 2;
                    lim[0, 1, 0, 0] = 0;
                    lim[0, 1, 0, 1] = 2;
                    lim[0, 1, 1, 0] = 1;
                    lim[0, 1, 1, 1] = 2;
                    lim[0, 2, 0, 0] = 0;
                    lim[0, 2, 0, 1] = 2;
                    lim[0, 2, 1, 0] = 0;
                    lim[0, 2, 1, 1] = 2;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 0;
                        lim[i, 0, 0, 1] = 0;
                        lim[i, 0, 1, 0] = 0;
                        lim[i, 0, 1, 1] = 2;
                        lim[i, 1, 0, 0] = 0;
                        lim[i, 1, 0, 1] = 2;
                        lim[i, 1, 1, 0] = 0;
                        lim[i, 1, 1, 1] = 0;
                        lim[i, 2, 0, 0] = 0;
                        lim[i, 2, 0, 1] = 2;
                        lim[i, 2, 1, 0] = 0;
                        lim[i, 2, 1, 1] = 2;
                    }
                    break;
                case 2://R
                case 3:
                    lim[0, 0, 0, 0] = 0;
                    lim[0, 0, 0, 1] = 1;
                    lim[0, 0, 1, 0] = 0;
                    lim[0, 0, 1, 1] = 2;
                    lim[0, 1, 0, 0] = 0;
                    lim[0, 1, 0, 1] = 2;
                    lim[0, 1, 1, 0] = 0;
                    lim[0, 1, 1, 1] = 1;
                    lim[0, 2, 0, 0] = 0;
                    lim[0, 2, 0, 1] = 2;
                    lim[0, 2, 1, 0] = 0;
                    lim[0, 2, 1, 1] = 2;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 2;
                        lim[i, 0, 0, 1] = 2;
                        lim[i, 0, 1, 0] = 0;
                        lim[i, 0, 1, 1] = 2;
                        lim[i, 1, 0, 0] = 0;
                        lim[i, 1, 0, 1] = 2;
                        lim[i, 1, 1, 0] = 2;
                        lim[i, 1, 1, 1] = 2;
                        lim[i, 2, 0, 0] = 0;
                        lim[i, 2, 0, 1] = 2;
                        lim[i, 2, 1, 0] = 0;
                        lim[i, 2, 1, 1] = 2;
                    }
                    break;
                case 4://F
                case 5:
                    lim[0, 0, 0, 0] = 0;
                    lim[0, 0, 0, 1] = 2;
                    lim[0, 0, 1, 0] = 1;
                    lim[0, 0, 1, 1] = 2;
                    lim[0, 1, 0, 0] = 0;
                    lim[0, 1, 0, 1] = 2;
                    lim[0, 1, 1, 0] = 0;
                    lim[0, 1, 1, 1] = 2;
                    lim[0, 2, 0, 0] = 0;
                    lim[0, 2, 0, 1] = 2;
                    lim[0, 2, 1, 0] = 1;
                    lim[0, 2, 1, 1] = 2;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 0;
                        lim[i, 0, 0, 1] = 2;
                        lim[i, 0, 1, 0] = 0;
                        lim[i, 0, 1, 1] = 0;
                        lim[i, 1, 0, 0] = 0;
                        lim[i, 1, 0, 1] = 2;
                        lim[i, 1, 1, 0] = 0;
                        lim[i, 1, 1, 1] = 2;
                        lim[i, 2, 0, 0] = 0;
                        lim[i, 2, 0, 1] = 2;
                        lim[i, 2, 1, 0] = 0;
                        lim[i, 2, 1, 1] = 0;
                    }
                    break;
                case 6://B
                case 7:
                    lim[0, 0, 0, 0] = 0;
                    lim[0, 0, 0, 1] = 2;
                    lim[0, 0, 1, 0] = 0;
                    lim[0, 0, 1, 1] = 1;
                    lim[0, 1, 0, 0] = 0;
                    lim[0, 1, 0, 1] = 2;
                    lim[0, 1, 1, 0] = 0;
                    lim[0, 1, 1, 1] = 2;
                    lim[0, 2, 0, 0] = 0;
                    lim[0, 2, 0, 1] = 2;
                    lim[0, 2, 1, 0] = 0;
                    lim[0, 2, 1, 1] = 1;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 0;
                        lim[i, 0, 0, 1] = 2;
                        lim[i, 0, 1, 0] = 2;
                        lim[i, 0, 1, 1] = 2;
                        lim[i, 1, 0, 0] = 0;
                        lim[i, 1, 0, 1] = 2;
                        lim[i, 1, 1, 0] = 0;
                        lim[i, 1, 1, 1] = 2;
                        lim[i, 2, 0, 0] = 0;
                        lim[i, 2, 0, 1] = 2;
                        lim[i, 2, 1, 0] = 2;
                        lim[i, 2, 1, 1] = 2;
                    }
                    break;
                case 8:
                case 9://중하
                    lim[0, 0, 0, 0] = 0;
                    lim[0, 0, 0, 1] = 2;
                    lim[0, 0, 1, 0] = 0;
                    lim[0, 0, 1, 1] = 2;
                    lim[0, 1, 0, 0] = 0;
                    lim[0, 1, 0, 1] = 1;
                    lim[0, 1, 1, 0] = 0;
                    lim[0, 1, 1, 1] = 2;
                    lim[0, 2, 0, 0] = 0;
                    lim[0, 2, 0, 1] = 1;
                    lim[0, 2, 1, 0] = 0;
                    lim[0, 2, 1, 1] = 2;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 0;
                        lim[i, 0, 0, 1] = 2;
                        lim[i, 0, 1, 0] = 0;
                        lim[i, 0, 1, 1] = 2;
                        lim[i, 1, 0, 0] = 2;
                        lim[i, 1, 0, 1] = 2;
                        lim[i, 1, 1, 0] = 0;
                        lim[i, 1, 1, 1] = 2;
                        lim[i, 2, 0, 0] = 2;
                        lim[i, 2, 0, 1] = 2;
                        lim[i, 2, 1, 0] = 0;
                        lim[i, 2, 1, 1] = 2;
                    }
                    break;
                case 10:
                case 11://중상
                    lim[0, 0, 0, 0] = 0;
                    lim[0, 0, 0, 1] = 2;
                    lim[0, 0, 1, 0] = 0;
                    lim[0, 0, 1, 1] = 2;
                    lim[0, 1, 0, 0] = 1;
                    lim[0, 1, 0, 1] = 2;
                    lim[0, 1, 1, 0] = 0;
                    lim[0, 1, 1, 1] = 2;
                    lim[0, 2, 0, 0] = 1;
                    lim[0, 2, 0, 1] = 2;
                    lim[0, 2, 1, 0] = 0;
                    lim[0, 2, 1, 1] = 2;
                    for (int i = 1; i < 4; i++)
                    {
                        lim[i, 0, 0, 0] = 0;
                        lim[i, 0, 0, 1] = 2;
                        lim[i, 0, 1, 0] = 0;
                        lim[i, 0, 1, 1] = 2;
                        lim[i, 1, 0, 0] = 0;
                        lim[i, 1, 0, 1] = 0;
                        lim[i, 1, 1, 0] = 0;
                        lim[i, 1, 1, 1] = 2;
                        lim[i, 2, 0, 0] = 0;
                        lim[i, 2, 0, 1] = 0;
                        lim[i, 2, 1, 0] = 0;
                        lim[i, 2, 1, 1] = 2;
                    }
                    break;
            }
            return lim;
        }
        int[,] bonexy(int tp1)
        {
            int[,] xy = new int[,] {{60,27},{60,27}};
             switch(tp1)
            {
                case 0:
                case 1://L
                    xy[0,0] -= 39;
                    xy[0,1] -= 24;
                    xy[1,0] -= 39;
                    xy[1,1] -= 24;
                    xy[0,0] += 120;
                    xy[0,1] += 75;
                    break;
                case 2:
                case 3://R
                    xy[1,0] += 120;
                    xy[1,1] += 78;
                    break;
                case 4:
                case 5://F
                    xy[0,0] -= 9;
                    xy[1, 0] -= 9;
                    xy[0,0] += 90;
                    xy[1,1] += 78;
                    break;
                case 6:
                case 7://B
                    xy[0,1] -= 24;
                    xy[1, 1] -= 24;
                    xy[0,1] += 75;
                    xy[1,0] += 150;
                    break;            
                case 8:
                case 9://D               
                    xy[1,1] +=158;
                    break;
                case 10:
                case 11://U         
                    xy[0,1] += 79;
                    break;
                default:
                    break;
            }
             return xy;
        }
        void ani(IntPtr pt, int tp)
        {
            Bitmap nbmp = new Bitmap(Properties.Resources.display);
            int bmpnum = tp / 4;
            int tp2=cnt2;
            if (tp == 1 || tp == 2 || tp == 5 || tp == 6 || tp == 8 || tp == 11)
            {
                switch(cnt2)
                {
                    case 1:
                        break;
                    case 2:
                        tp2 = 3;
                        break;
                    case 3:
                        tp2 = 2;
                        break;
                }
            }
            int[,,,] lim = ptlim(tp);//이미지번호,ulr,xy,시작 끝
            IntPtr[] clr = new IntPtr[7];
            IntPtr porig;
            for (int i = 0; i < 7; i++)
            {
                clr[i] = CreateCompatibleDC(pt);
                porig = SelectObject(clr[i], side[i].GetHbitmap());
            }
                IntPtr bn0, bn;
                IntPtr ps = CreateCompatibleDC(pt);
                porig = SelectObject(ps, nbmp.GetHbitmap());
                bn0= CreateCompatibleDC(pt);
                bn = CreateCompatibleDC(pt);
                porig = SelectObject(bn0, bone[bmpnum, 0].GetHbitmap());
                porig = SelectObject(bn, bone[bmpnum, tp2].GetHbitmap());
                if(tp == 0 || tp == 1 ||tp == 6||tp == 7||tp == 8||tp == 9)//123 먼저
                {
                    int[,] bxy = bonexy(tp);
                    for(int i=lim[tp2,0,0,0];i<=lim[tp2,0,0,1];i++) //up
                    {
                        for (int j = lim[tp2, 0, 1, 0]; j <= lim[tp2, 0, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 0, 0, 0], j - lim[tp2, 0, 1, 0], tp, tp2, 'u');                    
                            Point[] ptu = pntu(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[0, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[tp2, 1, 0, 0]; i <= lim[tp2, 1, 0, 1]; i++) //left
                    {
                        for (int j = lim[tp2, 1, 1, 0]; j <= lim[tp2, 1, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 1, 0, 0], j - lim[tp2, 1, 1, 0], tp, tp2, 'l');
                            Point[] ptu = pntl(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[1, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[tp2, 2, 0, 0]; i <= lim[tp2, 2, 0, 1]; i++) //right
                    {
                        for (int j = lim[tp2, 2, 1, 0]; j <= lim[tp2, 2, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 2, 0, 0], j - lim[tp2,2, 1, 0], tp, tp2, 'r');
                            Point[] ptu = pntr(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[2, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    BitBlt(ps, bxy[1, 0], bxy[1, 1], bone[bmpnum, tp2].Width / 2, bone[bmpnum, tp2].Height, bn, bone[bmpnum, tp2].Width / 2, 0, TernaryRasterOperations.SRCPAINT);
                    BitBlt(ps, bxy[1, 0], bxy[1, 1], bone[bmpnum, tp2].Width / 2, bone[bmpnum, tp2].Height,bn, 0, 0, TernaryRasterOperations.SRCAND);

                    for (int i = lim[0, 0, 0, 0]; i <= lim[0, 0, 0, 1]; i++) //up
                    {
                        for (int j = lim[0, 0, 1, 0]; j <= lim[0, 0, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 0, 0, 0], j - lim[0, 0, 1, 0], tp, 0, 'u');
                            Point[] ptu = pntu(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[0, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[0, 1, 0, 0]; i <= lim[0, 1, 0, 1]; i++) //left
                    {
                        for (int j = lim[0, 1, 1, 0]; j <= lim[0, 1, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 1, 0, 0], j - lim[0, 1, 1, 0], tp, 0, 'l');
                            Point[] ptu = pntl(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[1, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[0, 2, 0, 0]; i <= lim[0, 2, 0, 1]; i++) //right
                    {
                        for (int j = lim[0, 2, 1, 0]; j <= lim[0, 2, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 2, 0, 0], j - lim[0, 2, 1, 0], tp, 0, 'r');
                            Point[] ptu = pntr(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[2, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    BitBlt(ps, bxy[0, 0], bxy[0, 1], bone[bmpnum, 0].Width / 2, bone[bmpnum, 0].Height, bn0, bone[bmpnum, 0].Width / 2, 0, TernaryRasterOperations.SRCPAINT);
                    BitBlt(ps, bxy[0, 0], bxy[0, 1], bone[bmpnum, 0].Width / 2, bone[bmpnum, 0].Height, bn0, 0, 0, TernaryRasterOperations.SRCAND);
                }else
                {
                    int[,] bxy = bonexy(tp);
                    for (int i = lim[0, 0, 0, 0]; i <= lim[0, 0, 0, 1]; i++) //up
                    {
                        for (int j = lim[0, 0, 1, 0]; j <= lim[0, 0, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 0, 0, 0], j - lim[0, 0, 1, 0], tp, 0, 'u');
                            Point[] ptu = pntu(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[0, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[0, 1, 0, 0]; i <= lim[0, 1, 0, 1]; i++) //left
                    {
                        for (int j = lim[0, 1, 1, 0]; j <= lim[0, 1, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 1, 0, 0], j - lim[0, 1, 1, 0], tp, 0, 'l');
                            Point[] ptu = pntl(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[1, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[0, 2, 0, 0]; i <= lim[0, 2, 0, 1]; i++) //right
                    {
                        for (int j = lim[0, 2, 1, 0]; j <= lim[0, 2, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[0, 2, 0, 0], j - lim[0, 2, 1, 0], tp, 0, 'r');
                            Point[] ptu = pntr(xy[0], xy[1], tp, 0);
                            PlgBlt(ps, ptu, clr[cube[2, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    BitBlt(ps, bxy[0, 0], bxy[0, 1], bone[bmpnum, 0].Width / 2, bone[bmpnum, 0].Height, bn0, bone[bmpnum, 0].Width / 2, 0, TernaryRasterOperations.SRCPAINT);
                    BitBlt(ps, bxy[0, 0], bxy[0, 1], bone[bmpnum, 0].Width / 2, bone[bmpnum, 0].Height, bn0, 0, 0, TernaryRasterOperations.SRCAND);

                    
                    for (int i = lim[tp2, 0, 0, 0]; i <= lim[tp2, 0, 0, 1]; i++) //up
                    {
                        for (int j = lim[tp2, 0, 1, 0]; j <= lim[tp2, 0, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 0, 0, 0], j - lim[tp2, 0, 1, 0], tp, tp2, 'u');
                            Point[] ptu = pntu(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[0, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[tp2, 1, 0, 0]; i <= lim[tp2, 1, 0, 1]; i++) //left
                    {
                        for (int j = lim[tp2, 1, 1, 0]; j <= lim[tp2, 1, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 1, 0, 0], j - lim[tp2, 1, 1, 0], tp, tp2, 'l');
                            Point[] ptu = pntl(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[1, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    for (int i = lim[tp2, 2, 0, 0]; i <= lim[tp2, 2, 0, 1]; i++) //right
                    {
                        for (int j = lim[tp2, 2, 1, 0]; j <= lim[tp2, 2, 1, 1]; j++)
                        {
                            int[] xy = getxy(i - lim[tp2, 2, 0, 0], j - lim[tp2, 2, 1, 0], tp, tp2, 'r');
                            Point[] ptu = pntr(xy[0], xy[1], tp, tp2);
                            PlgBlt(ps, ptu, clr[cube[2, i, j]], 0, 0, 130, 130, IntPtr.Zero, 0, 0);
                        }
                    }
                    BitBlt(ps, bxy[1, 0], bxy[1, 1], bone[bmpnum, tp2].Width / 2, bone[bmpnum, tp2].Height, bn, bone[bmpnum, tp2].Width / 2, 0, TernaryRasterOperations.SRCPAINT);
                    BitBlt(ps, bxy[1, 0], bxy[1, 1], bone[bmpnum, tp2].Width / 2, bone[bmpnum, tp2].Height, bn, 0, 0, TernaryRasterOperations.SRCAND);
                }
                BitBlt(pt, 0, 0, 600, 600, ps, 0, 0, TernaryRasterOperations.SRCCOPY);
                if (cnt2 == 2)
                {
                    nextmove(tp);
                }
           DeleteDC(ps);
           DeleteDC(bn);
           DeleteDC(bn0);
           for (int i = 0; i < 7; i++)
               DeleteDC(clr[i]);
        }
        void nextmove(int tp)
        {
/*
L - 좌측 위 > 아래 0
L' - 좌측 아래 > 위 1
R - 좌중 아래 > 위 2
R' - 좌중 위 > 아래 3
F - 우중 위 > 아래 4
F' - 우중 아래 > 위 5
B - 우측 아래 > 위 6
B' - 우측 위 > 아래 7
D - 중하 왼쪽 > 오른쪽 8
D' - 중하 오른쪽 > 왼쪽 9
U - 중위 오른쪽 > 왼쪽 10
U'- 중위 왼쪽 > 오른쪽 11  
*/

            int[] tmp;
            int[,] fc;
            int x = 0, y = 0;
            switch(tp)
            {
                case 0:
                    tmp = new int[] { cube[3, 2, 2], cube[3, 1, 2], cube[3, 0, 2] };
                    cube[3, 2, 2] = cube[5, 2, 0];
                    cube[3, 1, 2] = cube[5, 2, 1];
                    cube[3, 0, 2] = cube[5, 2, 2];
                    cube[5, 2, 0] = cube[1, 0, 0];
                    cube[5, 2, 1] = cube[1, 1, 0];
                    cube[5, 2, 2] = cube[1, 2, 0];
                    cube[1, 0, 0] = cube[0, 0, 2];
                    cube[1, 1, 0] = cube[0, 0, 1];
                    cube[1, 2, 0] = cube[0, 0, 0];
                    cube[0, 0, 2] = tmp[0];
                    cube[0, 0, 1] = tmp[1];
                    cube[0, 0, 0] = tmp[2];
                    fc = new int[,] {{cube[4,0,0],cube[4,0,1],cube[4,0,2]},{cube[4,1,0],cube[4,1,1],cube[4,1,2]},{cube[4,2,0],cube[4,2,1],cube[4,2,2]}};
	                for (int i = 2; i >=0; i--)
		                for (int j = 0; j < 3; j++)
		                {
			                cube[4,j,i] = fc[x,y];
			                y++;
			                if (y == 3)
			                {
				                y = 0;
				                x++;
			                }
		                }
                     break;
                case 1:
                    tmp = new int[] { cube[0, 0, 2], cube[1, 0, 1], cube[1, 0, 0] };
                    cube[0, 0, 2] = cube[1, 0, 0];
                    cube[0, 0, 1] = cube[1, 1, 0];
                    cube[0, 0, 0] = cube[1, 2, 0];
                    cube[1, 0, 0] = cube[5, 2, 0];
                    cube[1, 1, 0] = cube[5, 2, 1];
                    cube[1, 2, 0] = cube[5, 2, 2];
                    cube[5, 2, 0] = cube[3, 2, 2];
                    cube[5, 2, 1] = cube[3, 1, 2];
                    cube[5, 2, 2] = cube[3, 0, 2];
                    cube[3, 2, 2] = tmp[0];
                    cube[3, 1, 2] = tmp[1];
                    cube[3, 0, 2] = tmp[2];
                    fc = new int[,] {{cube[4,0,0],cube[4,0,1],cube[4,0,2]},{cube[4,1,0],cube[4,1,1],cube[4,1,2]},{cube[4,2,0],cube[4,2,1],cube[4,2,2]}};
                    for (int j = 0; j < 3; j++)
		                for (int i = 2; i >=0; i--)
		                {
			                cube[4,i,j] = fc[x,y];
			                y++;
			                if (y == 3)
			                {
				                y = 0;
				                x++;
			                }
		                }
                    break;
                case 2:
                    tmp = new int[] { cube[0,2,2], cube[0,2,1], cube[0,2,0] };
                    for (int i = 0; i < 3; i++)
                        cube[0,2,2-i] = cube[1, i,2];
                    for (int i = 0; i < 3; i++)
                        cube[1,i, 2] = cube[5, 0, i];
                    for (int i = 0; i < 3; i++)
                        cube[5, 0, i] = cube[3, 2-i, 0];
                    for (int i = 0; i < 3; i++)
                        cube[3, i, 0] = tmp[2-i];
                    fc = new int[,] { { cube[2, 0, 0], cube[2, 0, 1], cube[2, 0, 2] }, { cube[2, 1, 0], cube[2, 1, 1], cube[2, 1, 2] }, { cube[2, 2, 0], cube[2, 2, 1], cube[2, 2, 2] } };
                    for (int i = 2; i >= 0; i--)
                        for (int j = 0; j < 3; j++)
                        {
                            cube[2, j, i] = fc[x, y];
                            y++;
                            if (y == 3)
                            {
                                y = 0;
                                x++;
                            }
                        }
                    break;
                case 3:
                   tmp = new int[] { cube[3,0,0], cube[3,1,0], cube[3,2,0] };
                    for (int i = 0; i < 3; i++)
                        cube[3, 2 - i, 0] = cube[5, 0, i];
                    for (int i = 0; i < 3; i++)
                        cube[5, 0, i] = cube[1, i, 2];
                    for (int i = 0; i < 3; i++)
                        cube[1, i, 2] = cube[0, 2, 2-i];
                    for (int i = 0; i < 3; i++)
                        cube[0, 2, 2-i] = tmp[2-i];
                    fc = new int[,] { { cube[2, 0, 0], cube[2, 0, 1], cube[2, 0, 2] }, { cube[2, 1, 0], cube[4, 1, 1], cube[2, 1, 2] }, { cube[2, 2, 0], cube[2, 2, 1], cube[2, 2, 2] } };
                    for (int j = 0; j < 3; j++)
                        for (int i = 2; i >= 0; i--)
                        {
                            cube[2, i,j] = fc[x, y];
                            y++;
                            if (y == 3)
                            {
                                y = 0;
                                x++;
                            }
                        }
                    break;

                case 4:
                    tmp = new int[] { cube[4, 2, 2], cube[4, 1, 2], cube[4, 0, 2] };
                    for (int i = 0; i < 3; i++)
                        cube[4, 2 - i, 2] = cube[5, i, 0];
                    for (int i = 0; i < 3; i++)
                        cube[5,i, 0] = cube[2, i, 0];
                    for (int i = 0; i < 3; i++)
                        cube[2,i, 0] = cube[0,i, 0];
                    for (int i = 0; i < 3; i++)
                        cube[0,i,0] = tmp[i];
                    fc = new int[,] {{cube[1,0,0],cube[1,0,1],cube[1,0,2]},{cube[1,1,0],cube[1,1,1],cube[1,1,2]},{cube[1,2,0],cube[1,2,1],cube[1,2,2]}};
	                for (int i = 2; i >=0; i--)
		                for (int j = 0; j < 3; j++)
		                {
			                cube[1,j,i] = fc[x,y];
			                y++;
			                if (y == 3)
			                {
				                y = 0;
				                x++;
			                }
		                }
                     break;
                case 5:
                     tmp = new int[] { cube[0, 0, 0], cube[0, 1, 0], cube[0, 2, 0] };
                     for (int i = 0; i < 3; i++)
                         cube[0, i, 0] = cube[2, i, 0];
                     for (int i = 0; i < 3; i++)
                         cube[2, i, 0] = cube[5, i, 0];
                     for (int i = 0; i < 3; i++)
                         cube[5, i, 0] = cube[4, 2 - i, 2];
                     for (int i = 0; i < 3; i++)
                         cube[4, 2 - i, 2] = tmp[i];
                     fc = new int[,] { { cube[1, 0, 0], cube[1, 0, 1], cube[1, 0, 2] }, { cube[1, 1, 0], cube[1, 1, 1], cube[1, 1, 2] }, { cube[1, 2, 0], cube[1, 2, 1], cube[1, 2, 2] } };
                     for (int j = 0; j < 3; j++)
                         for (int i = 2; i >= 0; i--)
                         {
                             cube[4, i, j] = fc[x, y];
                             y++;
                             if (y == 3)
                             {
                                 y = 0;
                                 x++;
                             }
                         }
                     break;
                case 6:
                     tmp = new int[] { cube[0, 0, 2], cube[0, 1, 2], cube[0, 2, 2] };
                     for (int i = 0; i < 3; i++)
                         cube[0, i, 2] = cube[2, i, 2];
                     for (int i = 0; i < 3; i++)
                         cube[2, i, 2] = cube[5, i,2];
                     for (int i = 0; i < 3; i++)
                         cube[5, i,2] = cube[4, 2 - i, 0];
                     for (int i = 0; i < 3; i++)
                         cube[4, 2 - i, 0] = tmp[i];
                     fc = new int[,] { { cube[3, 0, 0], cube[3, 0, 1], cube[3, 0, 2] }, { cube[3, 1, 0], cube[3, 1, 1], cube[3, 1, 2] }, { cube[3, 2, 0], cube[3, 2, 1], cube[3, 2, 2] } };
                     for (int i = 2; i >= 0; i--)
                         for (int j = 0; j < 3; j++)
                         {
                             cube[3, i, j] = fc[x, y];
                             y++;
                             if (y == 3)
                             {
                                 y = 0;
                                 x++;
                             }
                         }
                     break;
                case 7:
                     tmp = new int[] { cube[4,2,0], cube[4,1,0], cube[4,0,0] };
                     for (int i = 0; i < 3; i++)
                         cube[4, 2 - i, 0] = cube[5, i, 2];
                     for (int i = 0; i < 3; i++)
                         cube[5, i, 2] = cube[2, i, 2];
                     for (int i = 0; i < 3; i++)
                         cube[2, i, 2] = cube[0, i,2];
                     for (int i = 0; i < 3; i++)
                         cube[0, i, 2] = tmp[i];
                     fc = new int[,] { { cube[3, 0, 0], cube[3, 0, 1], cube[3, 0, 2] }, { cube[3, 1, 0], cube[3, 1, 1], cube[3, 1, 2] }, { cube[3, 2, 0], cube[3, 2, 1], cube[3, 2, 2] } };
                     for (int j = 0; j < 3; j++)
                         for (int i = 2; i >= 0; i--)
                         {
                             cube[3, i,j] = fc[x, y];
                             y++;
                             if (y == 3)
                             {
                                 y = 0;
                                 x++;
                             }
                         }
                     break;
                case 8:
                     tmp = new int[] { cube[4, 2, 0], cube[4, 2, 1], cube[4, 2, 2] };
                     for (int i = 0; i < 3; i++)
                         cube[4, 2, i] = cube[3, 2, i];
                     for (int i = 0; i < 3; i++)
                         cube[3,2,i] = cube[2, 2,i];
                     for (int i = 0; i < 3; i++)
                         cube[2, 2,i] = cube[1,2,i];
                     for (int i = 0; i < 3; i++)
                         cube[1,2,i] = tmp[i];
                    fc = new int[,] {{cube[5,0,0],cube[5,0,1],cube[5,0,2]},{cube[5,1,0],cube[5,1,1],cube[5,1,2]},{cube[5,2,0],cube[5,2,1],cube[5,2,2]}};
	                for (int i = 2; i >=0; i--)
		                for (int j = 0; j < 3; j++)
		                {
			                cube[5,j,i] = fc[x,y];
			                y++;
			                if (y == 3)
			                {
				                y = 0;
				                x++;
			                }
		                }
                     break;
                case 9:
                     tmp = new int[] { cube[1,2,0], cube[1,2,1], cube[1, 2, 2] };
                     for (int i = 0; i < 3; i++)
                          cube[1, 2, i]=cube[2, 2, i] ;
                     for (int i = 0; i < 3; i++)
                         cube[2, 2, i] = cube[3, 2, i];
                     for (int i = 0; i < 3; i++)
                         cube[3, 2, i] = cube[4, 2, i];
                     for (int i = 0; i < 3; i++)
                         cube[4, 2, i] = tmp[i];
                     fc = new int[,] { { cube[5, 0, 0], cube[5, 0, 1], cube[5, 0, 2] }, { cube[5, 1, 0], cube[5, 1, 1], cube[5, 1, 2] }, { cube[5, 2, 0], cube[5, 2, 1], cube[5, 2, 2] } };
                     for (int j = 0; j < 3; j++)
                         for (int i = 2; i >= 0; i--)
                         {
                             cube[5, i, j] = fc[x, y];
                             y++;
                             if (y == 3)
                             {
                                 y = 0;
                                 x++;
                             }
                         }
                     break;
                case 10:
                     tmp = new int[] { cube[1, 0, 0], cube[1, 0, 1], cube[1, 0, 2] };
                     for (int i = 0; i < 3; i++)
                         cube[1, 0, i] = cube[2, 0, i];
                     for (int i = 0; i < 3; i++)
                         cube[2, 0, i] = cube[3, 0, i];
                     for (int i = 0; i < 3; i++)
                         cube[3, 0, i] = cube[4, 0, i];
                     for (int i = 0; i < 3; i++)
                         cube[4, 0, i] = tmp[i];
                     fc = new int[,] { { cube[0, 0, 0], cube[0, 0, 1], cube[0, 0, 2] }, { cube[0, 1, 0], cube[0, 1, 1], cube[0, 1, 2] }, { cube[0, 2, 0], cube[0, 2, 1], cube[0, 2, 2] } };
                     for (int i = 2; i >= 0; i--)
                         for (int j = 0; j < 3; j++)
                         {
                             cube[0, j, i] = fc[x, y];
                             y++;
                             if (y == 3)
                             {
                                 y = 0;
                                 x++;
                             }
                         }
                     break;
                case 11:
                     tmp = new int[] { cube[4, 0, 0], cube[4, 0, 1], cube[4, 0, 2] };
                     for (int i = 0; i < 3; i++)
                         cube[4, 0, i] = cube[3, 0, i];
                     for (int i = 0; i < 3; i++)
                         cube[3,0,i] = cube[2, 0,i];
                     for (int i = 0; i < 3; i++)
                         cube[2, 0,i] = cube[1,0,i];
                     for (int i = 0; i < 3; i++)
                         cube[1,0,i] = tmp[i];
                     fc = new int[,] { { cube[0, 0, 0], cube[0, 0, 1], cube[0, 0, 2] }, { cube[0, 1, 0], cube[0, 1, 1], cube[0, 1, 2] }, { cube[0, 2, 0], cube[0, 2, 1], cube[0, 2, 2] } };
                     for (int j = 0; j < 3; j++)
                         for (int i = 2; i >= 0; i--)
                         {
                             cube[0, i, j] = fc[x, y];
			                y++;
			                if (y == 3)
			                {
				                y = 0;
				                x++;
			                }
		                }
                     break;
            }
        }
        int timercnt=0;
        private void autoplaying_Tick(object sender, EventArgs e)
        {
            if(cnt<sol.Length-1)
            {
                cnt2++;
                if (sol[cnt].Contains("2") == true)
                {
                    timercnt++;
                    if (cnt2 > 3)
                        cnt2 = 1;
                    if(timercnt>6)
                    {
                        timercnt = 0;
                        cnt2 = 1;
                        if (auto)
                        {
                            cnt++;

                        }
                        else
                            autoplaying.Enabled = false;

                    }
                }
                if(cnt2>3)
                {
                    cnt2 = 1;
                    if (auto)
                    {
                        cnt++;
                        
                    }
                    else
                        autoplaying.Enabled = false;

                }
                count.Text = (cnt + 1).ToString() + " / " + sol.Length.ToString();
                display.Refresh();
            }
            else
            {
                int len = sol.Length-1;
                MessageBox.Show(len.ToString() + "번에 거친\n큐브 맞추기 성공!!", "Success!!", MessageBoxButtons.OK,MessageBoxIcon.None);
                autoplaying.Enabled = false;
                auto = false;
                but_back.Enabled = true;
                but_next.Enabled = false;
                but_auto.BackColor = SystemColors.Control;
            }
        }

        private void but_back_Click(object sender, EventArgs e)
        {
            cnt--;
            display.Refresh();
            count.Text = (cnt + 1).ToString() + " / " + sol.Length.ToString();
            autoplaying.Enabled = true;
        }

        private void but_next_Click(object sender, EventArgs e)
        {
            cnt++;
            display.Refresh();
            count.Text = (cnt + 1).ToString() + " / " + sol.Length.ToString();
            autoplaying.Enabled = true;
        }
    }
}
