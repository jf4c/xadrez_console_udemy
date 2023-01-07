using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class Torre: Piece
    {
        public Torre(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
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

            // UP
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line - 1;
            }


            // RIGHT
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Column = pos.Column + 1;
            }

            // DOWN
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Line = pos.Line + 1;
            }


            // LEFT
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) { break; }
                pos.Column = pos.Column - 1;
            }


            return mat;
        }

    }
}
