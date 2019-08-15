using System.Xml.Serialization;

namespace OrderProcessingSystem.Contracts.Http
{
    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public Order[] Order { get; set; }
    }
}
