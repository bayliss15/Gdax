// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implements methods to access the Products API
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
        /// Get a list of available currency pairs for trading.
        /// </summary>
        /// <returns>
        /// A list of products
        /// </returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var requestUri = "products";
            return await this.client.GetAsync<IEnumerable<Product>>(requestUri);
        }

        /// <summary>
        /// Get a list of open orders for a product. The amount of detail shown can be customized with the level parameter.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="level">The level.</param>
        /// <returns>
        /// A order book
        /// </returns>
        public async Task<Book> GetProductOrderBook(string productId, int level)
        {
            var requestUri = string.Format("products/{0}/book?level={1}", productId, level);
            return await this.client.GetAsync<Book>(requestUri);
        }

        /// <summary>
        /// Snapshot information about the last trade (tick), best bid/ask and 24h volume.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A ticker
        /// </returns>
        public async Task<Ticker> GetProductTicker(string productId)
        {
            var requestUri = string.Format("products/{0}/ticker", productId);
            return await this.client.GetAsync<Ticker>(requestUri);
        }

        /// <summary>
        /// List the latest trades for a product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A list of trades
        /// </returns>
        public async Task<IEnumerable<Trade>> GetTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/trades", productId);
            return await this.client.GetAsync<IEnumerable<Trade>>(requestUri);
        }

        /// <summary>
        /// Historic rates for a product. Rates are returned in grouped buckets based on requested granularity.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A list of candles
        /// </returns>
        public async Task<IEnumerable<Candle>> GetHistoricTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/candles", productId);
            return await this.client.GetAsync<IEnumerable<Candle>>(requestUri);
        }

        /// <summary>
        /// Get 24 hr statistics for the product. volume is in base currency units. open, high, low are in quote currency units.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A statistic
        /// </returns>
        public async Task<Statistic> Get24hrStatistics(string productId)
        {
            var requestUri = string.Format("products/{0}/stats", productId);
            return await this.client.GetAsync<Statistic>(requestUri);
        }
    }
}
