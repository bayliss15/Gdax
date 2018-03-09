// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// A client to access the GDAX api
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Client : IDisposable
    {
        /// <summary>
        /// The rest API endpoint for live.
        /// </summary>
        public const string RestApiLive = "https://api.gdax.com/";

        /// <summary>
        /// The rest API endpoint for the sandbox.
        /// </summary>
        public const string RestApiSandbox = "https://api-public.sandbox.gdax.com/";

        /// <summary>
        /// A unix Epoch
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="apiUri">The API URI.</param>
        /// <param name="userAgent">The user agent.</param>
        public Client(string apiUri = Client.RestApiLive, string userAgent = "gdax")
        {
            // Create and setup our HTTP client
            this.HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiUri ?? throw new ArgumentNullException(nameof(apiUri))),
            };

            this.HttpClient.DefaultRequestHeaders.Add("User-Agent", userAgent ?? throw new ArgumentNullException(nameof(userAgent)));

            // Create the API endpoints
            this.Currencies = new Currencies.CurrenciesService(this);
            this.Products = new Products.ProductsService(this);
            this.Time = new Time.TimeService(this);
        }

        /// <summary>
        /// Gets the currencies API.
        /// </summary>
        public Currencies.CurrenciesService Currencies { get; private set; }

        /// <summary>
        /// Gets the products.
        /// </summary>
        public Products.ProductsService Products { get; private set; }

        /// <summary>
        /// Gets the time API.
        /// </summary>
        public Time.TimeService Time { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP client.
        /// </summary>
        protected HttpClient HttpClient { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
        }

        /// <summary>
        /// Creates a request suitable for the GDAX API.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A HttpRequestMessage</returns>
        public virtual HttpRequestMessage CreateRequest(string endpoint, IEnumerable<(string, object)> parameters = null)
        {
            if (parameters != null)
            {
                var validParameters = parameters.Where(p => p.Item2 != null);

                if (validParameters.Any())
                {
                    endpoint += "?" + string.Join("&", validParameters.Select(p => string.Format("{0}={1}", p.Item1, p.Item2)));
                }
            }

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(this.HttpClient.BaseAddress, endpoint),
                Method = HttpMethod.Get,
            };

            return request;
        }

        /// <summary>
        /// Gets a result from the GDAX API asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to deserialize result to</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>
        /// A result as passed type
        /// </returns>
        public async Task<T> GetResponseAsync<T>(HttpRequestMessage request)
        {
            var response = await this.HttpClient.SendAsync(request);

            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var serializationSettings = new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };

                try
                {
                    return JsonConvert.DeserializeObject<T>(data, serializationSettings);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    throw;
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format("{0}: {1}", response.StatusCode, data));
            }
        }

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
                    if (this.HttpClient != null)
                    {
                        this.HttpClient.Dispose();
                    }
                }

                this.disposedValue = true;
            }
        }
    }
}
