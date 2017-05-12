using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Pekeman
{
    public class Npc
    {
        public Map.MapData _mapData;

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

        private Random _random = new Random();


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

        public void StartThread(Map.MapData data)
        {
            _mapData = data;
            Thread t = new Thread(MoveNpc);
            t.Start();


        }

        private Stopwatch _stopwatch;

        public int GetCellIndex(int x, int y)
        {
            return x * _mapData.Size.Width + y;
        }

        public IEnumerable<int> GetCellIndexUnderPlayer()
        {
            int posXMin = (int) Math.Floor((ScreenX - 8) / 32);
            int posXMax = (int) Math.Floor((ScreenX + 8) / 32);
            int posYMin = (int) Math.Floor((ScreenY - 0) / 32);
            int posYMax = (int) Math.Floor((ScreenY + 8) / 32);

            for (int x = posXMin; x <= posXMax; x++)
            {
                for (int y = posYMin; y <= posYMax; y++)
                {
                    yield return GetCellIndex(x, y);
                }
            }
        }

        public void MoveNpc()
        {
            double timeLeft = 0;

            ScreenX = X * 32;
            ScreenY = Y * 32;

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
                ScreenX += ellapsedSeconds * Speed * 32 * Math.Cos(Angle);
                ScreenY -= ellapsedSeconds * Speed * 32 * Math.Sin(Angle);

                //Out of map
                if (ScreenX < 0 || ScreenX + 32 > _mapData.Size.Width * 32)
                {
                    ScreenX = oldX;
                    timeLeft = 0;
                }

                if (ScreenY < 0 || ScreenY+ 32 > _mapData.Size.Height * 32)
                {
                    ScreenY = oldY;
                    timeLeft = 0;
                }

                if (GetCellIndexUnderPlayer().Any(i => _mapData.Layers.Collision[i]))
                {
                    ScreenX = oldX;
                    ScreenY = oldY;
                }

                Thread.Sleep(30);
            }
        }

    }
}