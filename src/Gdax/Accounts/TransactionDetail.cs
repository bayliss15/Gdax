namespace Gdax.Accounts
{
    using System;
    using Newtonsoft.Json;

    public class TransactionDetail
    {
        // TODO: Sort this out so we get the specific classes deserialized

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        [JsonProperty("order_id")]
        public Guid? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the trade identifier.
        /// </summary>
        [JsonProperty("trade_id")]
        public long? TradeId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the transfer identifier.
        /// </summary>
        [JsonProperty("transfer_id")]
        public Guid? TransferId { get; set; }

        /// <summary>
        /// Gets or sets the type of the transfer.
        /// </summary>
        [JsonProperty("transfer_type")]
        public string TransferType { get; set; }
    }

    ////public class TransferTransactionDetail
    ////{
    ////    [JsonProperty("transfer_id")]
    ////    public Guid? TransferId { get; set; }

    ////    [JsonProperty("transfer_type")]
    ////    public string TransferType { get; set; }
    ////}

    ////public class TradeTransactionDetail 
    ////{
    ////    [JsonProperty("order_id")]
    ////    public Guid? OrderId { get; set; }

    ////    [JsonProperty("trade_id")]
    ////    public long? TradeId { get; set; }

    ////    [JsonProperty("product_id")]
    ////    public string ProductId { get; set; }
    ////}
}
