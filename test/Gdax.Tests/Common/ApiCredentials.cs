// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Tests.Common
{
    using System;
    using Microsoft.Extensions.Configuration;

    public class ApiCredentials
    {
        private static ApiCredentials instance;

        private ApiCredentials()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<ApiCredentials>();
            var configuration = builder.Build();

            this.ApiKey = configuration["ApiKey"];
            this.ApiPassphrase = configuration["ApiPassphrase"];
            this.ApiSecret = configuration["ApiSecret"];
            this.AccountId = new Guid(configuration["AccountId"]);
        }

        public static ApiCredentials Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiCredentials();
                }

                return instance;
            }
        }

        public string ApiKey { get; private set; }

        public string ApiPassphrase { get; private set; }

        public string ApiSecret { get; private set; }

        public Guid AccountId { get; private set; }
    }
}
