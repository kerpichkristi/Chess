using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    class FigureMoving
    {
        public Figure figure { get; private set;}
        public Coordinates from  { get; private set; }
        public Coordinates to { get; private set; }
        public Figure promotion { get; set; }

        public FigureMoving(FigureCoordinates fc, Coordinates to,Figure promotion = Figure.none) {

            this.figure = fc.figure;
            this.from = fc.coordinates;
            this.to = to;
            this.promotion = promotion;
        
        }
        public FigureMoving(string move) {

            this.figure = (Figure)move[0];
            this.from = new Coordinates(move.Substring(1, 2));
            this.to = new Coordinates(move.Substring(3, 2));
            this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }
    }
}
