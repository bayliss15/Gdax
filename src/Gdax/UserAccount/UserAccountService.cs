// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.UserAccount
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the User Account API
    /// </summary>
    public class UserAccountService
    {
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountService"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal UserAccountService(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// This request will return your 30-day trailing volume for all products.
        /// This is a cached value that’s calculated every day at midnight UTC.
        /// </summary>
        /// <returns>
        /// The server time
        /// </returns>
        public async Task<IEnumerable<TrailingVolume>> TrailingVolume()
        {
            var request = this.client.CreateRequest("users/self/trailing-volume");
            return await this.client.GetResponseAsync<IEnumerable<TrailingVolume>>(request);
        }
    }
}
