using System;

namespace Pekeman
{
    public class EventManager
    {
        private readonly Random _random = new Random();
        public BattleManager Battle;

        public EventManager(BattleManager battle)
        {
            Battle = battle;
        }

        public void CheckEvent(Map.MapEvent[] mapDataEvents, double curX, double curY, double prevX, double prevY)
        {
            double currentX = Math.Floor(curX / 32);
            double currentY = Math.Floor(curY / 32);
            double previousX = Math.Floor(prevX / 32);
            double previousY = Math.Floor(prevY / 32);

            if (currentX == previousX && currentY == previousY)
            {
                return;
            }

            foreach (Map.MapEvent mapEvent in mapDataEvents)
            {
                int startX = mapEvent.Area.From.X;
                int startY = mapEvent.Area.From.Y;
                int endX = mapEvent.Area.To.X;
                int endY = mapEvent.Area.To.Y;

                if (currentX < startX || currentX > endX || currentY < startY || currentY > endY) continue;
                int multiplicator = (int) (100 / (mapEvent.Chances * 100));
                float next = _random.Next(0, multiplicator);
                if (next != 0) continue;

                switch (mapEvent.EventType)
                {
                    case EventTypeEnum.EnterPokedex:
                        //TODO: Open pokedex
                        break;
                    case EventTypeEnum.EnterPekecenter:
                        //TODO: Heal pekemon
                        break;
                    case EventTypeEnum.MeetPokemon:
                        Battle.StartBattle();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public enum EventTypeEnum
    {
        EnterPokedex,
        EnterPekecenter,
        MeetPokemon
    }
}