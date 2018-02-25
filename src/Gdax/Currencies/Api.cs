namespace Gdax.Currencies
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

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var requestUri = "currencies";
            return await client.GetAsync<IEnumerable<Currency>>(requestUri);
        }      
    }
}
