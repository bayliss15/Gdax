// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Time
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Time API
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
        /// Get the API server time.
        /// </summary>
        /// <returns>
        /// The server time
        /// </returns>
        public async Task<ServerTime> GetTime()
        {
            var requestUri = "time";
            return await this.client.GetAsync<ServerTime>(requestUri);
        }
    }
}
