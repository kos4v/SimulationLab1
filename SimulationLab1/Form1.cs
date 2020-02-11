using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace SimulationLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonPlusLabel();// Загрузка в массив типа bpl buttons and labels
        }

        private void buttonPlusLabel()
        {
            int i = 0, j = 0;
            foreach (var item in panel1.Controls)
            {

                if (item is System.Windows.Forms.Button)
                {
                    bPLs[i++].butt = ((System.Windows.Forms.Button)item);
                }
                if (item is System.Windows.Forms.Label)
                {
                    bPLs[j++].lab = ((System.Windows.Forms.Label)item);
                }

            }
        }

        int myMoney = 10;
        struct bPL
        {
            public System.Windows.Forms.Button butt;
            public Label lab;
            public int day;

        } // сопостовление каждой кнопке label и дня
        bPL[] bPLs = new bPL[16];
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            int debt = 0;
            switch (((System.Windows.Forms.Button)sender).BackColor.Name)
            {

                case "Black":
                case "White":
                    myMoney -= 5;
                    if (myMoney<0)
                    {
                        myMoney += 5;
                        debt = 1;
                    }
                    break;
                case "Brown":
                    myMoney -= 8;
                    if (myMoney < 0)
                    {
                        myMoney += 8;
                        debt = 1;
                    }
                    break;
                case "Green":
                    myMoney += 1;
                    break;
                case "Yellow":
                    myMoney += 7;
                    break;
                case "Red":
                    myMoney += 10;
                    break;
                default:
                    break;

            }
            if (debt==1)
                return;

            if (((System.Windows.Forms.Button)sender).BackColor == Color.White)
                ((System.Windows.Forms.Button)sender).BackColor  = Color.Black;
            else((System.Windows.Forms.Button)sender).BackColor  = Color.White;

            for (int i = 0; i < 16; i++)
                if (((System.Windows.Forms.Button)sender) == bPLs[i].butt)
                    bPLs[i].day = 0;

            label23.Text = Convert.ToString(myMoney);

            if (myMoney>=1000)
                timer1.Stop();
        }
        
        private void nextColor(System.Windows.Forms.Button butt)
        {
            switch (butt.BackColor.Name)
            {
                
                case "Black":
                    butt.BackColor = Color.Green;
                    break;
                case "Green":
                    butt.BackColor = Color.Yellow;
                    break;
                case "Yellow":
                    butt.BackColor = Color.Red;
                    break;
                case "Red":
                    butt.BackColor = Color.Brown;
                    break;
                default:
                    break;
            }
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
                if (bPLs[i].butt.BackColor != Color.White)
                {
                    switch ((bPLs[i].day))
                    {
                        case 10://green время после которого меняется цвет
                        case 20://yellow
                        case 50://red
                        case 80://brown
                            nextColor(bPLs[i].butt);
                            break;
                        default:
                            break;
                    }
                    (bPLs[i].lab).Text = "Day " + Convert.ToString(bPLs[i].day);
                    (bPLs[i].day) = bPLs[i].day + 1;
                }
            label29.Text = Convert.ToString(i++);
        }

        private void plusSpeed(object sender, EventArgs e)
        {
            if (timer1.Interval >= 500)
                return;
            timer1.Interval += 50;
            label30.Text = Convert.ToString(timer1.Interval);
        }

        private void MinusSpeed(object sender, EventArgs e)
        {
            if (timer1.Interval <= 50)
                return;
            timer1.Interval -= 50;
            label30.Text = Convert.ToString(timer1.Interval);
        }
    }
}
