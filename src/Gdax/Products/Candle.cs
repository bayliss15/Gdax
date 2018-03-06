// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    [JsonConverter(typeof(CandleConverter))]
    [DebuggerDisplay("Time: {Time}, Low: {Low}, High: {High}, Open: {Open}, Close: {Close}, Volume: {Volume}")]
    public class Candle
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        public decimal Volume { get; set; }
    }
}
