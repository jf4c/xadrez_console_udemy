using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finishing { get; private set; }

        private HashSet<Piece> _pieces;
        private HashSet<Piece> _captured;



        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finishing = false;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            PutPiece();

        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.addMovement();
            Piece pieceCaptured = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if (pieceCaptured != null)
            {
                _captured.Add(pieceCaptured);
            }

        }

        public void PerformsMove(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();

        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolida!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("A peça de origem escolida não é sua!");
            }
            if (!Board.Piece(pos).ExistsMovementPossible())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolida!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino Inválida!");
            }
        }


        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer= Color.Black;
            }
            else
            {
                CurrentPlayer= Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in _captured) 
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;

        }


        public void PutNewPiece(char colunm, int line, Piece piece)
        {
            Board.PutPiece(piece, new PositionChess(colunm, line).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPiece()
        {
            PutNewPiece('c', 1, new Torre(Board, Color.White));
            PutNewPiece('c', 2, new Torre(Board, Color.White));
            PutNewPiece('d', 2, new Torre(Board, Color.White));
            PutNewPiece('e', 2, new Torre(Board, Color.White));
            PutNewPiece('e', 1, new Torre(Board, Color.White));
            PutNewPiece('d', 1, new Rei(Board, Color.White));

            PutNewPiece('c', 7, new Torre(Board, Color.Black));
            PutNewPiece('c', 8, new Torre(Board, Color.Black));
            PutNewPiece('d', 7, new Torre(Board, Color.Black));
            PutNewPiece('e', 7, new Torre(Board, Color.Black));
            PutNewPiece('e', 8, new Torre(Board, Color.Black));
            PutNewPiece('d', 8, new Rei(Board, Color.Black));


        }
    }
}
