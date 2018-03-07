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
        /// <summary>
        /// Gets or sets the trade identifier.
        /// </summary>
        [JsonProperty("trade_id")]
        public long TradeId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

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
        /// Gets or sets the order identifier.
        /// </summary>
        [JsonProperty("order_id")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        [JsonProperty("profile_id")]
        public Guid ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the liquidity.
        /// </summary>
        [JsonProperty("liquidity")]
        public string Liquidity { get; set; }

        /// <summary>
        /// Gets or sets the fee.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Fill"/> is settled.
        /// </summary>
        [JsonProperty("settled")]
        public bool Settled { get; set; }

        /// <summary>
        /// Gets or sets the side.
        /// </summary>
        [JsonProperty("side")]
        public FillSide Side { get; set; }

        /// <summary>
        /// Gets or sets the USD volume.
        /// </summary>
        [JsonProperty("usd_volume")]
        public decimal UsdVolume { get; set; }
    }
}