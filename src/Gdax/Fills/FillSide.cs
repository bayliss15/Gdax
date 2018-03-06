﻿// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Fills
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An enumeration of sides for a fill
    /// </summary>
    public enum FillSide
    {
        [EnumMember(Value = "buy")]
        Buy,

        [EnumMember(Value = "sell")]
        Sell
    }
}
