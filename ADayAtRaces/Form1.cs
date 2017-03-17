using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtRaces
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[3];
        Greyhound[] greyhounds = new Greyhound[4];
        Random randomizer = new Random();
        public int winner;
 
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++) greyhounds[i] = new Greyhound(pictureBox1.Width,pictureBox1.Left);
            greyhounds[0].greyhoundPicBox = pictureBox2;
            greyhounds[1].greyhoundPicBox = pictureBox3;
            greyhounds[2].greyhoundPicBox = pictureBox4;
            greyhounds[3].greyhoundPicBox = pictureBox5;
            guys[0] = new Guy() { name = "Joe", cashAsset = 75 };
            guys[1] = new Guy() { name = "Bob", cashAsset = 50 };
            guys[2] = new Guy() { name = "Al", cashAsset = 45 };

            minimumBetLabel.Text = "Minimum bet: $5";
            RefreshInfo();
            BetsInfo();
        }

        private void RefreshInfo()
        {
            for (int i = 0; i < 4; i++)
            {
                greyhounds[i].greyhoundPicBox.Left = pictureBox1.Left;
                greyhounds[i].reachTheEnd = false;
               
            }
            joeRadioButton.Text = "Joe has $" + guys[0].cashAsset;
            bobRadioButton.Text = "Bob has $" + guys[1].cashAsset;
            alRadioButton.Text = "Al has $" + guys[2].cashAsset;
            for (int i = 0; i < 3; i++)
                guys[i].stake = 0;
        }
        private void BetsInfo()
        {
            if (guys[0].stake != 0) joeBetLabel.Text = "Joe bets $" + guys[0].stake + " on dog " + guys[0].betOnDog;
            else joeBetLabel.Text = "Joe hasn't place a bet.";
            if (guys[1].stake != 0) bobBetLabel.Text = "Bob bets $" + guys[1].stake + " on dog " + guys[1].betOnDog;
            else bobBetLabel.Text = "Bob hasn't place a bet.";
            if (guys[2].stake != 0) alBetLabel.Text = "Bob bets $" + guys[2].stake + " on dog " + guys[2].betOnDog;
            else alBetLabel.Text = "Bob hasn't place a bet.";
        }
        
        private void EndofTheGame()
        {
            
            timer1.Stop();
            MessageBox.Show("The winner is: " + winner);
            groupBox1.Enabled = true;
            for (int i = 0; i < 3; i++)
            {
                if (guys[i].betOnDog == winner) guys[i].Collect(true);
                else guys[i].Collect(false);
            }
             RefreshInfo();
            BetsInfo();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            groupBox1.Enabled = false;
         }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Al";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                greyhounds[i].dogSpeed = randomizer.Next(4, 7);
                greyhounds[i].Run();
                if (greyhounds[i].reachTheEnd)
                {
                    winner = i+1;
                    EndofTheGame();
                    return;
                 }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<3;i++)
            {
               if( name.Text == guys[i].name)
                {
                    guys[i].PlaceBet(numericUpDown1.Value, numericUpDown2.Value);
                }
            }
            BetsInfo();
        }
    }
}
