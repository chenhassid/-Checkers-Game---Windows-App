using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameUI05
{ 

    class SquareButton : Button
    {
        const int k_SquareSize = 50;
        internal eSquareType m_Type;
        internal int m_Row;
        internal int m_Column;

        internal eSquareType Type
        {
            get { return m_Type; }
            set
            {
                m_Type = value;
            }
        }

        internal int Row
        {
            get { return m_Row; }
        }

        internal int Column
        {
            get { return m_Column; }
        }

        internal enum eSquareType
        {
            None,
            X,
            O,
            K,
            U
        }
        public SquareButton(eSquareType i_SquareType, int i_Row, int i_Column)
        {
            this.ClientSize = new Size(k_SquareSize, k_SquareSize);
            m_Type = i_SquareType;
            m_Row = i_Row;
            m_Column = i_Column;

            switch (i_SquareType)
            {
                case eSquareType.O:
                    this.Text = "O";
                    break;
                case eSquareType.X:
                    this.Text = "X";
                    break;
                case eSquareType.K:
                    this.Text = "K";
                    break;
                case eSquareType.U:
                    this.Text = "U";
                    break;
            }
        }
    }
}
