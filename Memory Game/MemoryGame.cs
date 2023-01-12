using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project15
{    
    public partial class MemoryGameWindow : Form
    {
        GameManagement gameManager = new GameManagement();        

        Dictionary<MatrixIndex, FlippableButton> m_ButtonsDictionary = new Dictionary<MatrixIndex, FlippableButton>();

        protected virtual void OnTurnEnded(string PlayerName, int PlayerScore, bool res, int PlayerIndex)
        {
            if (res == true)
            {
                if (PlayerIndex == 0)
                {
                    labelPlayer1.Text = string.Format("{0}: {1} Pairs", PlayerName, PlayerScore);
                }
                else
                {
                    labelPlayer2.Text = string.Format("{0}: {1} Pairs", PlayerName, PlayerScore);
                }
            }
            else
            {
                if (PlayerIndex == 0)
                {
                    labelCurrentPlayerName.Text = gameManager.Players[1].PlayerName;
                    labelCurrentPlayerName.BackColor = labelPlayer2.BackColor;
                    labelCurrentPlayer.BackColor = labelPlayer2.BackColor;
                }
                else
                {
                    labelCurrentPlayerName.Text = gameManager.Players[0].PlayerName;
                    labelCurrentPlayerName.BackColor = labelPlayer1.BackColor;
                    labelCurrentPlayer.BackColor = labelPlayer1.BackColor;
                }
            }
            
           Refresh();  
        }

        public void OnButtonStatusChanged(MatrixIndex index, string Command)
        {
            labelFocus.Focus();
            FlippableButton temp;
            m_ButtonsDictionary.TryGetValue(index, out temp);
           
            if (Command == "Show")
            {
                temp.Exposed = true;
                temp.Text = temp.Value.ToString();
                temp.FlatStyle = FlatStyle.Standard;
                temp.BackColor = labelCurrentPlayer.BackColor;                                         
            }
            else
            {
                if (Command == "Hide")
                {
                    temp.Exposed = false;
                    temp.Text = "";
                    temp.FlatStyle = FlatStyle.System;
                    temp.BackColor = DefaultBackColor;
                }
            }  
            Refresh();
        }

        public void OnGameEnded(Player[] players, int i_Row, int i_Col, int i_WinnerIndex)
        {
            DialogResult dialogResult;

            if (i_WinnerIndex == -1) //draw
            {
                dialogResult = MessageBox.Show(string.Format("It's a draw! Both players got {0} pairs!{1}{1}Would you like to play another game?", players[0].PlayerScore, System.Environment.NewLine), "Game Finished", MessageBoxButtons.YesNo);

            }
            else
            {
                dialogResult = MessageBox.Show(string.Format("{0} is the winner with {1} pairs!{2}{2}Would you like to play another game?", players[i_WinnerIndex].PlayerName, players[i_WinnerIndex].PlayerScore, System.Environment.NewLine), "Game Finished", MessageBoxButtons.YesNo);
            }
           
            this.Dispose();

            if (dialogResult == DialogResult.Yes)
            {
                new MemoryGameWindow(i_Row, i_Col, new List<string>() { players[0].PlayerName, players[1].PlayerName }).ShowDialog();
            }        
        }

        void InitializeGame(int row, int col, List<String> list)
        {
            gameManager.InitiatePlayers(list);
            gameManager.InitiateGameBoard(row, col);

            gameManager.ButtonStatusChanged += OnButtonStatusChanged;
            gameManager.TurnEnded += OnTurnEnded;
            gameManager.GameEnded += OnGameEnded;                                   

            labelPlayer1.Text = string.Format("{0}: {1} Pairs", list[0], gameManager.Players[0].PlayerScore);
            labelPlayer2.Text = string.Format("{0}: {1} Pairs", list[1], gameManager.Players[1].PlayerScore);
            labelCurrentPlayerName.Text = list[0];
            
            InitiateBoard();

            StartGame();
        }

        void StartGame()
        {
            
        }

        public MemoryGameWindow(int row, int col, List<String> list)
        {
            InitializeComponent();            
            InitializeGame(row, col, list);                       
        }

        public void InitiateBoard()
        {
            int left = labelCurrentPlayer.Left;
            int top = 15;

            for (int i = 0; i < gameManager.Board.Rows; i++)
            {
                for (int j = 0; j < gameManager.Board.Cols; j++)
                {
                    FlippableButton button = new FlippableButton(i, j, gameManager.Board.BoardMatrix[i,j]);                   
                    button.ButtonClicked += gameManager.OnButtonClicked;
                    button.AfterButtonClicked += gameManager.OnAfterButtonClicked;
                    this.m_ButtonsDictionary.Add(button.MatrixIndex ,button);


                    button.TabStop = false;
                    button.Height = 65;
                    button.Width = 65;

                    button.Left += left;
                    button.Top += top;

                    left += button.Width + 5;
                    Controls.Add(button);

                    if (i + 1 == gameManager.Board.Rows)
                   {
                        labelCurrentPlayer.Top = button.Top + button.Height + 10;
                        labelCurrentPlayerName.Top = labelCurrentPlayer.Top;

                        labelPlayer1.Top = labelCurrentPlayerName.Top + labelCurrentPlayerName.Height + 10;

                        labelPlayer2.Top = labelPlayer1.Top + labelPlayer1.Height + 10;

                        this.Size = new Size(button.Right+25, labelPlayer2.Top+labelPlayer2.Height+50);
                    }
                }

                left = labelCurrentPlayer.Left;
                top += 70;
            }
        }

        private void MemoryGame_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelCurrentPlayer_Click(object sender, EventArgs e)
        {

        }

        private void labelPlayer2Score_Click(object sender, EventArgs e)
        {

        }

        private void labelPlayerName2_Click(object sender, EventArgs e)
        {

        }       
    }
}
