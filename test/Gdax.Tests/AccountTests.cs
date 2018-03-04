namespace Gdax.Tests
{
    using System;
    using Xunit;

    public class AccountTests
    {
        private Common.ApiCredentials credentials = Common.ApiCredentials.Instance;


        [Fact]
        public void GetAccounts_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(credentials.ApiKey, credentials.ApiSecret, credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccounts().Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetAccount_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(credentials.ApiKey, credentials.ApiSecret, credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccount(credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetAccountHistory_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(credentials.ApiKey, credentials.ApiSecret, credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccountHistory(credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetHolds_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(credentials.ApiKey, credentials.ApiSecret, credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetHolds(credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }
    }
}
