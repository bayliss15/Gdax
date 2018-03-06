// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a hold on an account
    /// </summary>
    public class Hold
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        [JsonProperty("account_id")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [JsonProperty("create_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public HoldType Type { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("ref")]
        public Guid Reference { get; set; }
    }
}
