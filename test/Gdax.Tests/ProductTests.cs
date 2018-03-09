// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Tests
{
    using System;
    using Xunit;

    public class ProductTests
    {
        [Fact]
        public void Get24hrStatistics_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.Get24hrStatistics("ETH-EUR").Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetHistoricTrades_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.GetHistoricTrades("ETH-EUR").Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetProductOrderBook_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.GetProductOrderBook("ETH-EUR", Products.OrderBookLevel.One).Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetProducts_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.GetProducts().Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetProductTicker_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.GetProductTicker("ETH-EUR").Result;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetTrades_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Products.GetTrades("ETH-EUR").Result;
                Assert.NotNull(result);
            }
        }
    }
}
