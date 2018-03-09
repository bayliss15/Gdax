// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts a candle to and from JSON.
    /// </summary>
    public class CandleConverter : JsonConverter<Candle>
    {
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
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
                    time = Client.Epoch.AddSeconds((long)reader.Value);
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
                        Volume = volume.Value,
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
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
