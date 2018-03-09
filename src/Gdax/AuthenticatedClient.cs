// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;

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
            this.Accounts = new Accounts.AccountsService(this);
            this.Fills = new Fills.FillsService(this);
            this.PaymentMethods = new PaymentMethods.PaymentMethodsService(this);
            this.UserAccount = new UserAccount.UserAccountService(this);
        }

        /// <summary>
        /// Gets the accounts API.
        /// </summary>
        public Accounts.AccountsService Accounts { get; private set; }

        /// <summary>
        /// Gets the fills API.
        /// </summary>
        public Fills.FillsService Fills { get; private set; }

        /// <summary>
        /// Gets the payment methods API.
        /// </summary>
        public PaymentMethods.PaymentMethodsService PaymentMethods { get; private set; }

        /// <summary>
        /// Gets the user account.
        /// </summary>
        public UserAccount.UserAccountService UserAccount { get; private set; }

        /// <summary>
        /// Creates a request suitable for the GDAX API.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// A HttpRequestMessage
        /// </returns>
        public override HttpRequestMessage CreateRequest(string endpoint, IEnumerable<(string, object)> parameters = null)
        {
            var request = base.CreateRequest(endpoint, parameters);

            var timeStamp = (DateTime.UtcNow - Client.Epoch).TotalSeconds.ToString("F0");

            var hashKey = Convert.FromBase64String(this.apiSecret);
            var hashData = string.Concat(timeStamp, "GET", request.RequestUri.PathAndQuery);
            var hashBytes = Encoding.UTF8.GetBytes(hashData);

            using (var hmac = new HMACSHA256(hashKey))
            {
                request.Headers.Add("CB-ACCESS-SIGN", Convert.ToBase64String(hmac.ComputeHash(hashBytes)));
            }

            request.Headers.Add("CB-ACCESS-TIMESTAMP", timeStamp);

            return request;
        }
    }
}
