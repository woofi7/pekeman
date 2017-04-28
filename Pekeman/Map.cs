using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pekeman
{
    public partial class Map : Panel
    {
        public Player player;

        private MapData _mapData = new MapData();
        private Image[] sprite = new Image[2048];
        private Image _fillImage;
        private const int TileSize = 32;
        private Point _centerPoint;

        public Map()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void LoadMap(String file)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sw = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                _mapData = serializer.Deserialize<MapData>(reader);
                LoadMapSprite(_mapData.TileSet);
            }
        }

        public void LoadMapSprite(string file)
        {
            var img = Image.FromFile(file);
            var width = img.Width / TileSize;
            var heigth = img.Height / TileSize;

            _fillImage = new Bitmap(TileSize * 2, TileSize * 2);
            var graphics = Graphics.FromImage(_fillImage);
            graphics.DrawImage(img, new Rectangle(0, 0, TileSize * 2, TileSize * 2), new Rectangle(img.Width - TileSize * 2, img.Height - TileSize * 2, TileSize * 2, TileSize * 2), GraphicsUnit.Pixel);
            graphics.Dispose();

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
            if (_mapData.Size == null)
            {
                LoadMap("mapTemplate.json");
            }

            Graphics g = e.Graphics;
            _centerPoint = new Point(Width / 2, Height / 2);

            Debug.WriteLine(player._x + " " + player._y);

            double centeredXCorner = player._x - _mapData.Size.Width * 32 / 2;
            double centeredYCorner = player._y - _mapData.Size.Height * 32 / 2;

            DrawOutMap(centeredYCorner, centeredXCorner, g);
            DrawMap(centeredYCorner, centeredXCorner, g);
            DrawPlayer(g);
        }

        private void DrawPlayer(Graphics g)
        {
            g.FillEllipse(Brushes.Red, _centerPoint.X - 5, _centerPoint.Y - 5, 10, 10);
        }

        private void DrawOutMap(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < Width / TileSize * 2; x++)
            {
                for (int y = 0; y < Height / TileSize * 2; y++)
                {
                    int posY = (y * TileSize * 2) - ((int) centeredYCorner - ((int) centeredYCorner / 64) * 32);
                    int posX = (x * TileSize * 2) - ((int) centeredXCorner - ((int) centeredXCorner / 64) * 32);

                    g.DrawImageUnscaled(_fillImage, posY, posX, TileSize * 2, TileSize * 2);
                }
            }
        }

        private void DrawMap(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < _mapData.Size.Width; x++)
            {
                for (int y = 0; y < _mapData.Size.Height; y++)
                {
                    int tileIndexBackground = _mapData.Layers.Background[x * _mapData.Size.Width + y];
                    int tileIndexForeground = _mapData.Layers.Foreground[x * _mapData.Size.Width + y];

                    int posY = (int) centeredYCorner + y * TileSize;
                    int posX = (int) centeredXCorner + x * TileSize;

                    g.DrawImageUnscaled(sprite[tileIndexBackground], posX, posY, TileSize, TileSize);
                    g.DrawImageUnscaled(sprite[tileIndexForeground], posX, posY, TileSize, TileSize);
                }
            }
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

            [JsonProperty("layers")]
            public MapLayers Layers { get; set; }

            [JsonProperty("events")]
            public MapEvent[] Events { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MapSize
        {
            [JsonProperty("width")]
            public int Width { get; private set; }

            [JsonProperty("height")]
            public int Height { get; private set; }
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
            public MapSize From { get; set; }

            [JsonProperty("to")]
            public MapSize To { get; set; }
        }

        public enum EventTypeEnum
        {
            EnterPokedex,
            MeetPokemon
        }

        public void MovePlayer(float distance)
        {
            if (distance != 0)
            {
                player.MovePlayer(distance);
                Refresh();
            }
        }
    }
}
