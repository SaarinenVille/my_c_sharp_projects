using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YatzyDiceGame
{
    public partial class AloitusForm : Form
    {
        public AloitusForm()
        {
            InitializeComponent();
        }

        private void ALoitaPeliBT_Click(object sender, EventArgs e)
        {
            YatzyForm frm1 = new YatzyForm();
            frm1.Show();
            this.Hide();
        }
    }
}
