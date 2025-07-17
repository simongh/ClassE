using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassE.Types
{
    public class BetterEnumConvertorFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var type = typeof(BetterEnumConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(type, options)!;
        }
    }
}