namespace Gdax.Products
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    [JsonConverter(typeof(PriceLevelConverter))]
    [DebuggerDisplay("Price: {Price}, Size: {Size}")]
    public class PriceLevel
    {
        public decimal Price { get; set; }

        public decimal Size { get; set; }      
    }

    public class PriceLevelConverter : JsonConverter<PriceLevel>
    {
        public override PriceLevel ReadJson(JsonReader reader, Type objectType, PriceLevel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            decimal? price = null;
            decimal? size = null;

            while(reader.Read())
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
