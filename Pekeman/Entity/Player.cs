using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pekeman.Map2;

namespace Pekeman.Entity
{
    public class Player : Entity
    {
        public Pokemon InitialPokemon { get; set; }
        public List<Pokemon> PokemonList = new List<Pokemon>();

        public bool RightMovement;
        public bool LeftMovement;
        public bool UpMovement;
        public bool DownMovement;

        public Player(Map2.MapDataJson mapData, string name) : base(mapData, name)
        {
        }

        public Player(Map2.MapDataJson mapData) : base(mapData)
        {
        }

        /// <summary>
        /// Définir le pokémon initial du joueur. Il sera de niveau 3 par défaut.
        /// </summary>
        /// <param name="pokemon">Un pokémon</param>
        public void SetInitialPokemon(Pokemon pokemon)
        {
            InitialPokemon = pokemon;
            InitialPokemon.Level = 3;
        }

        /// <summary>
        /// Ajouter un pokémon à la liste de pokémon vu par le joueur.
        /// </summary>
        /// <param name="newPokemon">Un pokémon</param>
        /// <returns>Vrai si le pokémon à été ajouté à la liste. Faux si il est
        ///  déjà présent.</returns>
        public bool AddPokemonOnList(Pokemon newPokemon)
        {
            foreach (Pokemon pokemon in PokemonList)
            {
                if (pokemon.Name.Equals(newPokemon.Name))
                {
                    return false;
                }
            }

            PokemonList.Add(newPokemon);
            return true;
        }

        public void MovePlayer(double ellapsedSeconds)
        {
            double distance = 0;

            if (RightMovement)
            {
                distance = ellapsedSeconds * BaseSpeed;
                Angle = 0;
            }
            else if (LeftMovement)
            {
                distance = ellapsedSeconds * BaseSpeed;
                Angle = Math.PI;
            }

            else if (UpMovement)
            {
                distance = ellapsedSeconds * BaseSpeed;
                Angle = Math.PI / 2;
            }
            else if (DownMovement)
            {
                distance = ellapsedSeconds * BaseSpeed;
                Angle = 3 * Math.PI / 2;
            }

            double oldX = X;
            double oldY = Y;

            MoveEntity(distance);

            if (X / 32 != oldX / 32 && Y / 32 != oldY / 32)
            {
                CheckEvent();
            }
        }

        private void CheckEvent()
        {
            foreach (MapEvent mapEvent in MapData.Events)
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

        public void KeyPress(Keys keyCode, bool keyDown)
        {
            switch (keyCode)
            {
                case Keys.A:
                case Keys.Left:
                    LeftMovement = keyDown;
                    break;
                case Keys.D:
                case Keys.Right:
                    RightMovement = keyDown;
                    break;
                case Keys.W:
                case Keys.Up:
                    UpMovement = keyDown;
                    break;
                case Keys.S:
                case Keys.Down:
                    DownMovement = keyDown;
                    break;
            }
        }

        /// <summary>
        /// Mettre à jour les mouvements des jambes et des bras du joueur.
        /// </summary>
        public new void UpdateMovementAnimation()
        {
            if (!RightMovement && !LeftMovement && !UpMovement && !DownMovement) return;

            MovementAnimation++;
            if (MovementAnimation == 3)
            {
                MovementAnimation = 0;
            }
        }
    }
}