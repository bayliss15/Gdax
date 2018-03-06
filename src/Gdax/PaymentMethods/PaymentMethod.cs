// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a payment method
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentMethod"/> is verified.
        /// </summary>
        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        /// <summary>
        /// Gets or sets the vertification method.
        /// </summary>
        [JsonProperty("verification_method")]
        public string VertificationMethod { get; set; }

        /// <summary>
        /// Gets or sets the CDV status.
        /// </summary>
        [JsonProperty("cdv_status")]
        public string CdvStatus { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [primary buy].
        /// </summary>
        [JsonProperty("primary_buy")]
        public bool PrimaryBuy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [primary sell].
        /// </summary>
        [JsonProperty("primary_sell")]
        public bool PrimarySell { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow buy].
        /// </summary>
        [JsonProperty("allow_buy")]
        public bool AllowBuy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow sell].
        /// </summary>
        [JsonProperty("allow_sell")]
        public bool AllowSell { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow deposit].
        /// </summary>
        [JsonProperty("allow_deposit")]
        public bool AllowDeposit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow withdraw].
        /// </summary>
        [JsonProperty("allow_withdraw")]
        public bool AllowWithdraw { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        [JsonProperty("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        [JsonProperty("resource_path")]
        public string ResourcePath { get; set; }

        /// <summary>
        /// Gets or sets the limits.
        /// </summary>
        [JsonProperty("limits")]
        public Limits Limits { get; set; }

        /// <summary>
        /// Gets or sets the fiat account.
        /// </summary>
        [JsonProperty("fiat_account")]
        public FiatAccount FiatAccount { get; set; }
    }
}