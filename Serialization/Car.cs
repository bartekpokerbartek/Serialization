using System.Xml.Serialization;

namespace Serialization
{
    public class Car
    {
        public string Color { get; set; }

        public decimal Price { get; set; }

        [XmlAttribute]
        public bool FromAbroad { get; set; }
    }
}
