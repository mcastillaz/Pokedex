using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Pokedex.Clases
{
    public partial class Pokemon
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("types")]
        public Types[] Types { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("moves")]
        public Moves[] Moves { get; set; }

        [JsonProperty("stats")]
        public Stats[] Stats { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("stat")]
        public Stat Stat { get; set; }

        [JsonProperty("base_stat")]
        public string baseStat { get; set; }
        
    }

    public partial class Stat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Moves
    {
        [JsonProperty("move")]
        public Move Move { get; set; }
    }

    public partial class Move
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Sprites
    {
        [JsonProperty("other")]
        public Other Other { get; set; }

        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }
    }

    public partial class Types
    {
        [JsonProperty("type")]
        public Type Type { get; set; }
    }

    public partial class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Other
    {
        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public partial class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public string frontDefault { get; set; }
    }

    public partial class Pokemon
    {
        public static Pokemon FromJson(string json) => JsonConvert.DeserializeObject<Pokemon>(json,
            Converter.Settings);
    }

    public static class Serializar
    {
        public static string ToJson(this Pokemon self) => JsonConvert.SerializeObject(self,
            Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
