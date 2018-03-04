namespace Gdax.Time
{
    using Newtonsoft.Json;
    using System;

    public class ServerTime
    {
        /// <summary>
        /// Gets or sets the iso.
        /// </summary>
        [JsonProperty("iso")]
        public DateTime Iso { get; set; }

        /// <summary>
        /// Gets or sets the epoch.
        /// </summary>
        [JsonProperty("epoch")]
        public decimal Epoch { get; set; }      
    }
}
