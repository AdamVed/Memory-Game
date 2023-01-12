namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Timers;

    public class GameManagement
    {
        ////attributes
        private Player[] m_Players;
        private Board m_Board;
        private List<Move> m_MovesList = new List<Move>();
        private int m_IndexOfCurrentPlayer = 0;
        private bool isGameEnded = false;

        ////events
        public event Action<MatrixIndex, string> ButtonStatusChanged;

        public event Action<string, int, bool, int> TurnEnded;

        public event Action<Player[], int, int, int> GameEnded;

        ////properties
        public Board Board
        {
            get
            {
                return this.m_Board;
            }

            set
            {
                this.m_Board = value;
            }
        }

        public Player[] Players
        {
            get
            {
                return this.m_Players;
            }

            set
            {
                this.m_Players = value;
            }
        }

        ////subscriptions provided by the class
        protected virtual void OnButtonStatusChanged(MatrixIndex i_Index, string i_Command)
        {
            if (ButtonStatusChanged != null)
            {
                ButtonStatusChanged.Invoke(i_Index, i_Command);
            }
        }    

        protected virtual void OnTurnEnded(string i_PlayerName, int i_PlayerScore, bool i_Res)
        {
            if (TurnEnded != null)
            {
                TurnEnded.Invoke(i_PlayerName, i_PlayerScore, i_Res, m_IndexOfCurrentPlayer);
            }
        }

        public void OnGameEnded(int i_WinnerIndex)
        {        
            if (GameEnded != null)
            {
                if (Players[0].PlayerScore == Players[1].PlayerScore)
                {
                    i_WinnerIndex = -1;
                }
                GameEnded.Invoke(Players, Board.Rows, Board.Cols, i_WinnerIndex);
            }
        }   

        ////methods subscribed to other events
        public void OnButtonClicked(ButtonClickedArgs i_E)
        {
            HumanPlayerMove(i_E.Index);
        }    

        public void OnAfterButtonClicked()
        {
            if (m_MovesList.Count > 1)
            {
                System.Threading.Thread.Sleep(1000);
                MoveListFull(m_IndexOfCurrentPlayer);
            }
        }
    
        ////other methods      
        public void HumanPlayerMove(MatrixIndex i_Index)
        {
            string oldFormatMove = ToOldFormat(i_Index.Row, i_Index.Col);

            Board.ExposedCardsMatrix[i_Index.Row, i_Index.Col] = true;

            m_MovesList.Add(new Move(new MatrixIndex(i_Index.Row, i_Index.Col)));
            Board.Lists.LegitMovesList.Remove(oldFormatMove);
            OnButtonStatusChanged(new MatrixIndex(i_Index.Row, i_Index.Col), "Show");
        }    

        public void ComputerPlayerMove(out string o_Card1)
        {
            ////The computer first checks if it's possible to choose from a smaller list of choices (New List = Legit Moves - Last Moves)
            if (this.Board.Lists.LastTwoMovesList.Count > 0 && this.Board.Lists.LegitMovesList.Count > this.Board.Lists.LastTwoMovesList.Count)
            {
                o_Card1 = this.Board.Lists.GetRandItemFromList(this.Board.Lists.List1WithoutList2(this.Board.Lists.LegitMovesList, this.Board.Lists.LastTwoMovesList));
            }
            else
            {
                ////if the Last Moves list is empty or equal in size to the Legit Move list, then pick a random card
                o_Card1 = this.Board.Lists.GetRandItemFromList(this.Board.Lists.LegitMovesList);
            }

            this.Board.Lists.LegitMovesList.Remove(o_Card1);
            this.Board.ExposeCard(o_Card1);
        } ////move 1    

        public void ComputerPlayerMove(out string o_Card2, string i_Card1)
        {
            char valueOfCardOne;
            bool isFoundMatchingCard = false;

            valueOfCardOne = this.Board.CardStrToChar(i_Card1);

            o_Card2 = this.Board.Lists.GetRandItemFromList(this.Board.Lists.LegitMovesList);

            for (int i = 0; i < this.Board.Lists.LastTwoMovesList.Count; i++)
            {
                ////if there is a matching card in the LastMoves list then the computer chooses it
                if (i_Card1.Equals(this.Board.Lists.LastTwoMovesList[i]) == false && this.Board.CardStrToChar(this.Board.Lists.LastTwoMovesList[i]).Equals(valueOfCardOne) == true)
                {
                    o_Card2 = this.Board.Lists.LastTwoMovesList[i];
                    this.Board.Lists.LastTwoMovesList.Remove(o_Card2);
                    isFoundMatchingCard = true;
                    this.Board.ExposeCard(o_Card2);
                    break;
                }
            }

            if (isFoundMatchingCard == false)
            {
                ////if there isn't a matching card, pick a new random one (and try to avoid last used cards if possible)
                this.ComputerPlayerMove(out o_Card2);
            }
        } ////move 2 

        public void ComputerTurn()
        {
            string chosencard1, chosencard2;
            int row1, col1, row2, col2;

            ComputerPlayerMove(out chosencard1);

            row1 = int.Parse(chosencard1[1].ToString()) - 1;
            col1 = chosencard1[0] - 'A';

            m_MovesList.Add(new Move(new MatrixIndex(row1, col1)));
            OnButtonStatusChanged(new MatrixIndex(row1, col1), "Show");

            System.Threading.Thread.Sleep(1000);

            ComputerPlayerMove(out chosencard2, chosencard1);

            row2 = int.Parse(chosencard2[1].ToString()) - 1;
            col2 = chosencard2[0] - 'A';

            m_MovesList.Add(new Move(new MatrixIndex(row2, col2)));
            OnButtonStatusChanged(new MatrixIndex(row2, col2), "Show");

            System.Threading.Thread.Sleep(1000);
            MoveListFull(m_IndexOfCurrentPlayer);

        }

        public bool CheckMatch()
        {
            return Board.BoardMatrix[m_MovesList[0].Index.Row, m_MovesList[0].Index.Col] == Board.BoardMatrix[m_MovesList[1].Index.Row, m_MovesList[1].Index.Col];
        }   
        
        public void MoveListFull(int i_CurrentIndex)
        {
            bool res = CheckMatch();

            string card1ToOldFormat = ToOldFormat(m_MovesList[0].Index.Row, m_MovesList[0].Index.Col);
            string card2ToOldFormat = ToOldFormat(m_MovesList[1].Index.Row, m_MovesList[1].Index.Col);

            if (res == true) ////if cards matched
            {
                bool isCardRemoved = false;

                Players[m_IndexOfCurrentPlayer].PlayerScore++;
                Board.Lists.LegitMovesList.Remove(card1ToOldFormat);
                Board.Lists.LegitMovesList.Remove(card2ToOldFormat);

                if (Board.Lists.LastTwoMovesList.Contains(card1ToOldFormat) == true)
                {
                    Board.Lists.LastTwoMovesList.Remove(card1ToOldFormat);
                    isCardRemoved = true;
                }

                if (Board.Lists.LastTwoMovesList.Contains(card2ToOldFormat) == true)
                {
                    Board.Lists.LastTwoMovesList.Remove(card2ToOldFormat);
                    isCardRemoved = true;
                }

                if (isCardRemoved == false && Board.Lists.LastTwoMovesList.Count > 0)
                {
                    Board.Lists.LastTwoMovesList.RemoveAt(0); ////If there is a match outside the list, make PC "forget" 1 move
                }

                isCardRemoved = false;
            }
            else 
            {
                ////cards didn't match
                m_IndexOfCurrentPlayer = (m_IndexOfCurrentPlayer + 1) % 2;
                ButtonStatusChanged(m_MovesList[0].Index, "Hide");
                ButtonStatusChanged(m_MovesList[1].Index, "Hide");

                Board.ExposedCardsMatrix[m_MovesList[0].Index.Row, m_MovesList[0].Index.Col] = false;
                Board.ExposedCardsMatrix[m_MovesList[1].Index.Row, m_MovesList[1].Index.Col] = false;

                Board.Lists.LegitMovesList.Add(card1ToOldFormat);
                Board.Lists.LegitMovesList.Add(card2ToOldFormat);

                if (Board.Lists.LastTwoMovesList.Contains(card1ToOldFormat) == false)
                {
                    if (Board.Lists.LastTwoMovesList.Count == 4)
                    {
                        Board.Lists.LastTwoMovesList.RemoveAt(0);
                    }

                    Board.Lists.LastTwoMovesList.Add(card1ToOldFormat);
                }

                if (Board.Lists.LastTwoMovesList.Contains(card2ToOldFormat) == false)
                {
                    if (Board.Lists.LastTwoMovesList.Count == 4)
                    {
                        Board.Lists.LastTwoMovesList.RemoveAt(0);
                    }

                    Board.Lists.LastTwoMovesList.Add(card2ToOldFormat);
                }
            }

            TurnEnded(Players[i_CurrentIndex].PlayerName, Players[i_CurrentIndex].PlayerScore, res, i_CurrentIndex);

            m_MovesList.RemoveAt(1);
            m_MovesList.RemoveAt(0);

            if (Board.Lists.LegitMovesList.Count == 0)
            {
                ////game finished
                if (Players[0].PlayerScore > Players[1].PlayerScore)
                {
                    OnGameEnded(0);
                }
                else
                {
                    OnGameEnded(1);
                }

                isGameEnded = true;
            }

            if (isGameEnded == false && Players[m_IndexOfCurrentPlayer].IsPlayerComputer == true)
            {
                ComputerTurn();
            }
        }   

        public static string ToOldFormat(int i_Row, int i_Col)
        {
            return string.Format("{0}{1}", (char)('A' + i_Col), i_Row + 1);
        }    

        public void InitiatePlayers(List<string> i_PlayersNamesList)
        {
            int numOfPlayers = i_PlayersNamesList.Count;

            this.m_Players = new Player[numOfPlayers];

            for (int i = 0; i < numOfPlayers; i++)
            {
                this.m_Players[i] = new Player();
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                this.m_Players[i].PlayerName = i_PlayersNamesList[i];

                if (i_PlayersNamesList[i].Contains("Computer"))
                {
                    this.m_Players[i].IsPlayerComputer = true;
                }
            }
        }    

        public void InitiateGameBoard(int i_GameRows, int i_GameCols)
        {
            this.m_Board = new Board(i_GameRows, i_GameCols);
        }    
    }

    struct Move
    {
        public Move(MatrixIndex i_Index)
        {
            Index = i_Index;
        }

        public MatrixIndex Index
        {
            get; set;
        }
    }
}