namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoardLists
    {
        ////attributes
        private List<char> m_MatrixCardsList;
        private List<string> m_LegitMovesList;
        private List<string> m_LastTwoMovesList;

        ////ctor
        public BoardLists(int i_GameRows, int i_GameCols)
        {
            m_LastTwoMovesList = new List<string>(4);
            FillLegitMovesList(i_GameRows, i_GameCols);
            FillListWithLetters(i_GameRows, i_GameCols);
        }

        ////properties
        public List<char> MatrixCardsList
        {
            get
            {
                return m_MatrixCardsList;
            }

            set
            {
                this.m_MatrixCardsList = value;
            }
        }

        public List<string> LegitMovesList
        {
            get
            {
                return this.m_LegitMovesList;
            }

            set
            {
                this.m_LegitMovesList = value;
            }
        }

        public List<string> LastTwoMovesList
        {
            get
            {
                return this.m_LastTwoMovesList;
            }

            set
            {
                this.m_LastTwoMovesList = value;
            }
        }

        ////methods
        public List<string> List1WithoutList2(List<string> i_ListOne, List<string> i_ListTwo)
        {
            List<string> newList = new List<string>(i_ListOne.Count);

            foreach (string item in i_ListOne)
            {
                newList.Add((string)item.Clone());
            }

            foreach (string item in i_ListTwo)
            {
                newList.Remove(item);
            }

            return newList;
        }

        public void FillListWithLetters(int i_Rows, int i_Cols)
        {
            int numOfElements = i_Rows * i_Cols / 2;

            this.m_MatrixCardsList = new List<char>(numOfElements);

            for (int i = 0; i < numOfElements; i++)
            {
                this.m_MatrixCardsList.Add((char)('A' + i));
                this.m_MatrixCardsList.Add((char)('A' + i));
            }
        }

        public void FillLegitMovesList(int i_Rows, int i_Cols)
        {
            int numOfElements = i_Rows * i_Cols;
            this.m_LegitMovesList = new List<string>(numOfElements);

            for (int i = 0; i < i_Cols; i++)
            {
                for (int j = 0; j < i_Rows; j++)
                {
                    this.m_LegitMovesList.Add(string.Format("{0}{1}", (char)('A' + i), j + 1));
                }
            }
        }

        public T GetRandItemFromList<T>(List<T> i_MyList)
        {
            int maxIndex = i_MyList.Count - 1;
            T item;
            Random rnd = new Random();
            int rnd_res = rnd.Next(0, maxIndex);
            item = i_MyList[rnd_res];

            return item;
        }
    }
}