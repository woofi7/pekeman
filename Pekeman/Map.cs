using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pekeman.Properties;

namespace Pekeman
{
    public partial class Map : Panel
    {
        public Player player;

        public BattleManager Battle;
        public EventManager EventZones;
        public Pokemon[] PokemonList;

        private MapData _mapData = new MapData();
        private Image[] sprite = new Image[2048];
        private Image _fillImage;
        private const int TileSize = 32;
        private Point _centerPoint;

        public Map()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Battle = new BattleManager(this);

            EventZones = new EventManager(Battle);
            LoadPokemon();
        }

        public void LoadPokemon()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader sw = new StreamReader("../../../pekeman.json"))
                using (JsonReader reader = new JsonTextReader(sw))
                {
                    PokemonList = serializer.Deserialize<Pokemon[]>(reader);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void LoadMap(String file)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sw = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                _mapData = serializer.Deserialize<MapData>(reader);
            }
            LoadMapSprite(_mapData.TileSet);
            player.ScreenX = _mapData.Spawn.X * 32 + 10;
            player.ScreenY = _mapData.Spawn.Y * 32 + 10;
        }

        public void LoadMapSprite(string file)
        {
            if (file == "")
            {
                return;
            }

            var img = Image.FromFile(file);
            var width = img.Width / TileSize;
            var heigth = img.Height / TileSize;

            //Fill image
            _fillImage = new Bitmap(TileSize * 2, TileSize * 2);
            var graphics = Graphics.FromImage(_fillImage);
            graphics.DrawImage(img, new Rectangle(0, 0, TileSize * 2, TileSize * 2), new Rectangle(img.Width - TileSize * 2, img.Height - TileSize * 2, TileSize * 2, TileSize * 2), GraphicsUnit.Pixel);
            graphics.Dispose();

            //Tileset
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < heigth; j++)
                {
                    var index = i * heigth + j;
                    sprite[index] = new Bitmap(width, heigth);
                    graphics = Graphics.FromImage(sprite[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, TileSize, TileSize), new Rectangle(j * TileSize, i * TileSize, TileSize, TileSize), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (_mapData.Size == null)
                    {
                        LoadMap("../../../mapTemplate.json");
                    }

                    Graphics g = e.Graphics;
                    _centerPoint = new Point(Width / 2, Height / 2);

                    double centeredXCorner = Width / 2D - (_mapData.Size.Width / 2D + player.ScreenX);
                    double centeredYCorner = Height / 2D - (_mapData.Size.Height / 2D + player.ScreenY);

                    DrawOutMap(centeredYCorner, centeredXCorner, g);
                    DrawBackground(centeredYCorner, centeredXCorner, g);
                    DrawPlayer(g);
                    DrawForeground(centeredYCorner, centeredXCorner, g);
                    DrawDebug(g);
                }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DrawDebug(Graphics g)
        {
            if (Debug.DebugMode)
            {
                int posX = (int) Math.Floor(player.ScreenX / 32);
                int posY = (int) Math.Floor(player.ScreenY / 32);

                int index = posX * _mapData.Size.Width + posY;

                Brush myBrush = new SolidBrush(Color.FromArgb(128, 32, 32, 32));
                g.FillRectangle(myBrush, 0, 0, 180, 192);

                Font myFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                g.DrawString("Debug mode", myFont, Brushes.White, 0, 0);
                g.DrawString("x: ", myFont, Brushes.White, 0, 18);
                g.DrawString("y: ", myFont, Brushes.White, 0, 36);
                g.DrawString("Angle: ", myFont, Brushes.White, 0, 54);
                g.DrawString("Arrière plan: ", myFont, Brushes.White, 0, 72);
                g.DrawString("Premier plan: ", myFont, Brushes.White, 0, 90);
                g.DrawString((player.ScreenX / 32).ToString("#0.0"), myFont, Brushes.Red, 16, 18);
                g.DrawString((player.ScreenY / 32).ToString("#0.0"), myFont, Brushes.Blue, 16, 36);
                g.DrawString((player.Angle * 180 / Math.PI).ToString("#0"), myFont, Brushes.White, 54, 54);
                g.DrawString(_mapData.Layers.Background[index].ToString(), myFont, Brushes.White, 100, 72);
                g.DrawString(_mapData.Layers.Foreground[index].ToString(), myFont, Brushes.White, 108, 90);
            }
        }

        private void DrawPlayer(Graphics g)
        {
            int posX = _centerPoint.X - 16;
            int posY = _centerPoint.Y - 16;
            int sourceX = player.MovementAnimation * 32;
            int sourceY = 0;


            switch ((int) player.Angle)
            {
                case 0:
                    sourceY = 32;
                    break;
                case (int) Math.PI / 2:
                    sourceY = 96;
                    break;
                case (int) Math.PI:
                    sourceY = 64;
                    break;
                case (int) (Math.PI + Math.PI / 2):
                    sourceY = 0;
                    break;
            }

            Font font = new Font("Arial", 10, FontStyle.Bold);

            SizeF size = g.MeasureString(player.Name, font);

            System.Diagnostics.Debug.WriteLine(size.Width + " " + size.Height);


            g.DrawImage(Resources.player, new Rectangle(posX, posY, 32, 32), new Rectangle(sourceX, sourceY
                , 32, 32), GraphicsUnit.Pixel);

            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 32, 32, 32));
            g.FillRectangle(brush, posX - (size.Width - 32) / 2, posY - 20, size.Width, size.Height);
            g.DrawString(player.Name, font, Brushes.WhiteSmoke, posX - (size.Width - 32) / 2 + 1, posY - 20);
        }

        private void DrawOutMap(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < Width / TileSize * 2; x++)
            {
                for (int y = 0; y < Height / TileSize * 2; y++)
                {
                    int posY = y * TileSize * 2 + (int)( centeredYCorner - centeredYCorner / 64) - Height / 2;
                    int posX = x * TileSize * 2 + (int)( centeredXCorner - centeredXCorner / 64) - Width / 2;

                    g.DrawImageUnscaled(_fillImage, posX, posY, TileSize * 2, TileSize * 2);
                }
            }
        }

        private void DrawBackground(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < _mapData.Size.Width; x++)
            {
                for (int y = 0; y < _mapData.Size.Height; y++)
                {
                    int tileIndexBackground = _mapData.Layers.Background[x * _mapData.Size.Width + y];

                    int posY = (int) centeredYCorner + y * TileSize;
                    int posX = (int) centeredXCorner + x * TileSize;

                    g.DrawImageUnscaled(sprite[tileIndexBackground], posX, posY, TileSize, TileSize);
                }
            }
        }

        private void DrawForeground(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < _mapData.Size.Width; x++)
            {
                for (int y = 0; y < _mapData.Size.Height; y++)
                {
                    int tileIndexForeground = _mapData.Layers.Foreground[x * _mapData.Size.Width + y];

                    int posY = (int) centeredYCorner + y * TileSize;
                    int posX = (int) centeredXCorner + x * TileSize;

                    g.DrawImageUnscaled(sprite[tileIndexForeground], posX, posY, TileSize, TileSize);
                }
            }
        }

        public void MovePlayer(float distance)
        {
            if (distance == 0) return;

            double oldX = player.ScreenX;
            double oldY = player.ScreenY;
            player.MovePlayer(distance);

            int posX = (int) Math.Floor(player.ScreenX / 32);
            int posY = (int) Math.Floor(player.ScreenY / 32);

            //Out of map
            if (posX < 0 || posX > _mapData.Size.Width - 1)
            {
                player.ScreenX = oldX;
                posX = (int) Math.Floor(player.ScreenX / 32);
            }
            else if (posY < 0 || posY > _mapData.Size.Height - 1)
            {
                player.ScreenY = oldY;
                posY = (int) Math.Floor(player.ScreenY / 32);
            }

            //Collision
            int collisionIndex = posX * _mapData.Size.Width + posY;
            if (!_mapData.Layers.Collision[collisionIndex])
            {
                player.ScreenX = oldX;
                player.ScreenY = oldY;
            }


            EventZones.CheckEvent(_mapData.Events, player.ScreenX, player.ScreenY, oldX, oldY);
            Refresh();
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapData
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("tileset")]
            public string TileSet { get; set; }

            [JsonProperty("size")]
            public MapSize Size { get; set; }

            [JsonProperty("spawn")]
            public MapPos Spawn { get; set; }

            [JsonProperty("layers")]
            public MapLayers Layers { get; set; }

            [JsonProperty("events")]
            public MapEvent[] Events { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapSize
        {
            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapLayers
        {
            [JsonProperty("background")]
            public int[] Background { get; set; }

            [JsonProperty("collision")]
            public bool[] Collision { get; set; }

            [JsonProperty("foreground")]
            public int[] Foreground { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapEvent
        {
            [JsonProperty("eventType")]
            [JsonConverter(typeof(StringEnumConverter))]
            public EventTypeEnum EventType { get; set; }

            [JsonProperty("chances")]
            public float Chances { get; set; }

            [JsonProperty("area")]
            public MapArea Area { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapArea
        {
            [JsonProperty("from")]
            public MapPos From { get; set; }

            [JsonProperty("to")]
            public MapPos To { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapPos
        {
            [JsonProperty("x")]
            public int X { get; set; }

            [JsonProperty("y")]
            public int Y { get; set; }
        }
    }
}
