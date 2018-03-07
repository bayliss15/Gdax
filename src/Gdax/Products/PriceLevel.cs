// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a price level
    /// </summary>
    [JsonConverter(typeof(PriceLevelConverter))]
    [DebuggerDisplay("Price: {Price}, Size: {Size}")]
    public class PriceLevel
    {
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public decimal Size { get; set; }
    }
}
