namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Player
    {
        ////attributes
        private int m_PlayerScore;
        private string m_PlayerName;
        private bool m_IsHumanPlayer;

        ////properties
        public int PlayerScore
        {
            get
            {
                return this.m_PlayerScore;
            }

            set
            {
                this.m_PlayerScore = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.m_PlayerName;
            }

            set
            {
                this.m_PlayerName = value;
            }
        }

        public bool IsPlayerComputer
        {
            get
            {
                return this.m_IsHumanPlayer;
            }

            set
            {
                this.m_IsHumanPlayer = value;
            }
        }
    }
}