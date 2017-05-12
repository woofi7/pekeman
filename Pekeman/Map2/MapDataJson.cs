using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pekeman.Map2
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MapDataJson
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
}