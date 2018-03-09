// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Tests
{
    using System;
    using Xunit;

    public class UserAccountTests
    {
        private Common.ApiCredentials credentials = Common.ApiCredentials.Instance;

        [Fact]
        public void TrailingVolume_ShouldReturn()
        {
            using (var client = new Gdax.AuthenticatedClient(this.credentials.ApiKey, this.credentials.ApiSecret, this.credentials.ApiPassphrase, Client.RestApiSandbox))
            {
                var result = client.UserAccount.TrailingVolume().Result;
                Assert.NotNull(result);
            }
        }
    }
}
