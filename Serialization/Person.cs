using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serialization
{
    [XmlRoot("ClassPerson")]
    public class Person
    {
        public Person()
        {
            Salary = Age + 199;
            Cars = new List<Car>();
        }

        [XmlElement("PropertyName")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [XmlIgnore]
        public string MiddleName { get; set; }

        [XmlElement("PropertyAge")]
        public int Age { get; set; }

        public List<Car> Cars { get; set; }

        [XmlElement("PropertySalary")]
        private int Salary { get; set; }
    }
}
