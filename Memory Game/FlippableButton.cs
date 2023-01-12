namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class FlippableButton : Button
    {
        ////attributes
        private MatrixIndex m_MatrixIndex;
        private bool m_Exposed = false;
        private char m_Value;

        ////ctor
        public FlippableButton(int i_Row, int i_Col, char i_Value)
        {
            this.MatrixIndex = new MatrixIndex(i_Row, i_Col);
            this.m_Value = i_Value;
        }

        ////events
        public event Action<ButtonClickedArgs> ButtonClicked;

        public event Action AfterButtonClicked;

        ////properties
        public MatrixIndex MatrixIndex
        {
            get
            {
                return this.m_MatrixIndex;
            }

            set
            {
                this.m_MatrixIndex = value;
            }
        }

        public char Value
        {
            get
            {
                return this.m_Value;
            }

            set
            {
                this.m_Value = value;
            }
        }

        public bool Exposed
        {
            get
            {
                return this.m_Exposed;
            }

            set
            {
                this.m_Exposed = value;
            }
        }

        ////methods
        public void OnAfterButtonClicked()
        {
            if (AfterButtonClicked != null)
            {
                AfterButtonClicked.Invoke();
            }
        }

        protected override void OnClick(EventArgs i_E)
        {
            if (this.Exposed == false)
            {
                ButtonClickedArgs e = new ButtonClickedArgs();

                e.Index = this.MatrixIndex;
                e.CurrentButton = this;

                if (ButtonClicked != null)
                {
                    ButtonClicked.Invoke(e);

                    OnAfterButtonClicked();
                }
            }
        }
    }
}