// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    /// <summary>
    /// An enumeration representing order book level
    /// </summary>
    public enum OrderBookLevel
    {
        /// <summary>
        /// Only the best bid and ask.
        /// </summary>
        One = 1,

        /// <summary>
        /// Top 50 bids and asks (aggregated)
        /// </summary>
        Two = 2,

        /// <summary>
        /// Full order book (non aggregated)
        /// </summary>
        Three = 3,
    }
}
