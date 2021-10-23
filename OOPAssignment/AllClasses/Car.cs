using System;
using System.Linq;
using OOPAssignment.AllEnums;
using OOPAssignment.AllInterfaces;
using OOPAssignment.AllStructs;

namespace OOPAssignment.AllClasses
{
    public class Car : ICarCommand, AllInterfaces.IObservable<CarInfo>
    {

        public Direction Direction;
        public ISurface Surface;
        public Guid Id { get; }
        public Coordinates Coordinates;
        

        private AllInterfaces.IObserver<CarInfo> Observer { get; set; }

        private Direction[] directions = new Direction[] { Direction.S, Direction.W, Direction.N, Direction.E };

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Id = Guid.NewGuid();
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        public void Attach(AllInterfaces.IObserver<CarInfo> observer)
        {
            observer.Update(new CarInfo(Id, Coordinates));
            Observer = observer;
        }

        public void Move()
        {

            long nextY = Coordinates.Y;


            long nextX = Coordinates.X;
            

            switch (Direction)
            {

                case Direction.S:
                    nextY--;
                    break;
                case Direction.W:
                    nextX--;
                    break;
                case Direction.N:
                    nextY++;
                    break;
                case Direction.E:
                    nextX++;
                    break;
                
            }

            var newCoordinates = new Coordinates(nextX, nextY);

            if (Observer.GetObservables().Any(x => x.Coordinates.X == newCoordinates.X && x.Coordinates.Y == newCoordinates.Y))
                throw new Exception("HATA: ÇARPIŞMA");
            if (!Surface.IsCoordinatesInBounds(newCoordinates))
                throw new System.Exception("HATA: HARİTA DIŞINDA");


            Coordinates = newCoordinates;
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }


        public void TurnRight()
        {
            var newIndex = Array.IndexOf(directions, Direction);

            if (++newIndex > 4)
            {
                newIndex = 0;
            }

            Direction = directions[newIndex];
        }
        public void TurnLeft()
        {
            var newIndex = Array.IndexOf(directions, Direction);

            if (--newIndex < 0)
            {
                newIndex = 3;
            }
            Direction = directions[newIndex];
        }

        
    }
}
