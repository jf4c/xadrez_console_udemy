using BoardLayer;
using BoardLayer.Enum;

namespace GameLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int _turn;
        private Color _currentPlayer;
        public bool Finishing { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            _turn = 1;
            _currentPlayer = Color.White;
            Finishing = false;
            PutPiece();

        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.addMovement();
            Board.PutPiece(p, destiny); 
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
