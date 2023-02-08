using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using YatzyDiceGame.Properties;

namespace YatzyDiceGame
{
    public partial class Yatzy : Form
    {
        
        int noppaArvo1, noppaArvo2, noppaArvo3, noppaArvo4, noppaArvo5;
        int[] arvoTaulu = new int[5];
        public Yatzy()
        {
            
            InitializeComponent();
            ValitutBT.Enabled= false;
        }

        int clickCount = 0;
        private void KaikkiBT_Click(object sender, EventArgs e)
        {
                        
            noppaArvo1 = piirraNoppa(Noppa01PB);
            arvoTaulu[0] = noppaArvo1;
            noppaArvo2 = piirraNoppa(Noppa02PB);
            arvoTaulu[1] = noppaArvo2;
            noppaArvo3 = piirraNoppa(Noppa03PB);
            arvoTaulu[2] = noppaArvo3;
            noppaArvo4 = piirraNoppa(Noppa04PB);
            arvoTaulu[3] = noppaArvo4;
            noppaArvo5 = piirraNoppa(Noppa05PB);
            arvoTaulu[4] = noppaArvo5;

            MessageBox.Show(noppaArvo1 + " " + noppaArvo2 + " " + noppaArvo3 + " " + noppaArvo4 + " " + noppaArvo5);

            ValitutBT.Enabled= true;
            clickCount++;

            if(clickCount == 3) 
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
                
            }
            



        }
        int nopanArvo = 0;


        private int piirraNoppa(PictureBox NoppaBox)
        {

            Random satunnainen = new Random();
            int noppa = satunnainen.Next(1, 7);
            switch (noppa)
            {
                case 1:
                    NoppaBox.Image = Properties.Resources.dice01;
                    return 1;
                    break;
                case 2:
                    NoppaBox.Image = Properties.Resources.dice02;
                    return 2;
                    break;
                case 3:
                    NoppaBox.Image = Properties.Resources.dice03;
                    return 3;
                    break;
                case 4:
                    NoppaBox.Image = Properties.Resources.dice04;
                    return 4;
                    break;
                case 5:
                    NoppaBox.Image = Properties.Resources.dice05;
                    return 5;
                    break;
                case 6:
                    NoppaBox.Image = Properties.Resources.dice06;
                    return 6;
                    break;
                default:
                    return 0;
                    break;
            }

        }


        private void ValitutBT_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                noppaArvo1 = piirraNoppa(Noppa01PB);
                arvoTaulu[0] = noppaArvo1;
            }
            if (checkBox2.Checked)
            {
                noppaArvo2 = piirraNoppa(Noppa02PB);
                arvoTaulu[1] = noppaArvo2;
            }
            if (checkBox3.Checked)
            {
                noppaArvo3 = piirraNoppa(Noppa03PB);
                arvoTaulu[2] = noppaArvo3;
            }
            if (checkBox4.Checked)
            {
                noppaArvo4 = piirraNoppa(Noppa04PB);
                arvoTaulu[3] = noppaArvo4;
            }
            if (checkBox5.Checked)
            {
                noppaArvo5 = piirraNoppa(Noppa05PB);
                arvoTaulu[4] = noppaArvo5;
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            clickCount++;
            if(clickCount == 3) 
            {
                ValitutBT.Enabled = false;
                KaikkiBT.Enabled = false;
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
            clickCount = 0;
           
        }
            

        // Aletaan määrittelemään pistetaulukkoa

        //Ensimmäisenä määritellään pisteet ykkösten mukaan 
        private void YkkosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 1)
            {
                summa++;
            }
            if (arvoTaulu[1] == 1) 
            {
                summa++;
            }
            if (arvoTaulu[2] == 1)
            {
                summa++;
            }
            if (arvoTaulu[3] == 1)
            {
                summa++;
            }
            if (arvoTaulu[4] == 1)
            {
                summa++;
            }
            YkkosetSummaLB.Text = Convert.ToString(summa);
        }

        private void KakkosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 2)
            {
                summa += 2;
            }
            if (arvoTaulu[1] == 2)
            {
                summa += 2;
            }
            if (arvoTaulu[2] == 2)
            {
                summa += 2;
            }
            if (arvoTaulu[3] == 2)
            {
                summa += 2;
            }
            if (arvoTaulu[4] == 2)
            {
                summa += 2;
            }
            KakkosetSummaLB.Text = Convert.ToString(summa);
        }


        private void KolmosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 3)
            {
                summa += 3;
            }
            if (arvoTaulu[1] == 3)
            {
                summa += 3;
            }
            if (arvoTaulu[2] == 3)
            {
                summa += 3;
            }
            if (arvoTaulu[3] == 3)
            {
                summa += 3;
            }
            if (arvoTaulu[4] == 3)
            {
                summa += 3;
            }
            KolmosetSummaLB.Text = Convert.ToString(summa);
        }


        private void NelosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 4)
            {
                summa += 4;
            }
            if (arvoTaulu[1] == 4)
            {
                summa += 4;
            }
            if (arvoTaulu[2] == 4)
            {
                summa += 4;
            }
            if (arvoTaulu[3] == 4)
            {
                summa += 4;
            }
            if (arvoTaulu[4] == 4)
            {
                summa += 4;
            }
            NelosetSummaLB.Text = Convert.ToString(summa);
        }


        private void ViitosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 5)
            {
                summa += 5;
            }
            if (arvoTaulu[1] == 5)
            {
                summa += 5;
            }
            if (arvoTaulu[2] == 5)
            {
                summa += 5;
            }
            if (arvoTaulu[3] == 5)
            {
                summa += 5;
            }
            if (arvoTaulu[4] == 5)
            {
                summa += 5;
            }
            ViitosetSummaLB.Text = Convert.ToString(summa);
        }


        private void KuutosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 6)
            {
                summa += 6;
            }
            if (arvoTaulu[1] == 6)
            {
                summa += 6;
            }
            if (arvoTaulu[2] == 6)
            {
                summa += 6;
            }
            if (arvoTaulu[3] == 6)
            {
                summa += 6;
            }
            if (arvoTaulu[4] == 6)
            {
                summa += 6;
            }
            KuutosetSummaLB.Text = Convert.ToString(summa);
        }


        private void P2YkkosetBT_Click(object sender, EventArgs e)
        {
            int summa = 0;

            if (arvoTaulu[0] == 1)
            {
                summa++;
            }
            if (arvoTaulu[1] == 1)
            {
                summa++;
            }
            if (arvoTaulu[2] == 1)
            {
                summa++;
            }
            if (arvoTaulu[3] == 1)
            {
                summa++;
            }
            if (arvoTaulu[4] == 1)
            {
                summa++;
            }
            PKaksiYkkösetSummaLB.Text = Convert.ToString(summa);
        }

        private void P2KakkosetBT_Click(object sender, EventArgs e)
        {

        }

        private void P2KolmosetBT_Click(object sender, EventArgs e)
        {

        }

        private void P2NelosetBT_Click(object sender, EventArgs e)
        {

        }

        private void P2ViitosetBT_Click(object sender, EventArgs e)
        {

        }

        private void P2KuutosetBT_Click(object sender, EventArgs e)
        {

        }
    }
}