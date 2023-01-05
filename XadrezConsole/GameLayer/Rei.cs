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

    }
}
