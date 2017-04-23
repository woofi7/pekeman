using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Pekeman
{
    public partial class Map : Panel
    {
        private MapData _mapData = new MapData();
        private Image[] sprite = new Image[2048];
        private Image fillImage;
        private const int TILE_SIZE = 32;

        public Map()
        {
            InitializeComponent();
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

        public void LoadMapSprite(String file)
        {
            Graphics graphics;

            Image img = Image.FromFile(file);
            int width = img.Width / TILE_SIZE;
            int heigth = img.Height / TILE_SIZE;

            fillImage = new Bitmap(TILE_SIZE * 2, TILE_SIZE * 2);
            graphics = Graphics.FromImage(fillImage);
            graphics.DrawImage(img, new Rectangle(0, 0, TILE_SIZE * 2, TILE_SIZE * 2), new Rectangle(img.Width - TILE_SIZE * 2, img.Height - TILE_SIZE * 2, TILE_SIZE * 2, TILE_SIZE * 2), GraphicsUnit.Pixel);
            graphics.Dispose();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    int index = i * heigth + j;

                    sprite[index] = new Bitmap(width, heigth);
                    graphics = Graphics.FromImage(sprite[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, TILE_SIZE, TILE_SIZE), new Rectangle(j * TILE_SIZE, i * TILE_SIZE, TILE_SIZE, TILE_SIZE), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            if (_mapData.Size == null)
            {
                LoadMap("D:\\workspace\\Pekeman\\mapTemplate.json");
            }

            Graphics g = e.Graphics;

            Point middlePoint = new Point(Width / 2, Height / 2);
            int centeredX = middlePoint.X - _mapData.Size.Width * 32 / 2;
            int centeredY = middlePoint.Y - _mapData.Size.Height * 32 / 2;

            for (int x = 0; x < Width / TILE_SIZE * 2; x++)
            {
                for (int y = 0; y < Height / TILE_SIZE * 2; y++)
                {
                    int posY = (y * TILE_SIZE * 2) - (centeredY - (centeredY / 64) * 32);
                    int posX = (x * TILE_SIZE * 2) - (centeredX - (centeredX / 64) * 32);

                    g.DrawImageUnscaled(fillImage, posY, posX, TILE_SIZE * 2, TILE_SIZE * 2);
                }
            }

            for (int x = 0; x < _mapData.Size.Width; x++)
            {
                for (int y = 0; y < _mapData.Size.Height; y++)
                {
                    int tileIndexBackground = _mapData.Layers.Background[x * _mapData.Size.Width + y];
                    int tileIndexForeground = _mapData.Layers.Foreground[x * _mapData.Size.Width + y];

                    int posY = centeredY + y * TILE_SIZE;
                    int posX = centeredX + x * TILE_SIZE;

                    g.DrawImageUnscaled(sprite[tileIndexBackground], posX, posY, TILE_SIZE, TILE_SIZE);
                    g.DrawImageUnscaled(sprite[tileIndexForeground], posX, posY, TILE_SIZE, TILE_SIZE);
                }
            }

            g.FillEllipse(Brushes.Red, middlePoint.X - 5, middlePoint.Y - 5, 10, 10);
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
    }
}
