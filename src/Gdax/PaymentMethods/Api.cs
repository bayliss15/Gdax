// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
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

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            var requestUri = "payment-methods";

            return await this.client.GetAsync<IEnumerable<PaymentMethod>>(requestUri);
        }
    }
}
