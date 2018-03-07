// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax
{
    using System;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// An authenticated client to access the GDAX api
    /// </summary>
    /// <seealso cref="Gdax.Client" />
    public class AuthenticatedClient : Client
    {
        private string apiSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        /// <param name="apiPassphrase">The API passphrase.</param>
        /// <param name="apiUri">The API URI.</param>
        /// <param name="userAgent">The user agent.</param>
        public AuthenticatedClient(string apiKey, string apiSecret, string apiPassphrase, string apiUri = Client.RestApiLive, string userAgent = "gdax")
            : base(apiUri, userAgent)
        {
            // Add our credentially bits to our HTTP client
            this.HttpClient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", apiKey ?? throw new ArgumentNullException(nameof(apiKey)));
            this.HttpClient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", apiPassphrase ?? throw new ArgumentNullException(nameof(apiPassphrase)));

            // Set our secret so we can use it later
            this.apiSecret = apiSecret ?? throw new ArgumentNullException(nameof(apiSecret));

            // Create the API endpoints
            this.Accounts = new Accounts.Api(this);
            this.Fills = new Fills.Api(this);
            this.PaymentMethods = new PaymentMethods.Api(this);
        }

        /// <summary>
        /// Gets the accounts API.
        /// </summary>
        public Accounts.Api Accounts { get; private set; }

        /// <summary>
        /// Gets the fills API.
        /// </summary>
        public Fills.Api Fills { get; private set; }

        /// <summary>
        /// Gets the payment methods API.
        /// </summary>
        public PaymentMethods.Api PaymentMethods { get; private set; }

        /// <summary>
        /// Gets a result from the GDAX API asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to deserialize result to</typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>
        /// A result as passed type
        /// </returns>
        internal async override Task<T> GetAsync<T>(string uri)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(this.HttpClient.BaseAddress, uri),
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
    }
}
