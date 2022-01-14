using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClassLibrary
{
    class FigureCoordinates
    {
        public Figure figure { get; private set; }
        public Coordinate coordinate { get; private set; }

        public FigureCoordinates(Figure figure, Coordinate coordinate)
        {
            this.figure = figure;
            this.coordinate = coordinate;
        }

    }
}
