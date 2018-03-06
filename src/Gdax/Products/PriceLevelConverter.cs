// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using Newtonsoft.Json;

    public class PriceLevelConverter : JsonConverter<PriceLevel>
    {
        public override PriceLevel ReadJson(JsonReader reader, Type objectType, PriceLevel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            decimal? price = null;
            decimal? size = null;

            while (reader.Read())
            {
                if (price == null)
                {
                    price = Convert.ToDecimal(reader.Value);
                }
                else if (size == null)
                {
                    size = Convert.ToDecimal(reader.Value);
                }

                if (reader.TokenType == JsonToken.EndArray)
                {
                    return new PriceLevel() { Price = price.Value, Size = size.Value };
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, PriceLevel value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.Price.ToString());
            writer.WriteValue(value.Size.ToString());
            writer.WriteEndArray();
        }
    }
}
