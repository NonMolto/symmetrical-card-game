using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cardGame_V2
{
    public partial class frmCardGame : Form
    {
        private Button? firstCard = null; // Need to be nullable to allow for no selection | Language Version 8.0 or higher
        private Button? secondCard = null; // Need to be nullable to allow for no selection | Language Version 8.0 or higher
        private Random random = new Random();

        private Image[] images = new Image[6];
        private Button[] btns;

        public frmCardGame()
        {
            InitializeComponent();
            btns = new Button[]
            {
                btnCard1, btnCard2, btnCard3, btnCard4, btnCard5, btnCard6
            };
            loadGame();
        }

        private void loadGame()
        {
            // images[0] = Properties.Resources.card1;
            // images[1] = Properties.Resources.card2;
            // images[2] = Properties.Resources.card3;
            // images[3] = Properties.Resources.card4;
            // images[4] = Properties.Resources.card5;
            // images[5] = Properties.Resources.card6;

           for (int i = 0; i < images.Length; i++)
           {
                int j = random.Next(images.Length);
                Image temp = images[i];
                images[i] = images[j];
                images[j] = temp;
           }


           for (int i = 0; i < btns.Length; i++)
           {
                // Need the icon bnts[i].BackgroundImage = Properties.Resources.cardBack;
                btns[i].BackgroundImageLayout = ImageLayout.Stretch;
                btns[i].Tag = images[i];
                btns[i].Enabled = true;
                btns[i].Click += Card_Click;
           }

            firstCard = null;
            secondCard = null;
        }

        private void Card_Click(object sender, EventArgs e)
        {

        }
    }
}
