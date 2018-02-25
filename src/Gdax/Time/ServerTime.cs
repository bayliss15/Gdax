namespace Gdax.Time
{
    using Newtonsoft.Json;
    using System;

    public class ServerTime
    {
        [JsonProperty("iso")]
        public DateTime Iso { get; set; }

        [JsonProperty("epoch")]
        public decimal Epoch { get; set; }      
    }
}
