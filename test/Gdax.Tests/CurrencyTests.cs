namespace Gdax.Tests
{
    using System;
    using Xunit;

    public class CurrencyTests
    {
        [Fact]
        public void GetCurrencies_ShouldReturn()
        {
            using (var client = new Gdax.Client(Client.RestApiSandbox))
            {
                var result = client.Currencies.GetCurrencies().Result;
                Assert.NotNull(result);
            }
        }
    }
}
