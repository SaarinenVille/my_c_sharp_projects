using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using YatzyDiceGame.Properties;

namespace YatzyDiceGame
{
    public partial class Yatzy : Form
    {
        // Luodaan noppien silm‰luvuille arvot muuttujiin
        int noppaArvo1, noppaArvo2, noppaArvo3, noppaArvo4, noppaArvo5;
        // Syˆtet‰‰n noppien arvot taulukkoon 
        int[] arvoTaulu = new int[5];
        public Yatzy()
        {

            InitializeComponent();
            ValitutBT.Enabled = false;
        }
        // Tehd‰‰n muuttuja, joka laskee klikkausten m‰‰r‰n. (max. 3 heittoa, jonka j‰lkeen heittobuttonit disabloidaan
        int clickCount = 0;

        // Luodaan metodi Heit‰ kaikki-buttonille
        // Jokaiselle noppa-pictureboxille kutsutaan erikseen samaa Piirr‰Noppa-metodia 
        private void KaikkiBT_Click(object sender, EventArgs e)
        {

            noppaArvo1 = PiirraNoppa(Noppa01PB);
            arvoTaulu[0] = noppaArvo1;
            noppaArvo2 = PiirraNoppa(Noppa02PB);
            arvoTaulu[1] = noppaArvo2;
            noppaArvo3 = PiirraNoppa(Noppa03PB);
            arvoTaulu[2] = noppaArvo3;
            noppaArvo4 = PiirraNoppa(Noppa04PB);
            arvoTaulu[3] = noppaArvo4;
            noppaArvo5 = PiirraNoppa(Noppa05PB);
            arvoTaulu[4] = noppaArvo5;

            // MessageBox.Show(noppaArvo1 + " " + noppaArvo2 + " " + noppaArvo3 + " " + noppaArvo4 + " " + noppaArvo5);

            ValitutBT.Enabled = true;
            clickCount++;

            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;

            }




        }


        // Seuraava metodi generoi jokaiseen pictureboxiin random nopan
        private int PiirraNoppa(PictureBox NoppaBox)
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

        /* Ensimm‰isen heiton j‰lkeen voi heitt‰‰ valitsemansa nopat. T‰ll‰ buttonilla kutsutaan samaa Piirr‰Noppa-metodia kuin aikaisemminkin,
         * mutta vain pictureboxeille, joihin yhdistetty checkbox on checked */


