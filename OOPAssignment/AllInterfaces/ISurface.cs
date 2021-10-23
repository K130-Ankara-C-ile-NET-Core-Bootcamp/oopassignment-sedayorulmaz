using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPAssignment.AllStructs;

namespace OOPAssignment.AllInterfaces
{
    public interface ISurface<T> where T : class 
    {
        long Width { get; }
        long Height { get; }
        bool IsCoordinatesInBounds(Coordinates coordinates);
    }
}
