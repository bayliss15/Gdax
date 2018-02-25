namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Book
    {
        [JsonProperty("sequence")]
        public decimal Sequence { get; set; }

        [JsonProperty("asks")]
        public IEnumerable<PriceLevel> Asks { get; set; }

        [JsonProperty("bids")]
        public IEnumerable<PriceLevel> Bids { get; set; }
    }
}
