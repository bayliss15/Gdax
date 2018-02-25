namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Statistic
    {
        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
}
