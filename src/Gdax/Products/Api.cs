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
            return await client.GetAsync<IEnumerable<Product>>(requestUri);
        }

        public async Task<Book> GetProductOrderBook(string productId, int level)
        {
            var requestUri = string.Format("products/{0}/book?level={1}", productId, level);
            return await client.GetAsync<Book>(requestUri);
        }

        public async Task<Ticker> GetProductTicker(string productId)
        {
            var requestUri = string.Format("products/{0}/ticker", productId);
            return await client.GetAsync<Ticker>(requestUri);
        }

        public async Task<IEnumerable<Trade>> GetTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/trades", productId);
            return await client.GetAsync<IEnumerable<Trade>>(requestUri); ;
        }

        public async Task<IEnumerable<Candle>> GetHistoricTrades(string productId)
        {
            var requestUri = string.Format("products/{0}/candles", productId);
            return await client.GetAsync<IEnumerable<Candle>>(requestUri);
        }

        public async Task<Statistic> Get24hrStatistics(string productId)
        {
            var requestUri = string.Format("products/{0}/stats", productId);
            return await client.GetAsync<Statistic>(requestUri);
        }
    }
}
