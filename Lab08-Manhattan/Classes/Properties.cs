using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08_Manhattan.Classes
{
    public class Properties
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("borough")]
        public string Borough { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }
            
    }
}
