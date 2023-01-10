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

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finishing = false;
            PutPiece();

        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.addMovement();
            Board.PutPiece(p, destiny); 
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

        private void PutPiece()
        {
            Board.PutPiece(new Torre(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.PutPiece(new Torre(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.PutPiece(new Torre(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.PutPiece(new Torre(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.PutPiece(new Torre(Board, Color.White), new PositionChess('e', 1).ToPosition());
            Board.PutPiece(new Rei(Board, Color.White), new PositionChess('d', 1).ToPosition());

            Board.PutPiece(new Torre(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.PutPiece(new Torre(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.PutPiece(new Torre(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.PutPiece(new Torre(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.PutPiece(new Torre(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.PutPiece(new Rei(Board, Color.Black), new PositionChess('d', 8).ToPosition());


        }
    }
}
