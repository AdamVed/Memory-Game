namespace Project15
{
    ////includes computer's AI implement - the computer uses a list of the last moves - helps the computer
    ////choose the right matching card
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            new Settings().ShowDialog();
        }
    }

    public struct MatrixIndex
    {
        ////attributes
        private int m_Row;
        private int m_Col;

        ////ctor
        public MatrixIndex(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        ////properties
        public int Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }
            set
            {
                m_Col = value;
            }
        }
    }
}