using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pekeman.Map2;

namespace Pekeman.Entity
{
    public abstract class Entity
    {
        public double X { get; set; } //Pixel
        public double Y { get; set; } //Pixel
        public int MovementAnimation { get; set; }
        public double Angle { get; set; }
        public double Speed { get; set; } = 1;
        public static double BaseSpeed { get; set; } = 128; //Pixel/second
        public string Name;

        protected readonly Random Random = new Random();

        private readonly Map2.MapDataJson _mapData;


        public Entity(Map2.MapDataJson mapData, string name)
        {
            _mapData = mapData;
            Name = name;
        }

        public Entity(Map2.MapDataJson mapData) : this(mapData, "Denis")
        {
        }

        /// <summary>
        /// Mettre à jour les mouvements des jambes et des bras du joueur.
        /// </summary>
        public void UpdateMovementAnimation()
        {
            MovementAnimation++;
            if (MovementAnimation == 3)
            {
                MovementAnimation = 0;
            }
        }

        /// <summary>
        /// Déplacer l'entité de la distance passé en paramètre dans l'angle de l'entité.
        /// Vérifier les collisions. Si après le déplacement l'entité entre en collision
        /// avec un objet ou sort de la map, il sera déplacé à sa position précédente.
        /// Vérifier si l'entité entre sur une zone d'évènement et g.rer cette évènement.
        /// </summary>
        /// <param name="distance">La distance à parcourir par l'entité.</param>
        public void MoveEntity(double distance)
        {
            if (distance == 0) return;

            double oldX = X;
            double oldY = Y;

            X += distance * Speed * Math.Cos(Angle);
            Y -= distance * Speed * Math.Sin(Angle);

            if (CollideWithWorld())
            {
                X = oldX;
                Y = oldY;
            }

            if (X / 32 != oldX / 32 && Y / 32 != oldY / 32)
            {
                CheckEvent();
            }
        }

        private void CheckEvent()
        {
            foreach (MapEvent mapEvent in _mapData.Events)
            {
                int startX = mapEvent.Area.From.X;
                int startY = mapEvent.Area.From.Y;
                int endX = mapEvent.Area.To.X;
                int endY = mapEvent.Area.To.Y;
                if (X / 32 < startX || X / 32 > endX || Y / 32 < startY || Y / 32 > endY) continue;

                int chancesMultiplicator = (int) (100 / (mapEvent.Chances * 100));

                int next = Random.Next(chancesMultiplicator);
                if (next != 0) continue;

                switch (mapEvent.EventType)
                {
                    case EventTypeEnum.EnterPokedex:
                        //TODO: frmPeke.ShowPekedex(true);
                        break;
                    case EventTypeEnum.EnterPekecenter:
                        //TODO: frmPeke.MapPeke.Battle.HealPokemon();
                        break;
                    case EventTypeEnum.MeetPokemon:
                        //TODO: Battle.StartBattle();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Récupérer l'index tu tableau en fonction de la position x et y.
        /// </summary>
        /// <param name="x">Ligne du tableau</param>
        /// <param name="y">Colonne du tableau</param>
        /// <returns>Index du tableau représenté par (x,y).</returns>
        private int GetCellIndex(int x, int y)
        {
            return x * _mapData.Size.Width + y;
        }

        /// <summary>
        /// Retourne l'ensemble des cases autour de l'entité auxquelles la boite de
        /// collision de l'entité touche.
        /// </summary>
        /// <returns>Retourne l'ensemble des cases autour de l'entité.</returns>
        private IEnumerable<int> GetCellIndexUnderPlayer()
        {
            int posXMin = (int) Math.Floor((X - 8) / 32);
            int posXMax = (int) Math.Floor((X + 8) / 32);
            int posYMin = (int) Math.Floor((Y - 0) / 32);
            int posYMax = (int) Math.Floor((Y + 8) / 32);

            for (int x = posXMin; x <= posXMax; x++)
            {
                for (int y = posYMin; y <= posYMax; y++)
                {
                    yield return GetCellIndex(x, y);
                }
            }
        }

        /// <summary>
        /// Vérifier le l'entité sort de la map ou qu'elle entre en collision avec
        ///  un objet dans la map.
        /// </summary>
        /// <returns>Vrai si l'entité entre en collision.</returns>
        private bool CollideWithWorld()
        {
            //Out of map
            if (X < 0 || X + 32 > _mapData.Size.Width * 32)
            {
                return true;
            }
            if (Y < 0 || Y + 32 > _mapData.Size.Width * 32)
            {
                return true;
            }

            //Collision
            if (GetCellIndexUnderPlayer().Any(i => _mapData.Layers.Collision[i]))
            {
                return true;
            }

            return false;
        }
    }
}