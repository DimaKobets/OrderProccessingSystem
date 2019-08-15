using Newtonsoft.Json;
using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "paymant")]
    public class Paymant
    {
        [XmlElement(ElementName = "method-name")]
        [JsonProperty(PropertyName = "method")]
        public string MethodName { get; set; }

        [XmlElement(ElementName = "amount")]
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }
    }
}
