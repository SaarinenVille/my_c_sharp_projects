using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using YatzyDiceGame.Properties;

namespace YatzyDiceGame
{

    public partial class YatzyForm : Form
    {

        // Luodaan noppien silm‰lukujen arvoille muuttujat
        int noppaArvo1, noppaArvo2, noppaArvo3, noppaArvo4, noppaArvo5;
        // Luodaan arvoTaulu ja loppuTulos-taulukot, joihin tullaan syˆtt‰m‰‰n noppien arvot
        int[] arvoTaulu = new int[5];
        int[] loppuTulos = new int[5];
        public YatzyForm()
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
            Array.Clear(arvoTaulu);
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

            HoldIcon1.Visible = false;
            HoldIcon2.Visible = false;
            HoldIcon3.Visible = false;
            HoldIcon4.Visible = false;
            HoldIcon5.Visible = false;

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

        }  
               
        // 1. pelaajan pisteet
        // Luodaan jokaiselle pistesarakkeen buttonille oma metodi, jossa kutsutaan laskuToimitus()- funktiota
        // Poikkeuksena yatzy, jonka tulos on fixed 50
        private void YkkosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for(int i = 0; i < arvoTaulu.Length; i++) 
            {
                if (arvoTaulu[i] == 1)
                {
                    summa += arvoTaulu[i];
                    YkkosetSummaLB.Text = Convert.ToString(summa);
                    YkkosetSummaLB.Visible = true;
                    YkkosetBT.Enabled = false;
                    YkkosetBT.BackColor= Color.OliveDrab;
                }
            }

            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            
            
