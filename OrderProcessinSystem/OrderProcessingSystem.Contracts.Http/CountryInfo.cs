using Newtonsoft.Json;
using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "country")]
    public class CountryInfo
    {
        [XmlElement(ElementName = "geo")]
        [JsonProperty(PropertyName = "geo")]
        public string GeoCode { get; set; }
    }
}
