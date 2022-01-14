using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    class Moves
    {
        FigureMoving fm;
        Board board;

        public Moves(Board board)
        {
            this.board = board;
        }
        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return CanMoveFrom() &&
                CanMoveTo() &&
                CanMoveFigure();
        }

       

        private bool CanMoveFrom() {
            return fm.from.OnBoard() &&
                    fm.figure.GetColor() == board.moveColor;
        
        }
        private bool CanMoveTo()
        {
            return fm.to.OnBoard() &&
                fm.from != fm.to &&
                board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }
        private bool CanMoveFigure()
        {
            switch (fm.figure)
            {
                case Figure.whiteKing:
                case Figure.blackKing:
                    return CanKingMove();
                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();
                case Figure.whiteRook:
                case Figure.blackRook:
                    return (fm.SignX == 0 || fm.SignY == 0) && CanStraightMove();
                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return (fm.SignX != 0 && fm.SignY != 0) && CanStraightMove();
                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKhightMove();
                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();
                default: return false;
            }
        }

        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }
        private bool CanKhightMove()
        {

            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
        }

        private bool CanStraightMove()
        {
            Coordinate at = fm.from;
            do
            {
                at = new Coordinate(at.x + fm.SignX, at.y + fm.SignY);
                if (at == fm.to)
                    return true;
            } while (at.OnBoard() &&
                    board.GetFigureAt(at) == Figure.none);
            return false;


        }
        private bool CanPawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
                return false;
            int stepY = fm.figure.GetColor() == Color.white ? 1 : -1;
            return
                CanPawnGo(stepY) ||
                CanPawnJump(stepY) ||
                CanPawnEat(stepY);
        }

     

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanPawnJump(int stepY)
        {
            
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == 2 * stepY)
                        if (fm.from.y == 1 || fm.from.y == 6)
                            if (board.GetFigureAt(new Coordinate(fm.from.x, fm.from.y + stepY)) == Figure.none)
                                return true;
            return false;
        }
        private bool CanPawnEat(int stepY)
        {
            if(board.GetFigureAt(fm.to) != Figure.none)
                if (fm.AbsDeltaX == 1)
                if (fm.DeltaY == stepY)
                    return true;
            return false;
        }
    }
    
}