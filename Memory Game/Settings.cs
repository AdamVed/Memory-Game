using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15
{
    public partial class Settings : Form
    {        

        public Settings()
        {
            InitializeComponent();
            //Adam is defaulted for testing
            textBoxFirstPlayerName.Text = "Player 1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAgainst_Click(object sender, EventArgs e)
        {
            if (buttonAgainst.Text == "Against a Friend")
            {
                textBoxSecondPlayerName.Enabled = true;
                textBoxSecondPlayerName.Text = "Player 2";
                buttonAgainst.Text = "Against Computer";
            }
            else
            {
                if (buttonAgainst.Text == "Against Computer")
                {
                    textBoxSecondPlayerName.Enabled = false;
                    textBoxSecondPlayerName.Text = "-computer-";
                    buttonAgainst.Text = "Against a Friend";
                }
            }                     
        }

        private void textBoxSecondPlayerName_TextChanged(object sender, EventArgs e)
        {           
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            int row = int.Parse(buttonBoardSize.Text[0].ToString());
            int col = int.Parse(buttonBoardSize.Text[4].ToString());
            bool isOk = false;

            while (isOk == false)
            {
                if (col < 6)
                {
                    col++;
                }
                else
                {
                    if (row < 6)
                    {
                        row++;
                        col = 4;
                    }
                    else
                    {
                        if (row == 6 && col == 6)
                        {
                            row = 4;
                            col = 4;
                        }
                    }
                }

                if (row % 2 == 0 || col % 2 == 0)
                    isOk = true;
            }                                
            buttonBoardSize.Text = string.Format("{0} x {1}", row, col);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int row = int.Parse(buttonBoardSize.Text[0].ToString());
            int col = int.Parse(buttonBoardSize.Text[4].ToString());
            string FirstPlayerName = textBoxFirstPlayerName.Text;
            string SecondPlayerName = textBoxSecondPlayerName.Text;

            this.Dispose(); //closing the Settings window 

            if (buttonAgainst.Text == "Against a Friend")
            {
                new MemoryGameWindow(row, col, new List<string>() { FirstPlayerName, "Computer" }).ShowDialog();
            }
            else
            {
                new MemoryGameWindow(row, col, new List<string>() { FirstPlayerName, SecondPlayerName}).ShowDialog();
            }
        }
    }
}
