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

        public Piece Piece(Position pos)
        {
            return _pieces[pos.Line, pos.Column];
        }
        public bool ExistPieces(Position pos) 
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistPieces(pos))
            {
                throw new BoardException("Já Existe Uma peça nessa posição!");
            }
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Line || pos.Column < 0 || pos.Column >= Column)
            {
                return false;
            }
            
            return true;
        }
        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos)) 
            {
                throw new BoardException("Position Invalid !");
            }

        }


    }
}
