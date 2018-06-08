using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLogic
{
    public class GameManager
    {
        public event EventHandler InvalidMove;

        internal enum eGameStatus
        {
            Winner,
            Lose,
            Draw,
            NotFinished,
        }

        private eGameStatus m_GameStatus;
        private bool v_Turn;
        private BoardGame m_BoardGame;
        private short m_BoardSize;
        private Player m_Player1;
        private Player m_Player2;
        private static Random s_Random = new Random();

        public GameManager(string i_Player1, string i_Player2, short i_BoardSize)
        {
            m_GameStatus = eGameStatus.NotFinished;
            v_Turn = true;
            m_Player1 = new Player(Player.eShapeType.X, i_Player1, Player.ePlayerType.Person);
            m_Player2 = new Player(Player.eShapeType.O, i_Player2, Player.ePlayerType.Person);
            m_BoardSize = i_BoardSize;
            m_BoardGame = new BoardGame(m_BoardSize);
        }

        public GameManager(string i_Player1, short i_BoardSize)
        {
            m_GameStatus = eGameStatus.NotFinished;
            v_Turn = true;
            m_Player1 = new Player(Player.eShapeType.X, i_Player1, Player.ePlayerType.Person);
            m_Player2 = new Player(Player.eShapeType.O, "Computer", Player.ePlayerType.Computer);
            m_BoardSize = i_BoardSize;
            m_BoardGame = new BoardGame(m_BoardSize);
        }

        internal Player GetPlayer1()
        {
            return this.m_Player1;
        }

        internal Player GetPlayer2()
        {
            return this.m_Player2;
        }

        public BoardGame GetBoardGame()
        {
            return this.m_BoardGame;
        }

        internal eGameStatus GetGameStatus()
        {
            return this.m_GameStatus;
        }



        private void gameRound(Move i_CurrentMove)
        {
            if (this.m_GameStatus == eGameStatus.NotFinished)
            {
                if (v_Turn)
                {
                    playCurrentPlayerTurn(i_CurrentMove, m_Player1, m_Player2);
                }
                else
                {
                    if (m_Player2.PlayerType == Player.ePlayerType.Person)
                    {
                        /*
                         if (GameUI.IsQuitInput(currentMoveString))
                         {
                             if (checkForQuitting(m_Player2, m_Player1))
                             {
                                 break;
                             }
                             else
                             {
                                 currentMoveString = GameUI.GetMessageInvalidQuit(m_BoardGame);
                             }
                         }
                         */

                        playCurrentPlayerTurn(i_CurrentMove, m_Player2, m_Player1);
                    }
                    else
                    {
                        playComputerTurn();
                    }

                    //checkGameStatus();
                }
            }

            /*
            if (GameUI05.checkForAnotherGameRound())
            {
                v_Turn = true;
                this.m_GameStatus = eGameStatus.NotFinished;
                short sizeOfBoard = m_BoardGame.Size;
                this.m_BoardGame = new BoardGame(sizeOfBoard);

                gameRound();
            }
            */

        }
        /*
        private void playFirstMoveOfGame()
        {
            string currentMoveString = GameUI.GetFirstMoveFromUser(m_Player1, m_BoardGame);

            if (GameUI.IsQuitInput(currentMoveString))
            {
                m_GameStatus = eGameStatus.Draw;
                GameUI.PrintGamePointStatus(this);
            }

            else
            {
                Move currentMove = getMoveFromString(currentMoveString);

                while (!currentMove.CheckIsValidMove(m_Player1.GetShapeType()))
                {
                    GameUI.PrintErrorOfMove(Move.eTypeOfMove.Regular);
                    currentMoveString = GameUI.GetFirstMoveFromUser(m_Player1, m_BoardGame);
                    currentMove = getMoveFromString(currentMoveString);
                }

                currentMove.MoveOnBoard(m_BoardGame);
                this.v_Turn = false;
            }


        }
        

        private void setSeconedPlayer(string i_TypeOfSeconedPlayer)
        {
            if (GameUI.IsUserTypeOfPlayer(i_TypeOfSeconedPlayer))
            {
                string nameOfPlayer2 = GameUI.GetSeconedPlayerName();
                this.m_Player2 = new Player(Player.eShapeType.O, nameOfPlayer2, Player.ePlayerType.Person);
            }
            else
            {
                this.m_Player2 = new Player(Player.eShapeType.O, "Computer", Player.ePlayerType.Computer);
                s_Random = new Random();
            }
        }
        */

        public void playComputerTurn()
        {
            List<Move> computerJumpsMoves = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.O);
            int lengthOfJumpsList = computerJumpsMoves.Count;
            Move currentMoveForComputer = null;

            if (lengthOfJumpsList > 0)
            {
                while (lengthOfJumpsList > 0)
                {
                    int indexOfJumplMove = s_Random.Next(0, lengthOfJumpsList);
                    currentMoveForComputer = computerJumpsMoves[indexOfJumplMove];
                    currentMoveForComputer.MoveType = Move.eTypeOfMove.Jump;
                    currentMoveForComputer.MoveOnBoard(m_BoardGame);
                    m_Player2.IsJumpTurn = true;

                    if (hasAnotherJump(currentMoveForComputer, m_Player2))
                    {
                        computerJumpsMoves = getListOfJumpsForPiece(m_Player2.GetShapeType(), currentMoveForComputer.ToSquare);
                        lengthOfJumpsList = computerJumpsMoves.Count;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                List<Move> computerDiagonalMoves = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.O);
                int lengthOfListDiagonal = computerDiagonalMoves.Count;
                int indexOfDiagonalMove = s_Random.Next(0, lengthOfListDiagonal);
                Console.WriteLine(indexOfDiagonalMove);
                currentMoveForComputer = computerDiagonalMoves[indexOfDiagonalMove];
                currentMoveForComputer.MoveType = Move.eTypeOfMove.Regular;
                currentMoveForComputer.MoveOnBoard(m_BoardGame);
            }
            v_Turn = !v_Turn;
        }
        /*
        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        private bool checkForQuitting(Player i_playerTurn, Player i_notPlayerTurn)
        {
            int playerTurnPoint = m_BoardGame.GetPointsOfPlayer(i_playerTurn.GetShapeType());
            int NotplayerTurnPoint = m_BoardGame.GetPointsOfPlayer(i_notPlayerTurn.GetShapeType());
            bool isValidQuit = (playerTurnPoint <= NotplayerTurnPoint);

            if (isValidQuit)
            {
                if (playerTurnPoint == NotplayerTurnPoint)
                {
                    m_GameStatus = eGameStatus.Draw;
                }
                else
                {
                    if (i_playerTurn.GetShapeType() == Player.eShapeType.X)
                    {

                        m_GameStatus = eGameStatus.Lose;
                    }
                    else
                    {
                        m_GameStatus = eGameStatus.Winner;
                    }

                    i_notPlayerTurn.Points += NotplayerTurnPoint - playerTurnPoint;
                }

                GameUI.PrintGamePointStatus(this);
            }

            return isValidQuit;
        }
        */
        /*
        private void checkGameStatus()
        {
            List<Move> diagonalMovesOfPlayer1 = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.X);
            List<Move> diagonalMovesOfPlayer2 = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.O);
            List<Move> jumpsMovesOfPlayer1 = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.X);
            List<Move> jumpsMovesOfPlayer2 = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.O);

            if (diagonalMovesOfPlayer1.Count == 0 && diagonalMovesOfPlayer2.Count == 0 && jumpsMovesOfPlayer1.Count == 0 && jumpsMovesOfPlayer2.Count == 0)
            {
                this.m_GameStatus = eGameStatus.Draw;
                GameUI.PrintGamePointStatus(this);
            }
            else
            {
                if (diagonalMovesOfPlayer1.Count == 0 && jumpsMovesOfPlayer1.Count == 0 || m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType()) == 0)
                {
                    this.m_GameStatus = eGameStatus.Lose;
                    m_Player2.Points = m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType()) - m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType());
                    GameUI.PrintGamePointStatus(this);
                }
                else
                {
                    if (diagonalMovesOfPlayer2.Count == 0 && jumpsMovesOfPlayer2.Count == 0 || m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType()) == 0)
                    {
                        this.m_GameStatus = eGameStatus.Winner;
                        m_Player1.Points = m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType()) - m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType());
                        GameUI.PrintGamePointStatus(this);
                    }
                }
            }
        }
        */

        private Move getValidMove(Move i_CurrentMove, Player i_PlayerTurn, Player i_NotPlayerTurn)
        {

            if (!isValidMove(i_CurrentMove))
            {
           
            //    InvalidMove.Invoke(this, EventArgs.Empty);

            }


            return i_CurrentMove;
        }

        private void playCurrentPlayerTurn(Move i_CurrentMove, Player i_PlayerTurn, Player i_NotPlayerTurn)
        {
            Move currentMove = getValidMove(i_CurrentMove, i_PlayerTurn, i_NotPlayerTurn);
            currentMove.MoveOnBoard(m_BoardGame);
            v_Turn = !v_Turn;

            if (i_PlayerTurn.IsJumpTurn)
            {
                while (hasAnotherJump(currentMove, i_PlayerTurn))
                {
                    //playAnotherTurn(ref currentMove, i_PlayerTurn, i_NotPlayerTurn);

                }
            }
        }
        /*
        private string playAnotherTurn(ref Move i_PrevtMove, Player i_PlayerTurn, Player i_NotPlayerTurn)
        {
            List<Move> playerSecondJumps = getListOfJumpsForPiece(i_PlayerTurn.GetShapeType(), i_PrevtMove.ToSquare);

            string i_CurrentMoveString = GameUI.GetMoveFromUser(i_NotPlayerTurn, i_PlayerTurn, m_BoardGame);
            i_PrevtMove = getMoveFromString(i_CurrentMoveString);

            bool isValid = false;
            while (!isValid)
            {
                if (isContainsMoveElement(playerSecondJumps, i_PrevtMove))
                {
                    isValid = true;
                    i_PrevtMove.MoveType = Move.eTypeOfMove.Jump;
                    i_PlayerTurn.IsJumpTurn = !i_PlayerTurn.IsJumpTurn;
                    i_PrevtMove.MoveOnBoard(m_BoardGame);
                }
                else
                {
                    GameUI.PrintErrorOfMove(Move.eTypeOfMove.Jump);
                    i_CurrentMoveString = GameUI05.GetMoveFromUser(i_NotPlayerTurn, i_PlayerTurn, m_BoardGame, i_CurrentMoveString);
                    i_PrevtMove = getMoveFromString(i_CurrentMoveString);
                   =
                }
            }

            return i_CurrentMoveString;
        }
        */
        private bool hasAnotherJump(Move i_CurrentMove, Player i_PlayerTurn)
        {
            List<Move> playerSecondJumps = getListOfJumpsForPiece(i_PlayerTurn.GetShapeType(), i_CurrentMove.ToSquare);

            return (playerSecondJumps.Count > 0) ? true : false;
        }

        // $G$ CSS-013 (-1) Input parameters names should start with i_PascaleCase.
        public bool isValidMove(Move i_CurrentMove)
        {
            bool isValid = false;
            Player.eShapeType shapeType;
            Player playerTurn;
            if (v_Turn)
            {
                shapeType = Player.eShapeType.X;
                playerTurn = m_Player1;
            }
            else
            {
                shapeType = Player.eShapeType.O;
                playerTurn = m_Player2;

            }
            List<Move> playerJumpMoves = m_BoardGame.GetListOfPlayerJumps(shapeType);

            if (playerJumpMoves.Count > 0)
            {
                if (isContainsMoveElement(playerJumpMoves, i_CurrentMove))
                {
                    isValid = true;
                    i_CurrentMove.MoveType = Move.eTypeOfMove.Jump;


                    playerTurn.IsJumpTurn = true;
                }
                else
                {
                    playerTurn.IsJumpTurn = false;
                    //     GameUI.PrintErrorOfMove(Move.eTypeOfMove.Jump);
                }
            }
            else
            {
                if (i_CurrentMove.CheckIsValidMove(shapeType))
                {
                    isValid = true;
                    i_CurrentMove.MoveType = Move.eTypeOfMove.Regular;
                }
                else
                {
                    //      GameUI.PrintErrorOfMove(Move.eTypeOfMove.Regular);
                }
            }
            if (!isValid)
            {
                InvalidMove.Invoke(this, EventArgs.Empty);
            }
            return isValid;
        }


        private static bool isContainsMoveElement(List<Move> i_ListOfMoves, Move i_currentMove)
        {
            bool isContainsMove = false;

            foreach (Move m in i_ListOfMoves)
            {
                if (i_currentMove.IsEqualsTo(m))
                {
                    isContainsMove = true;
                    break;
                }
            }

            return isContainsMove;
        }

        private Move getMoveFromString(string i_CurrentMoveString)
        {
            string fromSquare = i_CurrentMoveString.Substring(0, 2);
            string toSquare = i_CurrentMoveString.Substring(3, 2);
            int columnOfFromSquare = fromSquare[0] - 65;
            int rowOfFromSquare = fromSquare[1] - 97;
            int columnOfToSquare = toSquare[0] - 65;
            int rowOfToSquare = toSquare[1] - 97;
            Move currentMove = new Move(m_BoardGame.GetSquare(rowOfFromSquare, columnOfFromSquare), m_BoardGame.GetSquare(rowOfToSquare, columnOfToSquare));

            return currentMove;
        }

        private List<Move> getListOfJumpsForPiece(Player.eShapeType i_Shape, Square i_Square)
        {
            int squareRow = i_Square.Row;
            int squareColumn = i_Square.Column;
            Move currentMove;
            List<Move> leggalJumpsForPiece = m_BoardGame.GetListOfPlayerJumps(i_Shape);

            for (int i = 0; i < leggalJumpsForPiece.Count; i++)
            {
                currentMove = leggalJumpsForPiece[i];

                if (currentMove.FromSquare.Row != squareRow || currentMove.FromSquare.Column != squareColumn)
                {
                    leggalJumpsForPiece.Remove(currentMove);
                }
            }

            return leggalJumpsForPiece;
        }


    }
}
