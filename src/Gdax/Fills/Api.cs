// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Fills
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Api
    {
        private Client client;

        internal Api(Client client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Fill>> GetFills(Guid? orderId = null, string productId = null)
        {
            if (orderId != null && !string.IsNullOrWhiteSpace(productId)) { throw new ArgumentNullException("You cannot filter by orderId and productId"); }

            var requestUri = "fills";
            if (orderId != null) { requestUri += string.Format("?orderId={0}", orderId); }
            if (!string.IsNullOrWhiteSpace(productId)) { requestUri += string.Format("?productId={0}", orderId); }

            return await this.client.GetAsync<IEnumerable<Fill>>(requestUri);
        }
    }
}
