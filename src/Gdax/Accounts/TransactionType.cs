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
        [EnumMember(Value = "transfer")]
        Transfer,

        [EnumMember(Value = "match")]
        Match,

        [EnumMember(Value = "fee")]
        Fee,

        [EnumMember(Value = "rebate")]
        Rebate
    }
}
