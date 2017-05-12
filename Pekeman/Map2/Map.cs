using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pekeman.Entity;
using Pekeman.Properties;

namespace Pekeman.Map2
{
    public partial class Map : Panel
    {
        public FrmPekeman FrmPekeman;
        public BattleManager Battle = new BattleManager();
        public MapDataJson MapData = new MapDataJson();

        private readonly Image[] _sprite = new Image[2048];
        private const int TileSize = 32;

        private Image _fillImage;
        private Point _centerPoint;
        private Player _player;

        public Map()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Initialiser les paramètres par défaut de la map.
        /// </summary>
        /// <param name="frm">Le frame du parent.</param>
        public void InitializeMap(FrmPekeman frm)
        {
            FrmPekeman = frm;

            LoadMap("../../../mapTemplate.json");
            _player = new Player(MapData);
            FrmPekeman.ThePlayer = _player;

            FrmPekeman.ThePlayer.X = MapData.Spawn.X * 32 + 10;
            FrmPekeman.ThePlayer.Y = MapData.Spawn.Y * 32 + 10;

            Battle.InitialzeBattleManager(this);
            Controls.Add(Battle);
        }

        /// <summary>
        /// Dessiner les différents composants sur le panel. Tous centré sur le joueur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Map_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                _centerPoint = new Point(Width / 2, Height / 2);

                double centeredXCorner = _centerPoint.X - FrmPekeman.ThePlayer.X;
                double centeredYCorner = _centerPoint.Y - FrmPekeman.ThePlayer.X;

                DrawOutMap(centeredYCorner, centeredXCorner, g);
                DrawBackground(centeredYCorner, centeredXCorner, g);
                DrawnNpc(g);
                DrawPlayer(g);
                DrawForeground(centeredYCorner, centeredXCorner, g);
                DrawDebug(g);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        /// Dessiner le joueur centré sur le panel.
        /// </summary>
        /// <param name="g">Élément graphique</param>
        private void DrawPlayer(Graphics g)
        {
            int posX = _centerPoint.X - 16; //Le coin haut/gauche pour centrer le joueur
            int posY = _centerPoint.Y - 16; //Le coin haut/gauche pour centrer le joueur
            int mouvementAnimationX = _player.MovementAnimation * 32;
            int mouvementAnimationY = ComputeMouvementAnimationY((int) _player.Angle);

            g.DrawImage(Resources.player, new Rectangle(posX, posY, 32, 32),
                new Rectangle(mouvementAnimationX, mouvementAnimationY, 32, 32), GraphicsUnit.Pixel);

            DrawPseudo(g, posX, posY, _player.Name);
        }

        /// <summary>
        /// Dessiner le npc sur la carte.
        /// </summary>
        /// <param name="g">Élément graphique</param>
        private void DrawnNpc(Graphics g)
        {
            foreach (var npc in Npc.NpcList)
            {
                double cornerScreenX = Width / 2D - (MapData.Size.Width / 2D + _player.X);
                double cornerScreenY = Height / 2D - (MapData.Size.Height / 2D + _player.Y);

                int posX = (int) (npc.X + cornerScreenX);
                int posY = (int) (npc.Y + cornerScreenY);
                int mouvementAnimationX = npc.MovementAnimation * 32;
                int mouvementAnimationY = ComputeMouvementAnimationY((int) npc.Angle);

                g.DrawImage(Resources.npc, new Rectangle(posX, posY, 32, 32),
                    new Rectangle(mouvementAnimationX, mouvementAnimationY, 32, 32), GraphicsUnit.Pixel);

                DrawPseudo(g, posX, posY, npc.Name);
            }
        }

