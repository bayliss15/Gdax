namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System;

    public class Ticker
    {
        /// <summary>
        /// Gets or sets the trade identifier.
        /// </summary>
        [JsonProperty("trade_id")]
        public long TradeId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [JsonProperty("size")]
        public decimal Size { get; set; }

        /// <summary>
        /// Gets or sets the bid.
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        /// <summary>
        /// Gets or sets the ask.
        /// </summary>
        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}
