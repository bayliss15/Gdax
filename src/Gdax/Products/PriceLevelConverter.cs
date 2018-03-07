// Copyright (c) Steve Bayliss. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Gdax.Products
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts a price level to and from JSON.
    /// </summary>
    public class PriceLevelConverter : JsonConverter<PriceLevel>
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

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, PriceLevel value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(value.Price.ToString());
            writer.WriteValue(value.Size.ToString());
            writer.WriteEndArray();
        }
    }
}
