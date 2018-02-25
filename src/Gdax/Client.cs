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

        private HttpClient httpClient;

        private bool disposedValue = false;

        #endregion

        #region Constructors

        public Client()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.gdax.com/"),
            };

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Bware");

            this.Products = new Gdax.Products.Api(this);
        }

        #endregion

        #region Properties

        public Products.Api Products { get; private set; }

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
