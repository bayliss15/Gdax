// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An enumeration representing hold types
    /// </summary>
    public enum HoldType
    {
        /// <summary>
        /// A order hold
        /// </summary>
        [EnumMember(Value = "order")]
        Order,

        /// <summary>
        /// A transfer hold
        /// </summary>
        [EnumMember(Value = "transfer")]
        Transfer
    }
}
