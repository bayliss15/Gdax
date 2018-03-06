// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            using (var client = new Gdax.AuthenticatedClient(this.credentials.ApiKey, this.credentials.ApiSecret, this.credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccounts().Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetAccount_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(this.credentials.ApiKey, this.credentials.ApiSecret, this.credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccount(this.credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetAccountHistory_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(this.credentials.ApiKey, this.credentials.ApiSecret, this.credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetAccountHistory(this.credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetHolds_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(this.credentials.ApiKey, this.credentials.ApiSecret, this.credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.Accounts.GetHolds(this.credentials.AccountId).Result;
                Assert.NotNull(result);
            }
        }
    }
}
