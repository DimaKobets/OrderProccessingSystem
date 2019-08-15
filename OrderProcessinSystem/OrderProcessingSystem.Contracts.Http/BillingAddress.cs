using Newtonsoft.Json;
using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "billingaddress")]
    public class BillingAddress
    {
        [XmlElement(ElementName = "billemail")]
        [JsonProperty(PropertyName = "billemail")]
        public string Email { get; set; }

        [XmlElement(ElementName = "billfname")]
        [JsonProperty(PropertyName = "billfname")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "billstreet")]
        [JsonProperty(PropertyName = "billstreet")]
        public string Street { get; set; }

        [XmlElement(ElementName = "billstreetnr")]
        [JsonProperty(PropertyName = "billstreetnr")]
        public int HomeNumber { get; set; }

        [XmlElement(ElementName = "billcity")]
        [JsonProperty(PropertyName = "billcity")]
        public string City { get; set; }

        [XmlElement(ElementName = "country")]
        [JsonProperty(PropertyName = "country")]
        public CountryInfo CounryInfo { get; set; }

        [XmlElement(ElementName = "billzip")]
        [JsonProperty(PropertyName = "billzip")]
        public int ZipCode { get; set; }
    }
}
