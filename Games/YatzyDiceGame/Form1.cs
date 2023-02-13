using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using YatzyDiceGame.Properties;

namespace YatzyDiceGame
{    
    public partial class Yatzy : Form
    {
                
        // Luodaan noppien silm‰luvukujen arvoille muuttujat
        int noppaArvo1, noppaArvo2, noppaArvo3, noppaArvo4, noppaArvo5;
        // Luodaan arvoTaulu ja loppuTulos-taulukot, joihin tullaan syˆtt‰m‰‰n noppien arvot
        int[] arvoTaulu = new int[5];
        int[] loppuTulos = new int[5];
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

            clickCount++;
          
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;

            }
        }

        /* Ensimm‰isen heiton j‰lkeen voi heitt‰‰ valitsemansa nopat. T‰ll‰ buttonilla kutsutaan samaa Piirr‰Noppa-metodia kuin aikaisemminkin,
         * mutta vain pictureboxeille, joihin yhdistetty checkbox on checked */


        private void ValitutBT_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                noppaArvo1 = PiirraNoppa(Noppa01PB);
                arvoTaulu[0] = noppaArvo1;

            }
            if (checkBox2.Checked == false)
            {
                noppaArvo2 = PiirraNoppa(Noppa02PB);
                arvoTaulu[1] = noppaArvo2;
            }
            if (checkBox3.Checked == false)
            {
                noppaArvo3 = PiirraNoppa(Noppa03PB);
                arvoTaulu[2] = noppaArvo3;
            }
            if (checkBox4.Checked == false)
            {
                noppaArvo4 = PiirraNoppa(Noppa04PB);
                arvoTaulu[3] = noppaArvo4;
            }
            if (checkBox5.Checked == false)
            {
                noppaArvo5 = PiirraNoppa(Noppa05PB);
                arvoTaulu[4] = noppaArvo5;
            }

            clickCount++;
            if (clickCount == 3)
            {
                ValitutBT.Enabled = false;
                KaikkiBT.Enabled = false;
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
                    
                case 2:
                    NoppaBox.Image = Properties.Resources.dice02;
                    return 2;
                    
                case 3:
                    NoppaBox.Image = Properties.Resources.dice03;
                    return 3;
                    
                case 4:
                    NoppaBox.Image = Properties.Resources.dice04;
                    return 4;
                   
                case 5:
                    NoppaBox.Image = Properties.Resources.dice05;
                    return 5;
                    
                case 6:
                    NoppaBox.Image = Properties.Resources.dice06;
                    return 6;
                    
                default:
                    return 0;
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
            ValitutBT.Enabled = false;
            clickCount = 0;
        }

        // Aletaan m‰‰rittelem‰‰n pistetaulukkoa //

        /* M‰‰ritet‰‰n muuttujat:
         - summa-muuttuja, johon tallennetaan noppien yhteistulos kullakin heittovuorolla
         - muuttujat yl‰- ja alasarakkeiden yhteistulokselle
         - muuttuja kokonaispisteille
         - yatzylle oma muuttuja, koska tulos on fixed
        */

        int summa = 0;
        int summa2 = 0;
        int yhteensaYla = 0;
        int yhteensaAla = 0;
        int yhteensaYla2 = 0;
        int yhteensaAla2 = 0;
        int kaikenSumma = 0;
        int kaikenSumma2 = 0;
        int yatzy = 50;
        private void LaskuToimitus()
        {
            if (checkBox1.Checked)
            {
                loppuTulos[0] = noppaArvo1;
            }
            if (checkBox2.Checked)
            {
                loppuTulos[1] = noppaArvo2;
            }
            if (checkBox3.Checked)
            {
                loppuTulos[2] = noppaArvo3;
            }
            if (checkBox4.Checked)
            {
                loppuTulos[3] = noppaArvo4;
            }
            if (checkBox5.Checked)
            {
                loppuTulos[4] = noppaArvo5;
            }

            summa = loppuTulos[0] + loppuTulos[1] + loppuTulos[2] + loppuTulos[3] + loppuTulos[4];
            summa2 = loppuTulos[0] + loppuTulos[1] + loppuTulos[2] + loppuTulos[3] + loppuTulos[4];
            Array.Clear(loppuTulos);
            
        }              
        
        // 1. pelaajan pisteet
        // Luodaan jokaiselle pistesarakkeen buttonille oma metodi, jossa kutsutaan laskuToimitus()- funktiota
        // Poikkeuksena yatzy, jonka tulos on fixed 50
        private void YkkosetBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            YkkosetSummaLB.Text = Convert.ToString(summa);
            YkkosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            YkkosetBT.Enabled = false;                       
        }

        private void KakkosetBT_Click(object sender, EventArgs e)
        {
            
            LaskuToimitus();
            KakkosetSummaLB.Text = Convert.ToString(summa);
            KakkosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            KakkosetBT.Enabled = false;
        }


        private void KolmosetBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KolmosetSummaLB.Text = Convert.ToString(summa);
            KolmosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            KolmosetBT.Enabled = false;
        }


        private void NelosetBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            NelosetSummaLB.Text = Convert.ToString(summa);
            NelosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            NelosetBT.Enabled = false;
        }


        private void ViitosetBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            ViitosetSummaLB.Text = Convert.ToString(summa);
            ViitosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            ViitosetBT.Enabled = false;
        }


        private void KuutosetBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KuutosetSummaLB.Text = Convert.ToString(summa);
            KuutosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            KuutosetBT.Enabled = false;
        }

        private void YksiPariBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            YksiPariLB.Text = Convert.ToString(summa);
            YksiPariLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            YksiPariBT.Enabled = false;
        }

        private void KaksiPariaBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KaksiPariaLB.Text = Convert.ToString(summa);
            KaksiPariaLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            KaksiPariaBT.Enabled = false;
        }

        private void KolmoslukuBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KolmoslukuLB.Text = Convert.ToString(summa);
            KolmoslukuLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            KolmoslukuBT.Enabled = false;
        }

        private void NeloslukuBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            NeloslukuLB.Text = Convert.ToString(summa);
            NeloslukuLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            NeloslukuBT.Enabled = false;
        }



        private void PsuoraBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            PSuoraLB.Text = Convert.ToString(summa);
            PSuoraLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            PsuoraBT.Enabled = false;
        }

        private void IsuoraBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            IsuoraLB.Text = Convert.ToString(summa);
            IsuoraLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            IsuoraBT.Enabled = false;
        }

        private void TayskasiBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            TayskasiLB.Text = Convert.ToString(summa);
            TayskasiLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            TayskasiBT.Enabled = false;
        }
        

        private void SattumaBT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            SattumaLB.Text = Convert.ToString(summa);
            SattumaLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            SattumaBT.Enabled = false;
        }

        private void YatzyBT_Click(object sender, EventArgs e)
        {
            YatzyLB.Text = Convert.ToString(yatzy);
            YatzyLB.Visible = true;
            yhteensaAla += yatzy;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += yatzy;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            YatzyBT.Enabled = false;
        }

        // 2. pelaajan pisteet


        private void Ykkoset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            YkkosetSumma2LB.Text = Convert.ToString(summa2);
            YkkosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Ykkoset2BT.Enabled = false;
        }

        private void Kakkoset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KakkosetSumma2LB.Text = Convert.ToString(summa2);
            KakkosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
        }

        private void Kolmoset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KolmosetSumma2LB.Text = Convert.ToString(summa2);
            KolmosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
        }

        private void Neloset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            NelosetSumma2LB.Text = Convert.ToString(summa2);
            NelosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
        }

        private void Viitoset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            ViitosetSumma2LB.Text = Convert.ToString(summa2);
            ViitosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
        }

        private void Kuutoset2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KuutosetSumma2LB.Text = Convert.ToString(summa2);
            KuutosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
        }

        // 2. pelaaja Alaosan pisteet
        private void YksiPari2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            YksiPari2LB.Text = Convert.ToString(summa2);
            YksiPari2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            YksiPari2BT.Enabled = false;
        }

        private void KaksiParia2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            KaksiParia2LB.Text = Convert.ToString(summa2);
            KaksiParia2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            KaksiParia2BT.Enabled = false;
        }

        private void Kolmosluku2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            Kolmosluku2LB.Text = Convert.ToString(summa2);
            Kolmosluku2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Kolmosluku2BT.Enabled = false;
        }

        private void Nelosluku2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            Nelosluku2LB.Text = Convert.ToString(summa2);
            Nelosluku2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Nelosluku2BT.Enabled = false;
        }

        private void PSuora2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            PSuora2LB.Text = Convert.ToString(summa2);
            PSuora2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            PSuora2BT.Enabled = false;
        }

        private void ISuora2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            ISuora2LB.Text = Convert.ToString(summa2);
            ISuora2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            ISuora2BT.Enabled = false;
        }

        private void Tayskasi2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            Tayskasi2LB.Text = Convert.ToString(summa2);
            Tayskasi2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Tayskasi2BT.Enabled = false;
        }

        private void Sattuma2BT_Click(object sender, EventArgs e)
        {
            LaskuToimitus();
            Sattuma2LB.Text = Convert.ToString(summa2);
            Sattuma2LB.Visible = true;
            yhteensaAla2 += summa2;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Sattuma2BT.Enabled = false;
        }

        private void Yatzy2BT_Click(object sender, EventArgs e)
        {
            Yatzy2LB.Text = Convert.ToString(yatzy);
            Yatzy2LB.Visible = true;
            yhteensaAla2 += yatzy;
            YhtSumAla2LB.Text = Convert.ToString(yhteensaAla2);
            YhtSumAla2LB.Visible = true;
            kaikenSumma2 += yatzy;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Yatzy2BT.Enabled = false;
        }





        /*
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
        */


        // Laitetaan nopille klikkausominaisuus(noppaa klikatessa checkboxin chekkaus vaihtuu 

        private void Noppa01PB_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = true;
            }
            else if (checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false)
            {
                KaikkiBT.Enabled = true;
                ValitutBT.Enabled = false;
            }
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
            }
        }

        private void Noppa02PB_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = true;
            }
            else if (checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false)
            {
                KaikkiBT.Enabled = true;
                ValitutBT.Enabled = false;
            }
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
            }
        }

        private void Noppa03PB_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = true;
            }
            else if (checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false)
            {
                KaikkiBT.Enabled = true;
                ValitutBT.Enabled = false;
            }
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
            }
        }

        private void Noppa04PB_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = true;
            }
            else if (checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false)
            {
                KaikkiBT.Enabled = true;
                ValitutBT.Enabled = false;
            }
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
            }
        }

        private void Noppa05PB_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = true;
            }
            else if (checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false && checkBox1.Checked == false)
            {
                KaikkiBT.Enabled = true;
                ValitutBT.Enabled = false;
            }
            if (clickCount == 3)
            {
                KaikkiBT.Enabled = false;
                ValitutBT.Enabled = false;
            }
        }

        private void UusiBT_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void OhjeetBT_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}