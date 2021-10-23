using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPAssignment.AllStructs;

namespace OOPAssignment.AllClasses
{
    public class CarInfo
    {

        public Guid CarId;

        public Coordinates Coordinates;
        public CarInfo(Guid carId, Coordinates coordinates)
        {
            CarId = carId;
            Coordinates = coordinates;
        }
    }
}
