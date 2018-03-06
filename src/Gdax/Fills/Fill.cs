// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Fills
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Repesents a filled order
    /// </summary>
    public class Fill
    {
        [JsonProperty("trade_id")]
        public long TradeId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("order_id")]
        public Guid OrderId { get; set; }

        [JsonProperty("profile_id")]
        public Guid ProfileId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        [JsonProperty("liquidity")]
        public string Liquidity { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("settled")]
        public bool Settled { get; set; }

        [JsonProperty("side")]
        public FillSide Side { get; set; }

        [JsonProperty("usd_volume")]
        public decimal UsdVolume { get; set; }
    }
}