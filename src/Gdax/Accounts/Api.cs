// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Accounts
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

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var requestUri = "accounts";
            return await this.client.GetAsync<IEnumerable<Account>>(requestUri);
        }

        public async Task<Account> GetAccount(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}", accountId);
            return await this.client.GetAsync<Account>(requestUri);
        }

        public async Task<IEnumerable<Transaction>> GetAccountHistory(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/ledger", accountId);
            return await this.client.GetAsync<IEnumerable<Transaction>>(requestUri);
        }

        public async Task<IEnumerable<Hold>> GetHolds(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/holds", accountId);
            return await this.client.GetAsync<IEnumerable<Hold>>(requestUri);
        }
    }
}