        private void ValitutBT_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                noppaArvo1 = PiirraNoppa(Noppa01PB);
                arvoTaulu[0] = noppaArvo1;
            }
            if (checkBox2.Checked)
            {
                noppaArvo2 = PiirraNoppa(Noppa02PB);
                arvoTaulu[1] = noppaArvo2;
            }
            if (checkBox3.Checked)
            {
                noppaArvo3 = PiirraNoppa(Noppa03PB);
                arvoTaulu[2] = noppaArvo3;
            }
            if (checkBox4.Checked)
            {
                noppaArvo4 = PiirraNoppa(Noppa04PB);
                arvoTaulu[3] = noppaArvo4;
            }
            if (checkBox5.Checked)
            {
                noppaArvo5 = PiirraNoppa(Noppa05PB);
                arvoTaulu[4] = noppaArvo5;
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            clickCount++;
            if (clickCount == 3)
            {
                ValitutBT.Enabled = false;
                KaikkiBT.Enabled = false;
            }
        }


        // Kun  kolme heittoa on heitetty tai vuoro lopetettu, alustetaan pictureboxit alkuper‰iseen muotoon Alusta nopat-buttonilla
        private void AlustaBT_Click(object sender, EventArgs e)
        {
            Noppa01PB.Image = Properties.Resources.rollingDice;
            Noppa02PB.Image = Properties.Resources.rollingDice;
            Noppa03PB.Image = Properties.Resources.rollingDice;
            Noppa04PB.Image = Properties.Resources.rollingDice;
            Noppa05PB.Image = Properties.Resources.rollingDice;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            KaikkiBT.Enabled = true;
            clickCount = 0;

        }


        // Aletaan m‰‰rittelem‰‰n pistetaulukkoa

        //Ensimm‰isen‰ m‰‰ritell‰‰n pisteet ykkˆsten mukaan 

        int summa1 = 0;
        int yhteensa1 = 0;
        private void YkkosetBT_Click(object sender, EventArgs e)
        {
            YkkosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 1)
            {
                summa1++;
            }
            if (arvoTaulu[1] == 1)
            {
                summa1++;
            }
            if (arvoTaulu[2] == 1)
            {
                summa1++;
            }
            if (arvoTaulu[3] == 1)
            {
                summa1++;
            }
            if (arvoTaulu[4] == 1)
            {
                summa1++;
            }
            YkkosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }

        private void KakkosetBT_Click(object sender, EventArgs e)
        {
            KakkosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 2)
            {
                summa1 += 2;
            }
            if (arvoTaulu[1] == 2)
            {
                summa1 += 2;
            }
            if (arvoTaulu[2] == 2)
            {
                summa1 += 2;
            }
            if (arvoTaulu[3] == 2)
            {
                summa1 += 2;
            }
            if (arvoTaulu[4] == 2)
            {
                summa1 += 2;
            }
            KakkosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }


        private void KolmosetBT_Click(object sender, EventArgs e)
        {
            KolmosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 3)
            {
                summa1 += 3;
            }
            if (arvoTaulu[1] == 3)
            {
                summa1 += 3;
            }
            if (arvoTaulu[2] == 3)
            {
                summa1 += 3;
            }
            if (arvoTaulu[3] == 3)
            {
                summa1 += 3;
            }
            if (arvoTaulu[4] == 3)
            {
                summa1 += 3;
            }
            KolmosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }


        private void NelosetBT_Click(object sender, EventArgs e)
        {
            NelosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 4)
            {
                summa1 += 4;
            }
            if (arvoTaulu[1] == 4)
            {
                summa1 += 4;
            }
            if (arvoTaulu[2] == 4)
            {
                summa1 += 4;
            }
            if (arvoTaulu[3] == 4)
            {
                summa1 += 4;
            }
            if (arvoTaulu[4] == 4)
            {
                summa1 += 4;
            }
            NelosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }


        private void ViitosetBT_Click(object sender, EventArgs e)
        {
            ViitosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 5)
            {
                summa1 += 5;
            }
            if (arvoTaulu[1] == 5)
            {
                summa1 += 5;
            }
            if (arvoTaulu[2] == 5)
            {
                summa1 += 5;
            }
            if (arvoTaulu[3] == 5)
            {
                summa1 += 5;
            }
            if (arvoTaulu[4] == 5)
            {
                summa1 += 5;
            }
            ViitosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }


        private void KuutosetBT_Click(object sender, EventArgs e)
        {
            KuutosetSummaLB.Visible = true;
            summa1 = 0;

            if (arvoTaulu[0] == 6)
            {
                summa1 += 6;
            }
            if (arvoTaulu[1] == 6)
            {
                summa1 += 6;
            }
            if (arvoTaulu[2] == 6)
            {
                summa1 += 6;
            }
            if (arvoTaulu[3] == 6)
            {
                summa1 += 6;
            }
            if (arvoTaulu[4] == 6)
            {
                summa1 += 6;
            }
            KuutosetSummaLB.Text = Convert.ToString(summa1);
            yhteensa1 += summa1;
            YhtSum1.Text = Convert.ToString(yhteensa1);
            YhtSum1.Visible = true;
        }

        // 2. pelaajan pisteet

        int summa2;
        int yhteensa2;
        private void P2YkkosetBT_Click(object sender, EventArgs e)
        {
            PKaksiYkkosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 1)
            {
                summa2++;
            }
            if (arvoTaulu[1] == 1)
            {
                summa2++;
            }
            if (arvoTaulu[2] == 1)
            {
                summa2++;
            }
            if (arvoTaulu[3] == 1)
            {
                summa2++;
            }
            if (arvoTaulu[4] == 1)
            {
                summa2++;
            }
            PKaksiYkkosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }

        private void P2KakkosetBT_Click(object sender, EventArgs e)
        {
            PKaksiKakkosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 2)
            {
                summa2 += 2;
            }
            if (arvoTaulu[1] == 2)
            {
                summa2 += 2;
            }
            if (arvoTaulu[2] == 2)
            {
                summa2 += 2;
            }
            if (arvoTaulu[3] == 2)
            {
                summa2 += 2;
            }
            if (arvoTaulu[4] == 2)
            {
                summa2 += 2;
            }
            PKaksiKakkosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }

        private void P2KolmosetBT_Click(object sender, EventArgs e)
        {
            PKaksiKolmosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 3)
            {
                summa2 += 3;
            }
            if (arvoTaulu[1] == 3)
            {
                summa2 += 3;
            }
            if (arvoTaulu[2] == 3)
            {
                summa2 += 3;
            }
            if (arvoTaulu[3] == 3)
            {
                summa2 += 3;
            }
            if (arvoTaulu[4] == 3)
            {
                summa2 += 3;
            }
            PKaksiKolmosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }

        private void P2NelosetBT_Click(object sender, EventArgs e)
        {
            PKaksiNelosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 4)
            {
                summa2 += 4;
            }
            if (arvoTaulu[1] == 4)
            {
                summa2 += 4;
            }
            if (arvoTaulu[2] == 4)
            {
                summa2 += 4;
            }
            if (arvoTaulu[3] == 4)
            {
                summa2 += 4;
            }
            if (arvoTaulu[4] == 4)
            {
                summa2 += 4;
            }
            PKaksiNelosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }

        private void P2ViitosetBT_Click(object sender, EventArgs e)
        {
            PKaksiViitosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 5)
            {
                summa2 += 5;
            }
            if (arvoTaulu[1] == 5)
            {
                summa2 += 5;
            }
            if (arvoTaulu[2] == 5)
            {
                summa2 += 5;
            }
            if (arvoTaulu[3] == 5)
            {
                summa2 += 5;
            }
            if (arvoTaulu[4] == 5)
            {
                summa2 += 5;
            }
            PKaksiViitosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }

        private void P2KuutosetBT_Click(object sender, EventArgs e)
        {
            PKaksiKuutosetSummaLB.Visible = true;
            summa2 = 0;

            if (arvoTaulu[0] == 6)
            {
                summa2 += 6;
            }
            if (arvoTaulu[1] == 6)
            {
                summa2 += 6;
            }
            if (arvoTaulu[2] == 6)
            {
                summa2 += 6;
            }
            if (arvoTaulu[3] == 6)
            {
                summa2 += 6;
            }
            if (arvoTaulu[4] == 6)
            {
                summa2 += 6;
            }
            PKaksiKuutosetSummaLB.Text = Convert.ToString(summa2);
            yhteensa2 += summa2;
            YhtSum2.Text = Convert.ToString(yhteensa2);
            YhtSum2.Visible = true;
        }
        private void Noppa01PB_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
            }
            else if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }
    }
}