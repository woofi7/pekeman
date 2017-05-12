using System;
using System.IO;
using Newtonsoft.Json;

namespace Pekeman
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("elementType")]
        public string[] ElementType { get; set; }

        [JsonProperty("hp")]
        public int MaximumHp { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("catchRate")]
        public int CatchRate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("attack")]
        public int Attack { get; set; }

        [JsonProperty("defence")]
        public int Defence { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("generation")]
        public int[] Generation { get; set; }

        [JsonProperty("imgFront")]
        public string ImgFront { get; set; }

        [JsonProperty("imgBack")]
        public string ImgBack { get; set; }

        public int Level = 1;
        public int CurrentHp;
        private Random _random = new Random();

        public bool CanBeCatch(Pokemon wild)
        {
            double a = wild.CurrentHp * 2.0;
            double b = wild.MaximumHp * 3.0;
            double c = wild.CatchRate;
            double d = 0;

            if (b > 255.0)
            {
                a = Math.Floor(Math.Floor(a / 2.0) / 2.0);
                b = Math.Floor(Math.Floor(b / 2.0) / 2.0);
            }
            else
            {
                if (a == 0.0)
                {
                    a = 1.0;
                }
            }

            double x = Math.Floor((b - a) * c / b + d);

            if (x > 255.0)
            {
                return true;
            }
            else
            {
                int chance = _random.Next(0, 255);
                if (chance >= x)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanEscape(Pokemon opposant, int nbEscape)
        {
            double a = Speed;
            double b = opposant.Speed / 4.0 % 256.0;
            double c = nbEscape + 1.0;
            double f = a * 32.0 / b + 30.0 * c;

            if (f > 255.0)
            {
                return true;
            }
            else
            {
                double chance = _random.Next(0, 255);
                if (chance >= f)
                {
                    return true;
                }
            }

            return false;
        }

        public int Dammage(Pokemon attacker, Pokemon defender)
        {
            double a = attacker.Attack;
            double b = attacker.Attack;
            double c = CritMultiplyer();
            double d = defender.Defence;
            double r = _random.Next(217, 255);
            double dmg = ((((attacker.Level * .04 * c) + 2) * a * b / 50 / d) + 2) * r / 255;
            return (int) dmg;
        }

        
        private double CritMultiplyer()
        {
            double c = 1;
            int i = _random.Next(1, 101);
            if (i <= 15)
            {
                c = 1.15;
            }
            return c;
        }
    }
}