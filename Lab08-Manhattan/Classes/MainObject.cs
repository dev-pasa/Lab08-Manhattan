using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08_Manhattan.Classes
{
    public class MainObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
