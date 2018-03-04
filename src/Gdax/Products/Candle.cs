namespace Gdax.Products
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;

    [JsonConverter(typeof(CandleConverter))]
    [DebuggerDisplay("Time: {Time}, Low: {Low}, High: {High}, Open: {Open}, Close: {Close}, Volume: {Volume}")]
    public class Candle
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        public decimal Volume { get; set; }
    }

    public class CandleConverter : JsonConverter<Candle>
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override Candle ReadJson(JsonReader reader, Type objectType, Candle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {

            DateTime? time = null;
            decimal? low = null;
            decimal? high = null;
            decimal? open = null;
            decimal? close = null;
            decimal? volume = null;

            while (reader.Read())
            {
                if (time == null)
                {
                    time = epoch.AddSeconds((long)reader.Value);
                }
                else if (low == null)
                {
                    low = Convert.ToDecimal(reader.Value);
                }
                else if (high == null)
                {
                    high = Convert.ToDecimal(reader.Value);
                }
                else if (open == null)
                {
                    open = Convert.ToDecimal(reader.Value);
                }
                else if (close == null)
                {
                    close = Convert.ToDecimal(reader.Value);
                }
                else if (volume == null)
                {
                    volume = Convert.ToDecimal(reader.Value);
                }

                if (reader.TokenType == JsonToken.EndArray)
                {
                    return new Candle()
                    {
                        Time = time.Value,
                        Low = low.Value,
                        High = high.Value,
                        Open = open.Value,
                        Close = close.Value,
                        Volume = volume.Value
                    };
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, Candle value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            writer.WriteValue(value.Time.ToString());
            writer.WriteValue(value.Low.ToString());
            writer.WriteValue(value.High.ToString());
            writer.WriteValue(value.Open.ToString());
            writer.WriteValue(value.Close.ToString());
            writer.WriteValue(value.Volume.ToString());

            writer.WriteEndArray();
        }
    }
}
