﻿// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a transcation for an account
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        [JsonProperty("details")]
        public TransactionDetail Detail { get; set; }
    }
}
