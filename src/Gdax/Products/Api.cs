// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Api
    {
        private Client client;

        internal Api(Client client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var requestUri = "products";
            return await this.client.GetAsync<IEnumerable<Product>>(requestUri);
        }

        public async Task<Book> GetProductOrderBook(string productId, int level)
        {
            var requestUri = string.Format("products/{0}/book?level={1}", productId, level);
            return await this.client.GetAsync<Book>(requestUri);
        }

        public async Task<Ticker> GetProductTicker(string productId)
        {
            var requestUri = string.Format("products/{0}/ticker", productId);
            return await this.client.GetAsync<Ticker>(requestUri);
        }

        public async Task<IEnumerable<Trade>> GetTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/trades", productId);
            return await this.client.GetAsync<IEnumerable<Trade>>(requestUri);
        }

        public async Task<IEnumerable<Candle>> GetHistoricTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/candles", productId);
            return await this.client.GetAsync<IEnumerable<Candle>>(requestUri);
        }

        public async Task<Statistic> Get24hrStatistics(string productId)
        {
            var requestUri = string.Format("products/{0}/stats", productId);
            return await this.client.GetAsync<Statistic>(requestUri);
        }
    }
}
