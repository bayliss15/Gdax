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

        protected HttpClient httpClient;

        private bool disposedValue = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="apiUri">The API URI.</param>
        /// <param name="userAgent">The user agent.</param>
        public Client(string apiUri = Client.RestApiLive, string userAgent = "gdax")
        {
            // Validate our inputs
            if (string.IsNullOrWhiteSpace(apiUri)) { throw new ArgumentNullException(nameof(apiUri)); }
            if (string.IsNullOrWhiteSpace(userAgent)) { throw new ArgumentNullException(nameof(userAgent)); }

            // Create and setup our HTTP client
            httpClient = new HttpClient() { BaseAddress = new Uri(apiUri) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

            // Create the API endpoints
            this.Currencies = new Currencies.Api(this);
            this.Products = new Products.Api(this);
            this.Time = new Time.Api(this);
        }

        #endregion

        #region API Properties

        /// <summary>
        /// Gets the currencies API.
        /// </summary>
        public Currencies.Api Currencies { get; private set; }

        /// <summary>
        /// Gets the products.
        /// </summary>
        public Products.Api Products { get; private set; }

        /// <summary>
        /// Gets the time API.
        /// </summary>
        public Time.Api Time { get; private set; }

        #endregion

        #region Methods

        internal virtual async Task<T> GetAsync<T>(string uri)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(httpClient.BaseAddress, uri),
                Method = HttpMethod.Get
            };

            return await this.GetAsync<T>(request);            
        }

        internal async Task<T> GetAsync<T>(HttpRequestMessage request)
        {
            var response = await this.httpClient.SendAsync(request);

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

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
        }

        #endregion
    }
}
