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
    public partial class Map : UserControl
    {
        private MapData _mapData = new MapData();

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
    }
}
