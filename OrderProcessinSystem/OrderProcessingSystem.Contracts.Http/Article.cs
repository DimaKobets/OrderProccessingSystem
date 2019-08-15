using Newtonsoft.Json;
using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "orderarticle")]
    public class Article
    {
        [XmlElement(ElementName = "artnum")]
        [JsonProperty(PropertyName = "artnum")]
        public long Nomenclature { get; set; }

        [XmlElement(ElementName = "title")]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "amount")]
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [XmlElement(ElementName = "brutprice")]
        [JsonProperty(PropertyName = "brutprice")]
        public double BrutPrice { get; set; }
    }
}
