using System;

namespace Pekeman
{
    public class Player
    {
        public double _x
        {
            get;
            set;
        }

        public double _y {
            get;
            set;
        }

        public int MovementAnimation { get; set; } = 0;

        public double Angle { get; set; }

        public double Speed { get; set; } = 1;

        public void SetInitialPos(double x, double y)
        {
            _x = x;
            _y = y;
        }


        public void MovePlayer(float distance)
        {
            _x += distance * Speed * Math.Cos(Angle);
            _y -= distance * Speed * Math.Sin(Angle);
        }

    }
}