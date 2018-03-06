// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a FIAT account
    /// </summary>
    public class FiatAccount
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        [JsonProperty("resource")]
        public string Resource { get; set; }
    }
}