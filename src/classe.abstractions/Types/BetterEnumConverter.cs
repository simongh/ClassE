﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassE.Types
{
    // https://jscarle.dev/the-sunken-ship-that-is-the-jsonstringenumconverter/
    public class BetterEnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
    {
        private readonly Dictionary<TEnum, string> _enumToString = [];
        private readonly Dictionary<int, TEnum> _numberToEnum = [];
        private readonly Dictionary<string, TEnum> _stringToEnum = new(StringComparer.InvariantCultureIgnoreCase);

        public BetterEnumConverter(JsonSerializerOptions options)
        {
            var type = typeof(TEnum);
            var names = Enum.GetNames<TEnum>();
            var values = Enum.GetValues<TEnum>();
            var underlying = Enum.GetValuesAsUnderlyingType<TEnum>().Cast<int>().ToArray();
            for (var index = 0; index < names.Length; index++)
            {
                var name = names[index];
                var value = values[index];
                var underlyingValue = underlying[index];

                var attribute = type.GetMember(name)[0]
                    .GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                    .Cast<JsonPropertyNameAttribute>()
                    .FirstOrDefault();

                var defaultStringValue = FormatName(name, options);
                var customStringValue = attribute?.Name;

                _enumToString.TryAdd(value, customStringValue ?? defaultStringValue);
                _stringToEnum.TryAdd(defaultStringValue, value);
                if (customStringValue is not null)
                    _stringToEnum.TryAdd(customStringValue, value);
                _numberToEnum.TryAdd(underlyingValue, value);
            }
        }

        private static string FormatName(string name, JsonSerializerOptions options)
        {
            return options.PropertyNamingPolicy?.ConvertName(name) ?? name;
        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    {
                        var stringValue = reader.GetString();

                        if (stringValue is not null && _stringToEnum.TryGetValue(stringValue, out var enumValue))
                            return enumValue;
                        break;
                    }
                case JsonTokenType.Number:
                    {
                        if (reader.TryGetInt32(out var numValue) && _numberToEnum.TryGetValue(numValue, out var enumValue))
                            return enumValue;
                        break;
                    }
            }

            throw new JsonException(
                $"The JSON value '{Encoding.UTF8.GetString(reader.ValueSpan)}' could not be converted to {typeof(TEnum).FullName}. BytePosition: {reader.BytesConsumed}."
            );
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_enumToString[value]);
        }
    }
}