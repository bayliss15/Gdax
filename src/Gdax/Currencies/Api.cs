// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Currencies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Currencies API
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
        /// List known currencies.
        /// </summary>
        /// <returns>
        /// A list of currencies
        /// </returns>
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var requestUri = "currencies";
            return await this.client.GetAsync<IEnumerable<Currency>>(requestUri);
        }
    }
}
