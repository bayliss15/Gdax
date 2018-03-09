// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Currencies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Currencies API
    /// </summary>
    public class CurrenciesService
    {
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesService"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal CurrenciesService(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Get a list of known currencies.
        /// </summary>
        /// <returns>
        /// A list of currencies
        /// </returns>
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var request = this.client.CreateRequest("currencies");
            return await this.client.GetResponseAsync<IEnumerable<Currency>>(request);
        }
    }
}
