﻿// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Time
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the current server time
    /// </summary>
    public class ServerTime
    {
        /// <summary>
        /// Gets or sets the iso.
        /// </summary>
        [JsonProperty("iso")]
        public DateTime Iso { get; set; }

        /// <summary>
        /// Gets or sets the epoch.
        /// </summary>
        [JsonProperty("epoch")]
        public decimal Epoch { get; set; }
    }
}
