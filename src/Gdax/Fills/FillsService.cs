// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Fills
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Fills API
    /// </summary>
    public class FillsService
    {
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="FillsService"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal FillsService(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Get a list of recent fills.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A list of fills
        /// </returns>
        public async Task<IEnumerable<Fill>> GetFills(Guid? orderId = null, string productId = null)
        {
            if (orderId != null && !string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException("You cannot filter by orderId and productId");
            }

            var request = this.client.CreateRequest("fills", new (string, object)[] { ("orderId", orderId), ("productId", productId) });
            return await this.client.GetResponseAsync<IEnumerable<Fill>>(request);
        }
    }
}
