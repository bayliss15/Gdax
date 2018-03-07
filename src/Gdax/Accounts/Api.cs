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
        /// Get a list of trading accounts.
        /// </summary>
        /// <returns>
        /// A list of accounts
        /// </returns>
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var requestUri = "accounts";
            return await this.client.GetAsync<IEnumerable<Account>>(requestUri);
        }

        /// <summary>
        /// Information for a single account. Use this endpoint when you know the account id.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// An account
        /// </returns>
        public async Task<Account> GetAccount(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}", accountId);
            return await this.client.GetAsync<Account>(requestUri);
        }

        /// <summary>
        /// List account activity. Account activity either increases or decreases your account balance.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// A list of transactions
        /// </returns>
        public async Task<IEnumerable<Transaction>> GetAccountHistory(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/ledger", accountId);
            return await this.client.GetAsync<IEnumerable<Transaction>>(requestUri);
        }

        /// <summary>
        /// Holds are placed on an account for any active orders or pending withdraw requests.
        /// As an order is filled, the hold amount is updated.
        /// If an order is canceled, any remaining hold is removed. For a withdraw, once it is completed, the hold is removed.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// A list of holds
        /// </returns>
        public async Task<IEnumerable<Hold>> GetHolds(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/holds", accountId);
            return await this.client.GetAsync<IEnumerable<Hold>>(requestUri);
        }
    }
}
