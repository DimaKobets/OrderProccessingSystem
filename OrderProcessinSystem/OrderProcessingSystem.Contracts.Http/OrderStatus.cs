using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum OrderStatus : byte
    {
        [EnumMember(Value = "Processed")]
        Processed,

        [EnumMember(Value = "Unprocessed")]
        Unprocessed,

        [EnumMember(Value = "Cancelled")]
        Cancelled
    }
}
