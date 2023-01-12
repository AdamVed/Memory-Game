namespace Project15
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ButtonClickedArgs : EventArgs
    {
        public MatrixIndex Index
        {
            get; set;
        }

        public FlippableButton CurrentButton
        {
            get; set;
        }
    }
}