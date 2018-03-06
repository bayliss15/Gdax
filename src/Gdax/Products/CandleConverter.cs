// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using Newtonsoft.Json;

    public class CandleConverter : JsonConverter<Candle>
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
                    time = Epoch.AddSeconds((long)reader.Value);
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
