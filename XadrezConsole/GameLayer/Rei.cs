using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class Rei : Piece
    {
        public Rei(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "R";
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
            if (Board.ValidPosition(pos) && CanMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // RIGHT
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // DOWN
            pos.DefineValues(Position.Line + 1 , Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SO
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // LEFT
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NO
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        

    }
}
