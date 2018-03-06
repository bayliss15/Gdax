// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using Newtonsoft.Json;

    public class Trade
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

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
        /// Gets or sets the side.
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; }
    }
}
