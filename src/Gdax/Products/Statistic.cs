﻿namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Statistic
    {
        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }

        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        [JsonProperty("high")]
        public decimal High { get; set; }

        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        [JsonProperty("low")]
        public decimal Low { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the last.
        /// </summary>
        [JsonProperty("last")]
        public decimal Last { get; set; }

        /// <summary>
        /// Gets or sets the 30 day volume.
        /// </summary>
        [JsonProperty("volume_30day")]
        public decimal Volume30Day { get; set; }
    }
}
