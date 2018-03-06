// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a limit on a payment method
    /// </summary>
    public class Limit
    {
        [JsonProperty("period_in_days")]
        public int PeriodInDays { get; set; }

        [JsonProperty("total")]
        public Value Total { get; set; }

        [JsonProperty("remaining")]
        public Value Remaining { get; set; }
    }
}