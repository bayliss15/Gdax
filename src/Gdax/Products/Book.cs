namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Book
    {
        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        [JsonProperty("sequence")]
        public decimal Sequence { get; set; }

        /// <summary>
        /// Gets or sets the asks.
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<PriceLevel> Asks { get; set; }

        /// <summary>
        /// Gets or sets the bids.
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<PriceLevel> Bids { get; set; }
    }
}
