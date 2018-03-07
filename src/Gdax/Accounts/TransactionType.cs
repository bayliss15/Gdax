// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An enumeraction of transaction types
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// A transfer transaction
        /// </summary>
        [EnumMember(Value = "transfer")]
        Transfer,

        /// <summary>
        /// A match transaction
        /// </summary>
        [EnumMember(Value = "match")]
        Match,

        /// <summary>
        /// A rebate transaction
        /// </summary>
        [EnumMember(Value = "fee")]
        Fee,

        /// <summary>
        /// A rebate transaction
        /// </summary>
        [EnumMember(Value = "rebate")]
        Rebate
    }
}
