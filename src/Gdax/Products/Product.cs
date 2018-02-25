namespace Gdax.Products
{
    using Newtonsoft.Json;

    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quote_currency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("base_min_size")]
        public decimal BaseMinSize { get; set; }

        [JsonProperty("base_max_size")]
        public decimal BaseMaxSize { get; set; }

        [JsonProperty("quote_increment")]
        public decimal QuoteIncrement { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("margin_enabled")]
        public bool MarginEnabled { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("min_market_funds")]
        public decimal MinMarketFunds { get; set; }

        [JsonProperty("max_market_funds")]
        public decimal MaxMarketFunds { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }

        [JsonProperty("limit_only")]
        public bool LimitOnly { get; set; }

        [JsonProperty("cancel_only")]
        public bool CancelOnly { get; set; }
    }
}
