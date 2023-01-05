using BoardLayer;
using BoardLayer.Enum;


namespace BoardLayer
{
    internal class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }

        private Piece[,] _pieces;

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
            _pieces = new Piece[line, column];
        }

        public Piece Piece(int line, int column)
        {
            return _pieces[line, column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

    }
}
