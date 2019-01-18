using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08_Manhattan.Classes
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("geometry")]
        public Properties Geometry { get; set; }
    }
}
