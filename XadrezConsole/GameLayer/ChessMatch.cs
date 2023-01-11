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
        public bool Check { get; private set; }

        private HashSet<Piece> _pieces;
        private HashSet<Piece> _captured;



        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finishing = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            PutPiece();

        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.addMovement();
            Piece pieceCaptured = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if (pieceCaptured != null)
            {
                _captured.Add(pieceCaptured);
            }
            //#Jogadas Especiais
            if (p is Rei && destiny.Column == origin.Column + 2)
            {
                Position OriginCastle = new Position(origin.Line, origin.Column + 3);
                Position DestinyCastle = new Position(origin.Line, origin.Column + 1);
                Piece t = Board.RemovePiece(OriginCastle);
                t.addMovement();
                Board.PutPiece(t, DestinyCastle);
            }

            if (p is Rei && destiny.Column == origin.Column - 2)
            {
                Position OriginCastle = new Position(origin.Line, origin.Column - 4);
                Position DestinyCastle = new Position(origin.Line, origin.Column - 1);
                Piece t = Board.RemovePiece(OriginCastle);
                t.addMovement();
                Board.PutPiece(t, DestinyCastle);
            }


            return pieceCaptured;
        }

        public void reverseMovement(Position origin, Position destiny, Piece pieceCaptured)
        {
            Piece p = Board.RemovePiece(destiny);
            p.RemoveMovement();
            if (pieceCaptured != null)
            {
                Board.PutPiece(pieceCaptured, destiny);
                _captured.Remove(pieceCaptured);
            }
            Board.PutPiece(p, origin);

            if (p is Rei && destiny.Column == origin.Column + 2)
            {
                Position OriginCastle = new Position(origin.Line, origin.Column + 3);
                Position DestinyCastle = new Position(origin.Line, origin.Column + 1);
                Piece t = Board.RemovePiece(DestinyCastle);
                t.RemoveMovement();
                Board.PutPiece(t, OriginCastle);
            }

            if (p is Rei && destiny.Column == origin.Column - 2)
            {
                Position OriginCastle = new Position(origin.Line, origin.Column - 4);
                Position DestinyCastle = new Position(origin.Line, origin.Column - 1);
                Piece t = Board.RemovePiece(DestinyCastle);
                t.addMovement();
                Board.PutPiece(t, OriginCastle);
            }

        }


        public void PerformsMove(Position origin, Position destiny)
        {
            Piece pieceCaptured = ExecuteMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                reverseMovement(origin, destiny, pieceCaptured);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (TestCheckMate(Opponent(CurrentPlayer)))
            {
                Finishing = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }


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
            if (!Board.Piece(origin).PossibleMove(destiny))
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

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            } 
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece p  in PiecesInGame(color))
            {
                if (p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece R = king(color);
            if (R == null)
            {
                throw new BoardException("Não Tem o Rei " + color + "nesse tabuleiro!");
            }
            foreach (Piece p in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = p.PossibleMoves();
                if (mat[R.Position.Line, R.Position.Column]) 
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool TestCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece p in PiecesInGame(color))
            {
                bool[,] mat = p.PossibleMoves();
                for (int i = 0; i < Board.Line; i++)
                {
                    for (int j = 0; j < Board.Column; j++)
                    {
                        if (mat[i,j])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(i, j);
                            Piece pieceCaptured = ExecuteMovement(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            reverseMovement(origin, destiny, pieceCaptured);
                            if (!testCheck) 
                            {
                                return false;
                            }
                        }

                    }
                }
            }
            return true;
        }



        public void PutNewPiece(char colunm, int line, Piece piece)
        {
            Board.PutPiece(piece, new PositionChess(colunm, line).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPiece()
        {
            PutNewPiece('e', 1, new Rei(Board, Color.White, this));
            PutNewPiece('d', 1, new Dama(Board, Color.White));
            PutNewPiece('c', 1, new Bispo(Board, Color.White));
            PutNewPiece('f', 1, new Bispo(Board, Color.White));
            PutNewPiece('b', 1, new Cavalo(Board, Color.White));
            PutNewPiece('g', 1, new Cavalo(Board, Color.White));
            PutNewPiece('a', 1, new Torre(Board, Color.White));
            PutNewPiece('h', 1, new Torre(Board, Color.White));
            PutNewPiece('a', 2, new Peao(Board, Color.White));
            PutNewPiece('b', 2, new Peao(Board, Color.White));
            PutNewPiece('c', 2, new Peao(Board, Color.White));
            PutNewPiece('d', 2, new Peao(Board, Color.White));
            PutNewPiece('e', 2, new Peao(Board, Color.White));
            PutNewPiece('f', 2, new Peao(Board, Color.White));
            PutNewPiece('g', 2, new Peao(Board, Color.White));
            PutNewPiece('h', 2, new Peao(Board, Color.White));



            PutNewPiece('e', 8, new Rei(Board, Color.Black, this));
            PutNewPiece('d', 8, new Dama(Board, Color.Black));
            PutNewPiece('c', 8, new Bispo(Board, Color.Black));
            PutNewPiece('f', 8, new Bispo(Board, Color.Black));
            PutNewPiece('b', 8, new Cavalo(Board, Color.Black));
            PutNewPiece('g', 8, new Cavalo(Board, Color.Black));
            PutNewPiece('a', 8, new Torre(Board, Color.Black));
            PutNewPiece('h', 8, new Torre(Board, Color.Black));
            PutNewPiece('a', 7, new Peao(Board, Color.Black));
            PutNewPiece('b', 7, new Peao(Board, Color.Black));
            PutNewPiece('c', 7, new Peao(Board, Color.Black));
            PutNewPiece('d', 7, new Peao(Board, Color.Black));
            PutNewPiece('e', 7, new Peao(Board, Color.Black));
            PutNewPiece('f', 7, new Peao(Board, Color.Black));
            PutNewPiece('g', 7, new Peao(Board, Color.Black));
            PutNewPiece('h', 7, new Peao(Board, Color.Black));


        }
    }
}
