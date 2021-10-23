using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPAssignment.AllInterfaces;
using OOPAssignment.AllStructs;


namespace OOPAssignment.AllClasses
{
    public class Surface : ISurface, ICollidableSurface, AllInterfaces.IObserver<CarInfo>
    {

        long _width, _height;
        private readonly List<CarInfo> ObservableCars = new List<CarInfo>();

        public Surface(long width, long height)
        {
            _width = width;
            _height = height;
        }

        public long Width => _width;
        public long Height => _height;

        public Surface()
        {
        }

        public Surface(long width, long height, List<CarInfo> observableCars) : this(width, height)
        {
            ObservableCars = observableCars;
        }

        public List<CarInfo> GetObservables()
        {
            List<CarInfo> carList = new List<CarInfo>();
            if (ObservableCars != null)
            {
                foreach (var item in ObservableCars)
                    carList.Add(item);
            }
            return carList;
        }


        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {

            if (ObservableCars != null)
            {
                foreach (var item in ObservableCars)
                {
                    if (item.Coordinates.X == coordinates.X && item.Coordinates.Y == coordinates.Y)
                        return false;
                }
            }
            return true;
        }


        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {

            if (coordinates.Y >= Height || coordinates.X >= Width || coordinates.X < 0 || coordinates.Y < 0)
            {
                return false;
            }
            return true;


        }


        public void Update(CarInfo provider)
        {
            var carL = GetObservables();



            if (carL.Contains(provider))
            {
                var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
                car.Coordinates = provider.Coordinates;
            }


            else if (IsCoordinatesEmpty(provider.Coordinates))
            {
                ObservableCars.Add(provider);

            }


            else
            {
                var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
                if (car.Coordinates.X == provider.Coordinates.X && car.Coordinates.Y == provider.Coordinates.Y)
                {
                    throw new Exception();
                }
                else
                {
                    ObservableCars.Add(provider);
                }
            }

        }

        bool ICollidableSurface.IsCoordinatesEmpty(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        

        public override bool Equals(object objectO)
        {
            return base.Equals(objectO);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public interface ISurface
    {
        bool IsCoordinatesInBounds(Coordinates newCoordinates);
    }
}
