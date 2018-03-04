namespace Gdax.Products
{
    using Newtonsoft.Json;

    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the base currency.
        /// </summary>
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Gets or sets the quote currency.
        /// </summary>
        [JsonProperty("quote_currency")]
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// Gets or sets the minimum size of the base.
        /// </summary>
        [JsonProperty("base_min_size")]
        public decimal BaseMinSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the base.
        /// </summary>
        [JsonProperty("base_max_size")]
        public decimal BaseMaxSize { get; set; }

        /// <summary>
        /// Gets or sets the quote increment.
        /// </summary>
        [JsonProperty("quote_increment")]
        public decimal QuoteIncrement { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [margin enabled].
        /// </summary>
        [JsonProperty("margin_enabled")]
        public bool MarginEnabled { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the minimum market funds.
        /// </summary>
        [JsonProperty("min_market_funds")]
        public decimal? MinMarketFunds { get; set; }

        /// <summary>
        /// Gets or sets the maximum market funds.
        /// </summary>
        [JsonProperty("max_market_funds")]
        public decimal? MaxMarketFunds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [post only].
        /// </summary>
        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [limit only].
        /// </summary>
        [JsonProperty("limit_only")]
        public bool LimitOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [cancel only].
        /// </summary>
        [JsonProperty("cancel_only")]
        public bool CancelOnly { get; set; }
    }
}
