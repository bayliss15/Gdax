namespace Gdax
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class Client : IDisposable
    {
        #region Fields

        public const string RestApiLive = "https://api.gdax.com/";
        public const string RestApiSandbox = "https://api-public.sandbox.gdax.com/";

        private HttpClient httpClient;

        private bool disposedValue = false;

        #endregion

        #region Constructors

        public Client() : this(Client.RestApiLive)
        {
        }

        public Client(string apiUri)
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiUri),
            };

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Bware");

            this.Currencies = new Gdax.Currencies.Api(this);
            this.Products = new Gdax.Products.Api(this);
            this.Time = new Gdax.Time.Api(this);
        }

        #endregion

        #region Properties

        public Currencies.Api Currencies { get; private set; }

        public Products.Api Products { get; private set; }

        public Time.Api Time { get; private set; }

        #endregion

        #region Methods

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await this.httpClient.GetAsync(url);
            
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            else
            {
                throw new InvalidOperationException(string.Format("{0}: {1}", response.StatusCode, data));
            }
        }

        #endregion

        #region IDisposable Implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (this.httpClient != null) { this.httpClient.Dispose(); }                
                }               

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
        }

        #endregion

    }
}
