using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using YatzyDiceGame.Properties;

namespace YatzyDiceGame
{
    public partial class Yatzy : Form
    {
        public Yatzy()
        {
            InitializeComponent();
            ValitutBT.Enabled= false;
        }
            
        private void KaikkiBT_Click(object sender, EventArgs e)
        {
                        
            piirraNoppa(Noppa01PB);
            piirraNoppa(Noppa02PB);
            piirraNoppa(Noppa03PB);
            piirraNoppa(Noppa04PB);
            piirraNoppa(Noppa05PB);

            KaikkiBT.Enabled = false;
            ValitutBT.Enabled = true;
        }

        private void ValitutBT_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                piirraNoppa(Noppa01PB);
            }
            if (checkBox2.Checked)
            {
                piirraNoppa(Noppa02PB);
            }
            if (checkBox3.Checked)
            {
                piirraNoppa(Noppa03PB);
            }
            if (checkBox4.Checked)
            {
                piirraNoppa(Noppa04PB);
            }
            if (checkBox5.Checked)
            {
                piirraNoppa(Noppa05PB);
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        int nopanArvo = 0;
        private void piirraNoppa(PictureBox NoppaBox)
        {
            int nopanArvo = 0;
            Random satunnainen = new Random();
            int noppa = satunnainen.Next(1, 7);
            switch (noppa)
            {
                case 1:
                    NoppaBox.Image = Properties.Resources.dice01;
                    nopanArvo = 1;
                    break;
                case 2:
                    NoppaBox.Image = Properties.Resources.dice02;
                    nopanArvo = 2;
                    break;
                case 3:
                    NoppaBox.Image = Properties.Resources.dice03;
                    nopanArvo = 3;
                    break;
                case 4:
                    NoppaBox.Image = Properties.Resources.dice04;
                    nopanArvo = 4;
                    break;
                case 5:
                    NoppaBox.Image = Properties.Resources.dice05;
                    nopanArvo = 5;
                    break;
                case 6:
                    NoppaBox.Image = Properties.Resources.dice06;
                    nopanArvo = 6;
                    break;
            }
            if (nopanArvo == 1)
            {
                YkkosetSummaLB.Text = "toimii";
            }
            else
            {
                YkkosetSummaLB.Text = "ei toimi";
            }
        }


        private void AlustaBT_Click(object sender, EventArgs e)
        {
            Noppa01PB.Image = Properties.Resources.dice01;
            Noppa02PB.Image = Properties.Resources.dice01;
            Noppa03PB.Image = Properties.Resources.dice01;
            Noppa04PB.Image = Properties.Resources.dice01;
            Noppa05PB.Image = Properties.Resources.dice01;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            KaikkiBT.Enabled = true;
        }
       
        private void YkkosetBT_Click(object sender, EventArgs e)
        {




            if (Noppa01PB.Image == Properties.Resources.dice01)
            {
               YkkosetSummaLB.Text = "1";
            }
            else
            {
                YkkosetSummaLB.Text = "0";
            }


        }
    }
}