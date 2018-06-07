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
        private short m_Size;
        private SquareButton[,] m_Squares;
        private Move currentMove;

        public BoardGameForm(short i_Size)
        {
            InitializeComponent();
            m_Size = i_Size;
            m_Squares = new SquareButton[this.m_Size, this.m_Size];
            InitBoard();
   

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

        public void button_Click(Object sender, EventArgs e)
        {
            SquareButton button = (SquareButton)sender;
            
            int row = button.Row;
            int col = button.Column;

            if (currentMove == null)
                currentMove = new Move();
            if (currentMove.FromSquare == null)
            {
                currentMove.FromSquare = new Square(button.Type, row, col);
            }
            else
            {
                currentMove.ToSquare = new Square(button.Type ,row, col);
            }
            if ((currentMove.FromSquare != null) && (currentMove.ToSquare != null))
            {
                /*
                if (CheckMove())
                {
                    MakeMove();
                    aiMakeMove();
                }
                */

                MakeMove();
            }
        }
      public void MakeMove()
        {
            Square fromSquare = currentMove.FromSquare;
            Square toSquare = currentMove.ToSquare;
            SquareButton fromButton = Squares[currentMove.FromSquare.Row, currentMove.FromSquare.Column];
            SquareButton toButton = Squares[currentMove.ToSquare.Row, currentMove.ToSquare.Column];

            switch (currentMove.MoveType)
            {
                case (GameLogic.Move.eTypeOfMove.Regular):

                    if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
                    {
                        toSquare.Type = Square.eSquareType.K;                      
                    }

                    else
                        if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == m_Size - 1)
                    {
                        toSquare.Type = Square.eSquareType.U;
                    }
                    else
                    {
                        toSquare.Type = fromSquare.Type;
                        
                    }
                    fromSquare.Type = Square.eSquareType.None;
                    break;

                case (GameLogic.Move.eTypeOfMove.Jump):
                   // capturePieceOnBoard(i_BoardGame);

                    if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
                    {
                        toSquare.Type = Square.eSquareType.K;
                    }

                    else
                    {
                        if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == m_Size - 1)
                        {
                            toSquare.Type = Square.eSquareType.U;
                        }
                        else
                        {
                            toSquare.Type = fromSquare.Type;
                        }
                    }
                    fromSquare.Type = Square.eSquareType.None;
                    break;
            }
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
