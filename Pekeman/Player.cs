using System;

namespace Pekeman
{
    public class Player
    {
        public double X
        {
            get { return ScreenX / 32; }
            set { X = value; ScreenX = value * 32;}
        }

        public double Y
        {
            get { return ScreenY / 32; }
            set { Y = value; ScreenY = value * 32;}
        }

        public double ScreenX { get; set; }

        public double ScreenY { get; set; }

        public int MovementAnimation { get; set; } = 0;

        public double Angle { get; set; }

        public double Speed { get; set; } = 1;

        public double BaseSpeed { get; set; } = 128; //Pixel/second

        public double HitboxSize = 32;

        public Rotation Facing = new Rotation();

        public void SetInitialPos(double x, double y)
        {
            ScreenX = x;
            ScreenY = y;
        }

        public void MovePlayer(float distance)
        {
            ScreenX += distance * Speed * Math.Cos(Angle);
            ScreenY -= distance * Speed * Math.Sin(Angle);
        }

        public class Rotation
        {
            public bool Up = false;
            public bool Down = false;
            public bool Right = false;
            public bool Left = false;
        }
    }
}