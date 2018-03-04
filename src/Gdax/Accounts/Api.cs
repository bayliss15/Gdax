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
            return await client.GetAsync<IEnumerable<Account>>(requestUri);
        }

        public async Task<Account> GetAccount(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}", accountId);
            return await client.GetAsync<Account>(requestUri);
        }

        public async Task<IEnumerable<Transaction>> GetAccountHistory(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/ledger", accountId);
            return await client.GetAsync<IEnumerable<Transaction>>(requestUri);
        }

        public async Task<IEnumerable<Hold>> GetHolds(Guid accountId)
        {
            var requestUri = string.Format("accounts/{0}/holds", accountId);
            return await client.GetAsync<IEnumerable<Hold>>(requestUri);
        }
    }
}
