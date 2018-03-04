namespace Gdax.Tests.Common
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        public string ApiKey { get; private set; }

        public string ApiPassphrase { get; private set; }

        public string ApiSecret { get; private set; }

        public Guid AccountId { get; private set; }

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


    }
}