        /// <summary>
        /// Dessiner le pseudo au-dessus de l'entité.
        /// </summary>
        /// <param name="g">Élément graphique</param>
        /// <param name="posX">Position x de l'entité.</param>
        /// <param name="posY">Position y de l'entité.</param>
        /// <param name="name">Chaine à afficher</param>
        private void DrawPseudo(Graphics g, int posX, int posY, string name)
        {
            Font font = new Font("Arial", 10, FontStyle.Bold);
            SizeF size = g.MeasureString(name, font);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 32, 32, 32));
            g.FillRectangle(brush, posX - (size.Width - 32) / 2, posY - 20, size.Width, size.Height);
            g.DrawString(name, font, Brushes.WhiteSmoke, posX - (size.Width - 32) / 2 + 1, posY - 20);
        }

        /// <summary>
        /// Afficher les informations sur l'emplacement du joueur et la map.
        /// </summary>
        /// <param name="g">Élément graphique</param>
        private void DrawDebug(Graphics g)
        {
            if (Debug.DebugMode)
            {
                int posX = (int) Math.Floor(_player.X / 32);
                int posY = (int) Math.Floor(_player.Y / 32);

                int index = posX * MapData.Size.Width + posY;

                Brush myBrush = new SolidBrush(Color.FromArgb(128, 32, 32, 32));
                g.FillRectangle(myBrush, 0, 0, 180, 192);

                Font myFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                g.DrawString("Debug mode", myFont, Brushes.White, 0, 0);
                g.DrawString("x: ", myFont, Brushes.White, 0, 18);
                g.DrawString("y: ", myFont, Brushes.White, 0, 36);
                g.DrawString("Angle: ", myFont, Brushes.White, 0, 54);
                g.DrawString("Arrière plan: ", myFont, Brushes.White, 0, 72);
                g.DrawString("Premier plan: ", myFont, Brushes.White, 0, 90);
                g.DrawString((_player.X / 32).ToString("#0.0"), myFont, Brushes.Red, 16, 18);
                g.DrawString((_player.Y / 32).ToString("#0.0"), myFont, Brushes.Blue, 16, 36);
                g.DrawString((_player.Angle * 180 / Math.PI).ToString("#0"), myFont, Brushes.White, 54, 54);
                g.DrawString(MapData.Layers.Background[index].ToString(), myFont, Brushes.White, 100, 72);
                g.DrawString(MapData.Layers.Foreground[index].ToString(), myFont, Brushes.White, 108, 90);
            }
        }

        /// <summary>
        /// Dessiner l'extérieur de la map.
        /// </summary>
        /// <param name="centeredYCorner">Le coin haut/gauche de la map.</param>
        /// <param name="centeredXCorner">Le coin haut/gauche de la map.</param>
        /// <param name="g">Élément graphique</param>
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

        /// <summary>
        /// Dessiner l'arrière-plan de la map.
        /// </summary>
        /// <param name="centeredYCorner">Le coin haut/gauche de la map.</param>
        /// <param name="centeredXCorner">Le coin haut/gauche de la map.</param>
        /// <param name="g">Élément graphique</param>
        private void DrawBackground(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < MapData.Size.Width; x++)
            {
                for (int y = 0; y < MapData.Size.Height; y++)
                {
                    int tileIndexBackground = MapData.Layers.Background[x * MapData.Size.Width + y];

                    int posY = (int) centeredYCorner + y * TileSize;
                    int posX = (int) centeredXCorner + x * TileSize;

                    if (posX < -TileSize || posY < -TileSize || posX > Width || posY > Height)
                    {
                        continue;
                    }
                    g.DrawImageUnscaled(_sprite[tileIndexBackground], posX, posY, TileSize, TileSize);
                }
            }
        }

        /// <summary>
        /// Dessiner l'avant-plan de la map.
        /// </summary>
        /// <param name="centeredYCorner">Le coin haut/gauche de la map.</param>
        /// <param name="centeredXCorner">Le coin haut/gauche de la map.</param>
        /// <param name="g">Élément graphique</param>
        private void DrawForeground(double centeredYCorner, double centeredXCorner, Graphics g)
        {
            for (int x = 0; x < MapData.Size.Width; x++)
            {
                for (int y = 0; y < MapData.Size.Height; y++)
                {
                    int tileIndexForeground = MapData.Layers.Foreground[x * MapData.Size.Width + y];

                    int posY = (int) centeredYCorner + y * TileSize;
                    int posX = (int) centeredXCorner + x * TileSize;

                    if (posX < -TileSize || posY < -TileSize || posX > Width || posY > Height)
                    {
                        continue;
                    }
                    g.DrawImageUnscaled(_sprite[tileIndexForeground], posX, posY, TileSize, TileSize);
                }
            }
        }

        /// <summary>
        /// Calculer la l'image d.animation à utiliser.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static int ComputeMouvementAnimationY(int angle)
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

        /// <summary>
        /// Charger la map dans le format JSON.
        /// </summary>
        /// <param name="file">Chemin vers le fichier de la map.</param>
        public void LoadMap(String file)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sw = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                MapData = serializer.Deserialize<MapDataJson>(reader);
            }
            LoadMapTileset(MapData.TileSet);
        }

        /// <summary>
        /// Changer le tileset de la map en mémoire et générer l'image de
        /// remplissage.
        /// </summary>
        /// <param name="file">Chemin vers le tileset.</param>
        public void LoadMapTileset(string file)
        {
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
                    _sprite[index] = new Bitmap(width, heigth);
                    graphics = Graphics.FromImage(_sprite[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, TileSize, TileSize), new Rectangle(j * TileSize, i * TileSize, TileSize, TileSize), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
        }

        /// <summary>
        /// Terminer la partie.
        /// </summary>
        public void EndGame()
        {

        }

        /// <summary>
        /// Capturer un pokémon.
        /// </summary>
        /// <param name="wild"></param>
        public void CatchPokemon(Pokemon wild)
        {

        }
    }
}
