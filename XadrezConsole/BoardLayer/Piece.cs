using BoardLayer.Enum;

namespace BoardLayer
{
    internal class Piece
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

        
    }
}
