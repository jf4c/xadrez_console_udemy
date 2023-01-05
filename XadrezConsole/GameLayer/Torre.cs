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

    }
}
