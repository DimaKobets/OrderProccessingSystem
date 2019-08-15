using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "oxid")]
        [JsonProperty(PropertyName = "oxid")]
        public long Oxid { get; set; }

        [XmlElement(ElementName = "orderdate")]
        [JsonProperty(PropertyName = "orderdate")]
        public DateTime OrderDate { get; set; }

        [XmlElement(ElementName = "billingaddress")]
        [JsonProperty(PropertyName = "billingaddress")]
        public BillingAddress BillingAddress { get; set; }

        //[XmlElement(ElementName = "payments")]
        [XmlArray("payments")]
        [XmlArrayItem("payment")]
        [JsonProperty(PropertyName = "payments")]
        public Paymant[] Payments { get; set; }

        //[XmlElement(ElementName = "articles")]
        [XmlArray("articles")]
        [XmlArrayItem("orderarticle")]
        [JsonProperty(PropertyName = "articles")]
        public Article[] Articles { get; set; }
    }
}
