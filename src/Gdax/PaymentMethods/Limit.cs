// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a limit on a payment method
    /// </summary>
    public class Limit
    {
        /// <summary>
        /// Gets or sets the period in days.
        /// </summary>
        [JsonProperty("period_in_days")]
        public int PeriodInDays { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        [JsonProperty("total")]
        public Value Total { get; set; }

        /// <summary>
        /// Gets or sets the remaining.
        /// </summary>
        [JsonProperty("remaining")]
        public Value Remaining { get; set; }
    }
}