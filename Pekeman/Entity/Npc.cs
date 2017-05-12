using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Pekeman.Map2;
using Pekeman.Properties;

namespace Pekeman.Entity
{
    public class Npc : Entity
    {
        public static List<Npc> NpcList = new List<Npc>();
        private Stopwatch _stopwatch;

        public Npc(MapDataJson mapData, string name) : base(mapData, name)
        {
        }

        public Npc(MapDataJson mapData) : base(mapData)
        {
        }

        /// <summary>
        /// Créer les npc avec les données passé en paramètre. Va créer un thread par
        /// npc qui va calculer son déplacement.
        /// </summary>
        /// <param name="data">Un nom et l'emplacement du spawn du npc.</param>
        public void LoadNpc(MapDataJson data)
        {
            foreach (NpcData npcData in data.Npc)
            {
                Thread.Sleep(20);
                var tmpNpc = new Npc(data)
                {
                    Name = npcData.Name,
                    X = npcData.Spawn.X * 32,
                    Y = npcData.Spawn.Y * 32
                };

                NpcList.Add(tmpNpc);
                tmpNpc.StartThread();
            }
        }

        /// <summary>
        /// Démarer le thread sur l'objet.
        /// </summary>
        public void StartThread()
        {
            Thread t = new Thread(MoveNpc);
            t.Start();
        }

        /// <summary>
        /// Gestion des déplacement du npc, sa vitesse, son orientation et la
        ///  distance qu'il parcour.
        /// </summary>
        public void MoveNpc()
        {
            double timeLeft = 0;

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
                    Angle = Random.Next(4) * Math.PI / 2;
                    Speed = 0.75 + Random.NextDouble() / 2;
                }

                MoveEntity(ellapsedSeconds * BaseSpeed);
                Thread.Sleep(30);
            }
        }
    }
}