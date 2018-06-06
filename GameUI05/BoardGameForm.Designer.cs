using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI05
{
    partial class BoardGameForm : Form
    {
        private short m_Size;
        private Button[,] m_Squares;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BoardGameForm(short i_Size, Button[,] i_Squares)
        {
            InitializeComponent();
            this.m_Size = i_Size;
            this.m_Squares = i_Squares;
            BuildBoard();
        }

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BoardGameForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.BoardGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        internal void BuildBoard()
        {

            this.m_Squares = new Button[m_Size, m_Size];

            for( int i=0; i< this.m_Size; i++ )
            {
                for (int j = 0; j < this.m_Size; j++)
            {
                m_Squares[i, j] = new Button();
                m_Squares[i, j].Height = 50;
                m_Squares[i, j].Width = 50;
                    m_Squares[i, j].Location = new Point(i * 50, j * 50);
                    m_Squares[i, j].BackColor = Color.Black;
                    this.Controls.Add(m_Squares[i, j]);

                }
            
            }
            this.ShowDialog();
        /*
                for (int i = 0; i < this.m_Size / 2 - 1; i++)
                {
                    for (int j = 0; j < this.m_Size; j++)
                    {
                        if (i % 2 == 1)
                        {
                            if (j % 2 == 0)
                            {
                        

                        }
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                            m_Squares[i, j].Type = eSquareType.O;
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
                            m_Squares[i, j].Type = eSquareType.X;
                            }
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                            m_Squares[i, j].Type = eSquareType.X;
                            }
                        }
                    }
                    */
                
            }

        private Label label1;
        private Label label2;
    }

        #endregion
    }
