using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
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
        public Npc[] NpcList;

        public MapData _mapData = new MapData();

        
        private Image[] sprite = new Image[2048];
        private Image _fillImage;
        private const int TileSize = 32;
        private Point _centerPoint;
        public FrmPekeman frmPekeman;

        public Map()
        {
            InitializeComponent();
        }
        
        public void InitializeMap(FrmPekeman frm)
        {
            DoubleBuffered = true;

            LoadMap("../../../mapTemplate.json");
            LoadPokemon();
            LoadNpc();
            frmPekeman = frm;
            Battle = new BattleManager(this);
            Battle.InitialzeBattleManager(frm);
            Battle.Visible = false;
            Controls.Add(Battle);

            EventZones = new EventManager(Battle);
        }

        public void LoadNpc()
        {
            NpcList = new Npc[_mapData.Npc.Length];

            for (var i = 0; i < _mapData.Npc.Length; i++)
            {
                Thread.Sleep(20);
                var tmpNpc = new Npc
                {
                    Name = _mapData.Npc[i].Name,
                    X = _mapData.Npc[i].Spawn.X,
                    Y = _mapData.Npc[i].Spawn.Y
                };

                NpcList[i] = tmpNpc;
                tmpNpc.StartThread(_mapData);
            }
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

        public void PartieTerminer()
        {
            
        }

        public void CatchPokemon(Pokemon wild)
        {
            
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
                Graphics g = e.Graphics;
                _centerPoint = new Point(Width / 2, Height / 2);

                double centeredXCorner = Width / 2D - (player.ScreenX);
                double centeredYCorner = Height / 2D - ( player.ScreenY);

                DrawOutMap(centeredYCorner, centeredXCorner, g);
                DrawBackground(centeredYCorner, centeredXCorner, g);
                DrawPlayer(g);
                DrawnNpc(g);
                DrawForeground(centeredYCorner, centeredXCorner, g);
                DrawDebug(g);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DrawPlayer(Graphics g)
        {
            int posX = _centerPoint.X - 16;
            int posY = _centerPoint.Y - 16;
            int sourceX = player.MovementAnimation * 32;
            int sourceY = ComputeSourceY((int) player.Angle);

            g.DrawImage(Resources.player, new Rectangle(posX, posY, 32, 32), new Rectangle(sourceX, sourceY
                , 32, 32), GraphicsUnit.Pixel);

            DrawPseudo(g, posX, posY, player.Name);
        }

        private void DrawnNpc(Graphics g)
        {
            foreach (var npc in NpcList)
            {

                double tmpX = npc.ScreenX;
                double tmpY = npc.ScreenY;
                double mapWidth = Width;
                double mapHeight = Height;
                double cornerScreenX = mapWidth / 2D - (_mapData.Size.Width / 2D + player.ScreenX);
                double cornerScreenY = mapHeight / 2D - (_mapData.Size.Height / 2D + player.ScreenY);

                tmpX = cornerScreenX + tmpX;
                tmpY = cornerScreenY + tmpY;

                int posX = (int) tmpX;
                int posY = (int) tmpY;

                int sourceX = npc.MovementAnimation * 32;
                int sourceY = ComputeSourceY((int) npc.Angle);

                g.DrawImage(Resources.npc, new Rectangle(posX, posY, 32, 32), new Rectangle(sourceX, sourceY
                    , 32, 32), GraphicsUnit.Pixel);

                DrawPseudo(g, posX, posY, npc.Name);
            }
        }

        private static int ComputeSourceY(int angle)
        {
            int sourceY = 0;

            switch (angle)
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
            return sourceY;
        }

        private void DrawPseudo(Graphics g, int posX, int posY, string name)
        {
            Font font = new Font("Arial", 10, FontStyle.Bold);
            SizeF size = g.MeasureString(name, font);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 32, 32, 32));
            g.FillRectangle(brush, posX - (size.Width - 32) / 2, posY - 20, size.Width, size.Height);
            g.DrawString(name, font, Brushes.WhiteSmoke, posX - (size.Width - 32) / 2 + 1, posY - 20);
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

        private void DrawOutMap(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < Width / TileSize * 2; x++)
            {
                for (int y = 0; y < Height / TileSize * 2; y++)
                {
                    int posY = y * TileSize * 2 + (int)( centeredYCorner - centeredYCorner / 64) - Height / 2;
                    int posX = x * TileSize * 2 + (int)( centeredXCorner - centeredXCorner / 64) - Width / 2;

                    if (posX < -TileSize  * 2|| posY < -TileSize * 2 || posX > Width || posY > Height)
                    {
                        continue;
                    }
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

                    if (posX < -TileSize || posY < -TileSize || posX > Width || posY > Height)
                    {
                        continue;
                    }
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

                    if (posX < -TileSize || posY < -TileSize || posX > Width || posY > Height)
                    {
                        continue;
                    }
                    g.DrawImageUnscaled(sprite[tileIndexForeground], posX, posY, TileSize, TileSize);
                }
            }
        }

        public int GetCellIndex(int x, int y)
        {
            return x * _mapData.Size.Width + y;
        }

        public IEnumerable<int> GetCellIndexUnderPlayer()
        {
            int posXMin = (int) Math.Floor((player.ScreenX - 8) / 32);
            int posXMax = (int) Math.Floor((player.ScreenX + 8) / 32);
            int posYMin = (int) Math.Floor((player.ScreenY - 0) / 32);
            int posYMax = (int) Math.Floor((player.ScreenY + 8) / 32);

            for (int x = posXMin; x <= posXMax; x++)
            {
                for (int y = posYMin; y <= posYMax; y++)
                {
                    yield return GetCellIndex(x, y);
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
            int posXMin = (int) Math.Floor((player.ScreenX - 8) / 32);
            int posXMax = (int) Math.Floor((player.ScreenX + 16) / 32);
            int posYMin = (int) Math.Floor((player.ScreenY - 8) / 32);
            int posYMax = (int) Math.Floor((player.ScreenY + 16) / 32);


            //Out of map
            if (player.ScreenX < 0 || player.ScreenX + 32 > _mapData.Size.Width * 32)
            {
                player.ScreenX = oldX;
            }

            if (player.ScreenY < 0 || player.ScreenY+ 32 > _mapData.Size.Height * 32)
            {
                player.ScreenY = oldY;
            }

            //Collision

            if (GetCellIndexUnderPlayer().Any(i => _mapData.Layers.Collision[i]))
            {
                player.ScreenX = oldX;
                player.ScreenY = oldY;
            }

            EventZones.CheckEvent(_mapData.Events, player.ScreenX, player.ScreenY, oldX, oldY, frmPekeman);
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

            [JsonProperty("npc")]
            public NpcData[] Npc { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class NpcData
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("spawn")]
            public MapPos Spawn { get; set; }
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

        public void UpdateMovementAnimation()
        {
            foreach (var npc1 in NpcList)
            {
                npc1.UpdateMovementAnimation();
            }
        }
    }
}
