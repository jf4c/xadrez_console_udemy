﻿using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class Cavalo : Piece
    {
        public Cavalo(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);

            
            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line -2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line - 1, Position.Column +2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            
            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }



    }
}
