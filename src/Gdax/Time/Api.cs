namespace Gdax.Time
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

        public async Task<ServerTime> GetTime()
        {
            var requestUri = "time";
            return await client.GetAsync<ServerTime>(requestUri);
        }      
    }
}
