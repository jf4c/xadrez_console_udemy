using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class Bispo : Piece
    {
        public Bispo(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
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

            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 1;

            }


            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 1;
            }

            // SO
            pos.DefineValues(Position.Line + 1, Position.Column - 1 );
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 1;
            }


            // NO
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 1;
            }


            return mat;
        }

    }
}
