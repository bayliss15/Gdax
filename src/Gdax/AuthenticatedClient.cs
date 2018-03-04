﻿namespace Gdax
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Security.Cryptography;

    public class AuthenticatedClient : Client
    {
        #region Fields

        private string apiSecret;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        /// <param name="apiPassphrase">The API passphrase.</param>
        /// <param name="apiUri">The API URI.</param>
        /// <param name="userAgent">The user agent.</param>
        public AuthenticatedClient(string apiKey, string apiSecret, string apiPassphrase, string apiUri = Client.RestApiLive, string userAgent = "gdax")
            : base(apiUri, userAgent)
        {
            // Validate our inputs        
            if (string.IsNullOrWhiteSpace(apiKey)) { throw new ArgumentNullException(nameof(apiKey)); }
            if (string.IsNullOrWhiteSpace(apiSecret)) { throw new ArgumentNullException(nameof(apiSecret)); }
            if (string.IsNullOrWhiteSpace(apiPassphrase)) { throw new ArgumentNullException(nameof(apiPassphrase)); }

            // Add our credentially bits to our HTTP client
            this.httpClient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", apiKey);
            this.httpClient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", apiPassphrase);

            // Set our secret so we can use it later
            this.apiSecret = apiSecret;

            // Create the API endpoints
            this.Accounts = new Accounts.Api(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the accounts API.
        /// </summary>
        public Accounts.Api Accounts { get; private set; }

        #endregion

        #region Methods

        internal async override Task<T> GetAsync<T>(string uri)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(httpClient.BaseAddress, uri),
                Method = HttpMethod.Get,
            };

            var timeStamp = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.ToString("F0");

            var hashKey = Convert.FromBase64String(this.apiSecret);
            var hashData = string.Concat(timeStamp, "GET", request.RequestUri.PathAndQuery);
            var hashBytes = Encoding.UTF8.GetBytes(hashData);

            using (var hmac = new HMACSHA256(hashKey))
            {
                request.Headers.Add("CB-ACCESS-SIGN", Convert.ToBase64String(hmac.ComputeHash(hashBytes)));
            }

            request.Headers.Add("CB-ACCESS-TIMESTAMP", timeStamp);

            return await this.GetAsync<T>(request);
        }

        #endregion
    }
}