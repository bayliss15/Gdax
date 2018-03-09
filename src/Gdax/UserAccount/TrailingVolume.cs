// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.UserAccount
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a trailing volume.
    /// </summary>
    public class TrailingVolume
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the exchange volume.
        /// </summary>
        [JsonProperty("exchange_volume")]
        public decimal ExchangeVolume { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the date time the record was recorded.
        /// </summary>
        [JsonProperty("recorded_at")]
        public DateTime Recorded { get; set; }
    }
}
