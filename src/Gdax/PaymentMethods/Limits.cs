// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the limits on a payment method
    /// </summary>
    public class Limits
    {
        /// <summary>
        /// Gets or sets the buy limits.
        /// </summary>
        [JsonProperty("buy")]
        public IEnumerable<Limit> Buy { get; set; }

        /// <summary>
        /// Gets or sets the instant buy limits.
        /// </summary>
        [JsonProperty("instant_buy")]
        public IEnumerable<Limit> InstantBuy { get; set; }

        /// <summary>
        /// Gets or sets the sell limits.
        /// </summary>
        [JsonProperty("sell")]
        public IEnumerable<Limit> Sell { get; set; }

        /// <summary>
        /// Gets or sets the deposit limits.
        /// </summary>
        [JsonProperty("deposit")]
        public IEnumerable<Limit> Deposit { get; set; }
    }
}