// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Accounts API
    /// </summary>
    public class AccountsService
    {
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsService"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        internal AccountsService(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Get a list of trading accounts.
        /// </summary>
        /// <returns>
        /// A list of accounts
        /// </returns>
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var request = this.client.CreateRequest("accounts");
            return await this.client.GetResponseAsync<IEnumerable<Account>>(request);
        }

        /// <summary>
        /// Gets an account matching the specified account identifer.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// An account
        /// </returns>
        public async Task<Account> GetAccount(Guid accountId)
        {
            var endpoint = string.Format("accounts/{0}", accountId);
            var request = this.client.CreateRequest(endpoint);
            return await this.client.GetResponseAsync<Account>(request);
        }

        /// <summary>
        /// Gets the transaction history for an account matching the specified identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// A list of transactions
        /// </returns>
        public async Task<IEnumerable<Transaction>> GetAccountHistory(Guid accountId)
        {
            var endpoint = string.Format("accounts/{0}/ledger", accountId);
            var request = this.client.CreateRequest(endpoint);
            return await this.client.GetResponseAsync<IEnumerable<Transaction>>(request);
        }

        /// <summary>
        /// Gets the holds for the account matching the specified identifer.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// A list of holds
        /// </returns>
        public async Task<IEnumerable<Hold>> GetHolds(Guid accountId)
        {
            var endpoint = string.Format("accounts/{0}/holds", accountId);
            var request = this.client.CreateRequest(endpoint);
            return await this.client.GetResponseAsync<IEnumerable<Hold>>(request);
        }
    }
}
