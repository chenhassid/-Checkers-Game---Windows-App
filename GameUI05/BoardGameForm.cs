using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameUI05
{
    public partial class BoardGameForm : Form
    {
        internal const int k_Margin = 50;
        private GameManager m_Game;
        private short m_Size;
        private SquareButton[,] m_Squares;
        private Move M_CurrentMove;
        private StartGameForm m_StartGameForm;
        private bool v_IsComputerGame;
        private Player m_PlayerTurn;


        public BoardGameForm(StartGameForm i_StartGameForm)
        {
            m_StartGameForm = i_StartGameForm;
            m_Size = m_StartGameForm.BoardSize;
            M_CurrentMove = null;
            m_Squares = new SquareButton[this.m_Size, this.m_Size];
            v_IsComputerGame = !m_StartGameForm.CheckBoxPlayer2.Checked;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(SizeBoard * k_Margin - 8, SizeBoard * k_Margin + k_Margin);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            m_PlayerTurn = new Player(Player.eShapeType.X, m_StartGameForm.TextBoxPlayer1.Text, Player.ePlayerType.Person);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponent();
            InitBoard();

            if (v_IsComputerGame)
            {
                m_Game = new GameManager(m_StartGameForm.TextBoxPlayer1.Text, m_StartGameForm.BoardSize);
            }
            else
            {
                m_Game = new GameManager(m_StartGameForm.TextBoxPlayer1.Text, m_StartGameForm.TextBoxPlayer2.Text, m_StartGameForm.BoardSize);
            }

            registerEvents();
        }
        public StartGameForm GetStartGameForm
        {
            get
            {
                return m_StartGameForm;
            }
        }

        public SquareButton[,] Squares
        {
            get
            {
                return m_Squares;
            }
            set
            {
                m_Squares = value;
            }
        }

        public short SizeBoard
        {
            get
            {
                return m_Size;
            }
            set
            {
                m_Size = value;
            }
        }

        private void registerEvents()
        {
            m_Game.InvalidMove += new EventHandler(invalidMove);

        }



        public void button_Click(Object sender, EventArgs e)
        {
            SquareButton button = sender as SquareButton;
            int row = button.Row;
            int col = button.Column;

            if (M_CurrentMove == null)
            {
                M_CurrentMove = new Move();
            }

            if (M_CurrentMove.FromSquare == null)
            {
                M_CurrentMove.FromSquare = new Square(button.Type, row, col);
               
            }

            else
            {
                M_CurrentMove.ToSquare = new Square(button.Type, row, col);
            }

            if ((M_CurrentMove.FromSquare != null) && (M_CurrentMove.ToSquare != null))
            {

                if (m_Game.isValidMove(M_CurrentMove))
                {
                    MakeMove();

                    //     v_IsComputerGame = true;
                }
                /*
                if (v_IsComputerGame)
                {
                    MakeComputerMove();
                    v_IsComputerGame = !v_IsComputerGame;
                }
                */


            }
          //  M_CurrentMove = null;

        }


        private void MakeComputerMove()
        {
            // m_Game.playComputerTurn();

        }

        public void MakeMove()
        {
            this.Text = "From: " + M_CurrentMove.FromSquare.Row.ToString() + "," + M_CurrentMove.FromSquare.Column.ToString() + " To: " + M_CurrentMove.ToSquare.Row.ToString() + "," + M_CurrentMove.ToSquare.Column.ToString();

            Square fromSquare = M_CurrentMove.FromSquare;
            Square toSquare = M_CurrentMove.ToSquare;
            SquareButton fromButton = Squares[fromSquare.Row, fromSquare.Column];
            SquareButton toButton = Squares[toSquare.Row, toSquare.Column];
            /*
                        switch (M_CurrentMove.MoveType)
                        {
                        */
            //   case (GameLogic.Move.eTypeOfMove.Regular):

            if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
            {
                toButton.Type = Square.eSquareType.K;
                toButton.Text = "K";
            }

            else
            {
                if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == m_Size - 1)
                {
                    toButton.Type = Square.eSquareType.U;
                    toButton.Text = "U";
                }
                else
                {
                    toButton.Type = fromSquare.Type;
                    toButton.Text = fromSquare.ToStringSqureType();
                }
            }

            fromButton.Type = Square.eSquareType.None;
            fromButton.Text = string.Empty;
          
            //    break;


            //         case (GameLogic.Move.eTypeOfMove.Jump):
         //   M_CurrentMove.capturePieceOnBoard(m_Game.GetBoardGame());


            if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
            {
                toButton.Type = Square.eSquareType.K;
            }

            else
            {
                if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == m_Size - 1)
                {
                    toButton.Type = Square.eSquareType.U;
                }
                else
                {
                    toButton.Type = fromSquare.Type;
                }
            }
            fromButton.Type = Square.eSquareType.None;
            //         break;
            //  }

            M_CurrentMove = new Move();
            M_CurrentMove.FromSquare = null;
            M_CurrentMove.ToSquare = null;


        }

        private void invalidMove(object sender, EventArgs e)
        {
            MessageBox.Show("Invalid Move!" + Environment.NewLine + "Please choose a valid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BoardGame_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button53_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
