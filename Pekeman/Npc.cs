namespace Pekeman
{
    public class Npc
    {
        public static int MovementAnimation { get; set; } = 0;

        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }
        public double Speed { get; set; } = 1;
        public double BaseSpeed { get; set; } = 128; //Pixel/second
        public Player.Rotation Facing = new Player.Rotation();
        public string Name;

        public Npc(string name)
        {
            Name = name;
        }

        public Npc() : this("Mathieu")
        {
        }
    }
}