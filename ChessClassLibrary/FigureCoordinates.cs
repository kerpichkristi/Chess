using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    class FigureCoordinates
    {
        public Figure figure { get; private set;}
        public Coordinates coordinates { get; private set;}

        public FigureCoordinates(Figure figure, Coordinates coordinates) {

            this.figure = figure;
            this.coordinates = coordinates;
        
        
        }
    }
}
