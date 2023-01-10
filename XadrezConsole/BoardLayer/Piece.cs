using BoardLayer.Enum;

namespace BoardLayer
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmOfMovement { get; set; }
        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            AmOfMovement = 0;
        }

        public bool ExistsMovementPossible()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.Line, pos.Column];
        }

        public void addMovement()
        {
            AmOfMovement++;
        }

        public abstract bool[,] PossibleMoves();
    }
}