            /*
            Toinen tapa, jolla kutsutaan erillist‰ laskutoimitus-metodia
            LaskuToimitus();
            YkkosetSummaLB.Text = Convert.ToString(summa);
            YkkosetSummaLB.Visible = true;
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            YkkosetBT.Enabled = false;              
            */
        }
        private void KakkosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[i] == 2)
                {
                    summa+=arvoTaulu[i];
                    KakkosetSummaLB.Text = Convert.ToString(summa);
                    KakkosetSummaLB.Visible = true;
                    KakkosetBT.Enabled = false;
                    KakkosetBT.BackColor= Color.OliveDrab;
                }
            }
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void KolmosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[i] == 3)
                {
                    summa+=arvoTaulu[i];
                    KolmosetSummaLB.Text = Convert.ToString(summa);
                    KolmosetSummaLB.Visible = true;
                    KolmosetBT.Enabled = false;
                    KolmosetBT.BackColor= Color.OliveDrab;
                }
            }
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void NelosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[i] == 4)
                {
                    summa += arvoTaulu[i];
                    NelosetSummaLB.Text = Convert.ToString(summa);
                    NelosetSummaLB.Visible = true;
                    NelosetBT.Enabled = false;
                    NelosetBT.BackColor= Color.OliveDrab;
                }
            }
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void ViitosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[i] == 5)
                {
                    summa += arvoTaulu[i];
                    ViitosetSummaLB.Text = Convert.ToString(summa);
                    ViitosetSummaLB.Visible = true;
                    ViitosetBT.Enabled = false;
                    ViitosetBT.BackColor= Color.OliveDrab;
                }
            }
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void KuutosetBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[i] == 6)
                {
                    summa+=arvoTaulu[i];
                    KuutosetSummaLB.Text = Convert.ToString(summa);
                    KuutosetSummaLB.Visible = true;
                    KuutosetBT.Enabled = false;
                    KuutosetBT.BackColor = Color.OliveDrab;
                }
            }
            yhteensaYla += summa;
            YhtSumYlaLB.Text = Convert.ToString(yhteensaYla);
            YhtSumYlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void YksiPariBT_Click(object sender, EventArgs e)
        {
            Array.Sort(arvoTaulu);
            int pari1 = 0;
            int pari2 = 0;
            summa = 0;
            for (int i = 0; i < 4; i++)
            {
                if (arvoTaulu[i] == arvoTaulu[i + 1])
                {
                    if (pari1 == 0)
                    {
                        pari1 = arvoTaulu[i];
                    }

                    else
                    {
                        pari2 = arvoTaulu[i];
                    }
                    i++;
                }
            }
            if(pari1 > pari2)
            {
                summa += pari1 * 2;
                YksiPariLB.Text = Convert.ToString(summa);
                YksiPariLB.Visible = true;
                YksiPariBT.Enabled = false;
                YksiPariBT.BackColor = Color.OliveDrab;
            }
            else if (pari2 > pari1)
            {
                summa += pari2 * 2;
                YksiPariLB.Text = Convert.ToString(summa);
                YksiPariLB.Visible = true;
                YksiPariBT.Enabled = false;
                YkkosetBT.BackColor = Color.Green;
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void KaksiPariaBT_Click(object sender, EventArgs e)
        {
            Array.Sort(arvoTaulu);
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length - 1; i++)
            {
                for (int j = i + 1; j < arvoTaulu.Length; j++)
                {
                    if (arvoTaulu[i] == arvoTaulu[j])
                    {
                        for (int k = j + 1; k < arvoTaulu.Length - 1; k++)
                        {
                            for (int l = k + 1; l < arvoTaulu.Length; l++)
                            {
                                if (arvoTaulu[k] == arvoTaulu[l]) 
                                {
                                    summa += arvoTaulu[j] * 2 + arvoTaulu[l] * 2;
                                    KaksiPariaLB.Text = Convert.ToString(summa);
                                    KaksiPariaLB.Visible = true;
                                    KaksiPariaBT.Enabled = false;
                                    KaksiPariaBT.BackColor = Color.OliveDrab;
                                }
                            }
                        }

                    }
                }
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void KolmoslukuBT_Click(object sender, EventArgs e)
        {
            Array.Sort(arvoTaulu);
            int kolmoset = 0;
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                for (int j = i + 1; j < arvoTaulu.Length; j++)
                {
                   if (arvoTaulu[i] == arvoTaulu[j])
                    {
                        kolmoset++;
                        if(kolmoset == 3)
                        {
                            summa += arvoTaulu[j] * 3;
                            KolmoslukuLB.Text = Convert.ToString(summa);
                            KolmoslukuLB.Visible = true;
                            KolmoslukuBT.Enabled = false;
                            KolmoslukuBT.BackColor = Color.OliveDrab;
                        }
                    }
                }
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void NeloslukuBT_Click(object sender, EventArgs e)
        {
            Array.Sort(arvoTaulu);
            int neloset = 0;
            summa = 0;
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                for (int j = i + 1; j < arvoTaulu.Length; j++)
                {
                    if (arvoTaulu[i] == arvoTaulu[j])
                    {
                        neloset++;
                        if (neloset == 4)
                        {
                            summa += arvoTaulu[j] * 4;
                            NeloslukuLB.Text = Convert.ToString(summa);
                            NeloslukuLB.Visible = true;
                            NeloslukuBT.Enabled = false;
                            NeloslukuBT.BackColor = Color.OliveDrab;
                        }
                    }
                }
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }



        private void PsuoraBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            Array.Sort(arvoTaulu);
            for (int i = 0; i < arvoTaulu.Length; i++) 
            { 
                if (arvoTaulu[0] == 1 && arvoTaulu[1] == 2 && arvoTaulu[2] == 3 && arvoTaulu[3] == 4 && arvoTaulu[4] == 5)
                {
                    summa += arvoTaulu[i];
                    PSuoraLB.Text = Convert.ToString(summa);
                    PSuoraLB.Visible = true;
                    PsuoraBT.Enabled = false;
                    PsuoraBT.BackColor = Color.OliveDrab;
                }
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void IsuoraBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            Array.Sort(arvoTaulu);
            for (int i = 0; i < arvoTaulu.Length; i++)
            {
                if (arvoTaulu[0] == 2 && arvoTaulu[1] == 3 && arvoTaulu[2] == 4 && arvoTaulu[3] == 5 && arvoTaulu[4] == 6)
                {
                    summa += arvoTaulu[i];
                    IsuoraLB.Text = Convert.ToString(summa);
                    IsuoraLB.Visible = true;
                    IsuoraBT.Enabled = false;
                    IsuoraBT.BackColor = Color.OliveDrab;
                }
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }

        private void TayskasiBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            Array.Sort(arvoTaulu);
            if ((arvoTaulu[0] == arvoTaulu[1] && arvoTaulu[1] == arvoTaulu[2] && arvoTaulu[3] == arvoTaulu[4]) ||
                (arvoTaulu[0] == arvoTaulu[1] && arvoTaulu[2] == arvoTaulu[3] && arvoTaulu[3] == arvoTaulu[4]))
            {
                summa += arvoTaulu[0] + arvoTaulu[1] + arvoTaulu[2] + arvoTaulu[3] + arvoTaulu[4];
                TayskasiLB.Text = Convert.ToString(summa);
                TayskasiLB.Visible = true;
                TayskasiBT.Enabled = false;
                TayskasiBT.BackColor = Color.OliveDrab;
            }
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
        }
        

        private void SattumaBT_Click(object sender, EventArgs e)
        {
            summa = 0;
            summa += arvoTaulu[0] + arvoTaulu[1] + arvoTaulu[2] + arvoTaulu[3] + arvoTaulu[4];
            SattumaLB.Text = Convert.ToString(summa);
            SattumaLB.Visible = true;
            yhteensaAla += summa;
            YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
            YhtSumAlaLB.Visible = true;
            kaikenSumma += summa;
            KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
            SattumaBT.Enabled = false;
            SattumaBT.BackColor = Color.OliveDrab;
        }

        private void YatzyBT_Click(object sender, EventArgs e)
        {
            if (arvoTaulu[0] == arvoTaulu[1] && arvoTaulu[0] == arvoTaulu[2] && arvoTaulu[0] == arvoTaulu[3] && arvoTaulu[0] == arvoTaulu[4])
            {
                YatzyLB.Text = Convert.ToString(yatzy);
                YatzyLB.Visible = true;
                yhteensaAla += yatzy;
                YhtSumAlaLB.Text = Convert.ToString(yhteensaAla);
                YhtSumAlaLB.Visible = true;
                kaikenSumma += yatzy;
                KaikenSummaLB.Text = Convert.ToString(kaikenSumma);
                YatzyBT.Enabled = false;
                YatzyBT.BackColor = Color.OliveDrab;
            }
        }

        // 2. pelaajan pisteet


        private void Ykkoset2BT_Click(object sender, EventArgs e)
        {
            /*
            LaskuToimitus();
            YkkosetSumma2LB.Text = Convert.ToString(summa2);
            YkkosetSumma2LB.Visible = true;
            yhteensaYla2 += summa2;
            YhtSumYla2LB.Text = Convert.ToString(yhteensaYla2);
            YhtSumYla2LB.Visible = true;
            kaikenSumma2 += summa2;
            KaikenSumma2LB.Text = Convert.ToString(kaikenSumma2);
            Ykkoset2BT.Enabled = false;
            */
        }

        private void Kakkoset2BT_Click(object sender, EventArgs e)
        {

        }

        private void Kolmoset2BT_Click(object sender, EventArgs e)
        {

        }

        private void Neloset2BT_Click(object sender, EventArgs e)
        {

        }

        private void Viitoset2BT_Click(object sender, EventArgs e)
        {

        }

        private void Kuutoset2BT_Click(object sender, EventArgs e)
        {

        }

        // 2. pelaaja Alaosan pisteet
        private void YksiPari2BT_Click(object sender, EventArgs e)
        {

        }

        private void KaksiParia2BT_Click(object sender, EventArgs e)
        {

        }

        private void Kolmosluku2BT_Click(object sender, EventArgs e)
        {

        }

        private void Nelosluku2BT_Click(object sender, EventArgs e)
        {

        }

        private void PSuora2BT_Click(object sender, EventArgs e)
        {

        }

        private void ISuora2BT_Click(object sender, EventArgs e)
        {

        }

        private void Tayskasi2BT_Click(object sender, EventArgs e)
        {

        }

        private void Sattuma2BT_Click(object sender, EventArgs e)
        {

        }

        private void Yatzy2BT_Click(object sender, EventArgs e)
        {

        }
                
        // Laitetaan nopille klikkausominaisuus(noppaa klikatessa checkboxin chekkaus vaihtuu 
             
        private void Noppa01PB_Click(object sender, EventArgs e)
        {
            

            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                HoldIcon1.Visible = true;
            }
            else
            {
                checkBox1.Checked = false;
                HoldIcon1.Visible = false;
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
                HoldIcon2.Visible = true;
            }
            else
            {
                checkBox2.Checked = false;
                HoldIcon2.Visible = false;
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
                HoldIcon3.Visible = true;
            }
            else
            {
                checkBox3.Checked = false;
                HoldIcon3.Visible = false;
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
                HoldIcon4.Visible = true;
            }
            else
            {
                checkBox4.Checked = false;
                HoldIcon4.Visible = false;
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
                HoldIcon5.Visible = true;
            }
            else
            {
                checkBox5.Checked = false;
                HoldIcon5.Visible = false;
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
            Ohjeet frm2 = new Ohjeet();
            frm2.Show();
        }

        private void Yatzy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}