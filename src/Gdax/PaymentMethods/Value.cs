// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the value of a limit
    /// </summary>
    public class Value
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}