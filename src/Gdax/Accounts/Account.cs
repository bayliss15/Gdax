// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the available.
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// Gets or sets the hold.
        /// </summary>
        [JsonProperty("hold")]
        public decimal Hold { get; set; }

        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        [JsonProperty("profile_id")]
        public Guid ProfileId { get; set; }
    }
}