namespace Gdax.Models
{
    using Newtonsoft.Json;
    using System;

    public class Time
    {
        [JsonProperty("iso")]
        public DateTime Iso { get; set; }

        [JsonProperty("epoch")]
        public decimal Epoch { get; set; }      
    }
}
