using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameUI05
{
    partial class BoardGameForm : Form
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
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(52, 22);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(45, 13);
            this.Player1.TabIndex = 0;
            this.Player1.Text = GetStartGameForm.TextBoxPlayer1.Text;
            this.Player1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(248, 22);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(42, 13);
            this.Player2.TabIndex = 1;
            this.Player2.Text = GetStartGameForm.TextBoxPlayer2.Text;
            this.Player2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "BoardGameForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.BoardGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

           
            this.Name = "BoardGameForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.BoardGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal void InitBoard()
        {
            for (int i = 0; i < this.m_Size; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {

                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.White;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            m_Squares[i, j].Click += new System.EventHandler(button_Click);
                            Controls.Add(m_Squares[i, j]);

                        }
                        else
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.Gray;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            Controls.Add(m_Squares[i, j]);
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.White;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            m_Squares[i, j].Click += new System.EventHandler(button_Click);
                            Controls.Add(m_Squares[i, j]);
                        }
                        else
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.Gray;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            Controls.Add(m_Squares[i, j]);
                        }
                    }
                }
            }

            for (int i = 0; i < this.m_Size / 2 - 1; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.O;
                            m_Squares[i, j].Text = "O";
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.O;
                            m_Squares[i, j].Text = "O";
                        }
                    }
                }
            }

            for (int i = this.m_Size - 1; i > this.m_Size / 2; i--)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.X;
                            m_Squares[i, j].Text = "X";
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.X;
                            m_Squares[i, j].Text = "X";
                        }
                    }
                }


            }
        }
        private Label Player1;
        private Label Player2;

    }

    #endregion
}
