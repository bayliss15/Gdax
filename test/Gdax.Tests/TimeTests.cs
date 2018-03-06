// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Tests
{
    using System;
    using Xunit;

    public class TimeTests
    {
        [Fact]
        public void GetTime_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Time.GetTime().Result;
                Assert.NotNull(result);
            }
        }
    }
}
