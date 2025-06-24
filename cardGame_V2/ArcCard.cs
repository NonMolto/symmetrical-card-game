using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cardGame_V2
{
    public partial class frmCardGame : Form
    {
        private Button firstCard = null; 
        private Button secondCard = null;
        private int[] pair = new int[6];

        private Random random = new Random();
        private Button[] btns;

        private Image[] images =
        {
            Properties.Resources.Ia_supernova,
            Properties.Resources.II_P_supernova,
            Properties.Resources.II_unknow_supernova
        };

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
            for (int i = 0; i < 6; i++) pair[i] = i % 3;

            for (int i = 0; i < pair.Length; i++)
           {
                int j = random.Next(pair.Length);
                int temp = pair[i];
                pair[i] = pair[j];
                pair[j] = temp;
           }


           for (int i = 0; i < btns.Length; i++)
           {
                btns[i].BackgroundImage = Properties.Resources.cardBack;
                btns[i].BackgroundImageLayout = ImageLayout.Stretch;
                btns[i].Tag = i;
                btns[i].Enabled = true;
                btns[i].Click -= Card_Click;
                btns[i].Click += Card_Click;
           }

            firstCard = null;
            secondCard = null;
        }


        private void Card_Click(object sender, EventArgs e)
        {
            Button card = (Button)sender;

            if (firstCard != null && secondCard != null)
            return;

            int indice = (int)card.Tag;
            card.BackgroundImage = images[pair[indice]];

            if (firstCard == null)
            {
                firstCard = card;
                return;
            }

            secondCard = card;

            int index1 = (int)firstCard.Tag;
            int index2 = (int)secondCard.Tag;

            if (pair[index1] == pair[index2]) 
            {
                firstCard.Enabled = false;
                secondCard.Enabled = false;
                firstCard = null;
                secondCard = null;

                if (deactivatedCards())
                {
                    MessageBox.Show("You win!");
                    loadGame();
                }
            }
            else
            {
                timer1.Start();
            }
        }

        private bool deactivatedCards()
        {
            foreach (Button btn in btns)
            {
                if (btn.Enabled)
                {
                    return false;
                }
            }
            return true;
        }
        private void frmCardGame_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (firstCard != null)
            {
                firstCard.BackgroundImage = Properties.Resources.cardBack;
            }

            if (secondCard != null)
            {
                secondCard.BackgroundImage = Properties.Resources.cardBack;
            }

            firstCard = null;
            secondCard = null;
        }
    }
}
