using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class Peao : Piece
    {
        public Peao(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "P";
        }

        private bool ExistOpponent(Position pos) 
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color; 
        }


        private bool free(Position pos)
        {
            return Board.Piece(pos) == null;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && free(pos) && AmOfMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && free(pos) && AmOfMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            
            return mat;
        }



    }
}
