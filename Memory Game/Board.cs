namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Board
    {
        ////attributes
        private int m_Rows;
        private int m_Cols;
        private char[,] m_BoardMatrix;
        private bool[,] m_ExposedCardsMatrix;
        private BoardLists m_Lists;

        ////ctor
        public Board(int i_GameRows, int i_GameCols)
        {
            m_Lists = new BoardLists(i_GameRows, i_GameCols);
            m_Rows = i_GameRows;
            m_Cols = i_GameCols;
            m_BoardMatrix = new char[m_Rows, m_Cols];
            m_ExposedCardsMatrix = new bool[m_Rows, m_Cols];

            FillMatrixFromRandList(Lists.MatrixCardsList);
        }

        ////properties
        public int Rows
        {
            get
            {
                return this.m_Rows;
            }

            set
            {
                this.m_Rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.m_Cols;
            }

            set
            {
                this.m_Cols = value;
            }
        }

        public char[,] BoardMatrix
        {
            get
            {
                return this.m_BoardMatrix;
            }

            set
            {
                this.m_BoardMatrix = value;
            }
        }

        public bool[,] ExposedCardsMatrix
        {
            get
            {
                return this.m_ExposedCardsMatrix;
            }

            set
            {
                this.m_ExposedCardsMatrix = value;
            }
        }

        public BoardLists Lists
        {
            get
            {
                return this.m_Lists;
            }
        }

        ////methods
        public char CardStrToChar(string i_Card)
        {
            int moveRow, moveCol;
            moveRow = int.Parse(i_Card[1].ToString()) - 1; ////Analyizing card 1's content
            moveCol = (int)char.ToUpper(i_Card[0]) - (int)'A';

            return m_BoardMatrix[moveRow, moveCol];
        }

        public void FillMatrixFromRandList(List<char> i_CharList)
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    BoardMatrix[i, j] = Lists.GetRandItemFromList(i_CharList);
                    i_CharList.Remove(m_BoardMatrix[i, j]);
                }
            }
        }
       
        public bool IsCardExposed(int i_CheckRow, int i_CheckCol)
        {
            return this.m_ExposedCardsMatrix[i_CheckRow, i_CheckCol];
        }

        public void ExposeCard(string i_Card)
        {
            int moveRow, moveCol;
            moveRow = int.Parse(i_Card[1].ToString()) - 1; ////Analyizing card 1's content
            moveCol = (int)char.ToUpper(i_Card[0]) - (int)'A';

            this.ExposedCardsMatrix[moveRow, moveCol] = true;
        }
    }
}