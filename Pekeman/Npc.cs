using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pekeman
{
    public class Npc
    {
        public int MovementAnimation { get; set; }

        public double ScreenX { get; set; }
        public double ScreenY { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }
        public double Speed { get; set; } = 1;
        public double BaseSpeed { get; set; } = 128; //Pixel/second
        public double Distance { get; set; }
        public Player.Rotation Facing = new Player.Rotation();
        public string Name;

        private Random _random;

        public Npc(string name)
        {
            Name = name;
        }

        public Npc() : this("Mathieu")
        {
        }

        public void UpdateMovementAnimation()
        {
            MovementAnimation++;

            if (MovementAnimation == 3)
            {
                MovementAnimation = 0;
            }
        }

        public void StartThread()
        {
            Thread t = new Thread(MoveNpc);
            t.Start();
        }

        private Stopwatch _stopwatch;
        public Map.MapData _mapData;

        public void MoveNpc()
        {
            _random = new Random();
            double timeLeft = 0;
            //Distance = 2;


            _stopwatch = Stopwatch.StartNew();
            while (true)
            {
                long ellapsed = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Reset();
                _stopwatch.Restart();
                float ellapsedSeconds = ellapsed / 1000f;

                timeLeft -= ellapsedSeconds;
                if (timeLeft < 0)
                {
                    timeLeft = 2;
                    Angle = _random.Next(4) * Math.PI / 2;
                    Speed = 0.75 + _random.NextDouble() / 2;
                }

                double oldX = ScreenX;
                double oldY = ScreenY;
                ScreenX += ellapsedSeconds * Speed * Math.Cos(Angle);
                ScreenY -= ellapsedSeconds * Speed * Math.Sin(Angle);

                //Out of map
                if (ScreenX < 0 || ScreenX + 32 > 320)
                {
                    ScreenX = oldX;
                    timeLeft = 0;
                }

                if (ScreenY < 0 || ScreenY+ 32 > 320)
                {
                    ScreenY = oldY;
                    timeLeft = 0;
                }

                Thread.Sleep(30);
            }
        }

    }
}