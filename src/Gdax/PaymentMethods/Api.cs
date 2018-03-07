﻿// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.PaymentMethods
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Payment Methods API
    /// </summary>
    public class Api
    {
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal Api(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Get a list of your payment methods.
        /// </summary>
        /// <returns>
        /// A list of payment methods
        /// </returns>
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            var requestUri = "payment-methods";

            return await this.client.GetAsync<IEnumerable<PaymentMethod>>(requestUri);
        }
    }
}
