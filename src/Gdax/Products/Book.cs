// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the order book
    /// </summary>
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
