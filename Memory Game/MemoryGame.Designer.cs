namespace Project15
{
    partial class MemoryGameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelCurrentPlayerName = new System.Windows.Forms.Label();
            this.labelFocus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelCurrentPlayer.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(117, 20);
            this.labelCurrentPlayer.TabIndex = 0;
            this.labelCurrentPlayer.Text = "Current Player: ";
            this.labelCurrentPlayer.Click += new System.EventHandler(this.labelCurrentPlayer_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelPlayer1.Location = new System.Drawing.Point(12, 43);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(119, 20);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player Name 1: ";
            this.labelPlayer1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labelPlayer2.Location = new System.Drawing.Point(14, 75);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(119, 20);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "Player Name 2: ";
            this.labelPlayer2.Click += new System.EventHandler(this.labelPlayerName2_Click);
            // 
            // labelCurrentPlayerName
            // 
            this.labelCurrentPlayerName.AutoSize = true;
            this.labelCurrentPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelCurrentPlayerName.Location = new System.Drawing.Point(127, 7);
            this.labelCurrentPlayerName.Name = "labelCurrentPlayerName";
            this.labelCurrentPlayerName.Size = new System.Drawing.Size(168, 20);
            this.labelCurrentPlayerName.TabIndex = 7;
            this.labelCurrentPlayerName.Text = "[current player\'s name]";
            // 
            // labelFocus
            // 
            this.labelFocus.AutoSize = true;
            this.labelFocus.Location = new System.Drawing.Point(305, 13);
            this.labelFocus.Name = "labelFocus";
            this.labelFocus.Size = new System.Drawing.Size(0, 20);
            this.labelFocus.TabIndex = 8;
            // 
            // MemoryGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 108);
            this.Controls.Add(this.labelFocus);
            this.Controls.Add(this.labelCurrentPlayerName);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelCurrentPlayer);
            this.MaximizeBox = false;
            this.Name = "MemoryGameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.Load += new System.EventHandler(this.MemoryGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentPlayer;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelCurrentPlayerName;
        private System.Windows.Forms.Label labelFocus;
    }
}