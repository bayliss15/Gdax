﻿// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An enumeration of transfer types
    /// </summary>
    public enum TransferType
    {
        [EnumMember(Value = "deposit")]
        Deposit,

        [EnumMember(Value = "withdraw")]
        Withdraw
    }
}
