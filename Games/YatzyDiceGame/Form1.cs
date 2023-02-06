namespace YatzyDiceGame
{
    public partial class Yatzy : Form
    {
        public Yatzy()
        {
            InitializeComponent();
        }

        private void KaikkiBT_Click(object sender, EventArgs e)
        {
            piirraNoppa(Noppa01PB);
            piirraNoppa(Noppa02PB);
            piirraNoppa(Noppa03PB);
            piirraNoppa(Noppa04PB);
            piirraNoppa(Noppa05PB);
        }
        private void piirraNoppa(PictureBox NoppaBox)
        {
            Random satunnainen = new Random();
            int noppa = satunnainen.Next(1, 7);
            switch (noppa)
            {
                case 1:
                    NoppaBox.Image = Properties.Resources.dice01;
                    break;
                case 2:
                    NoppaBox.Image = Properties.Resources.dice02;
                    break;
                case 3:
                    NoppaBox.Image = Properties.Resources.dice03;
                    break;
                case 4:
                    NoppaBox.Image = Properties.Resources.dice04;
                    break;
                case 5:
                    NoppaBox.Image = Properties.Resources.dice05;
                    break;
                case 6:
                    NoppaBox.Image = Properties.Resources.dice06;
                    break;
            }
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
        }
    }
}