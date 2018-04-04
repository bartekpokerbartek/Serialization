using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlElementAttribute myElementAttribute = new XmlElementAttribute();
            myElementAttribute.ElementName = "Surname";
            XmlAttributes myAttributes = new XmlAttributes();
            myAttributes.XmlElements.Add(myElementAttribute);
            XmlAttributeOverrides myOverrides = new XmlAttributeOverrides();
            myOverrides.Add(typeof(Person), "LastName", myAttributes);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person), myOverrides);
            Person person = new Person();
            StreamWriter streamWriter;
            var path = @"C:\ser.txt";

            person.Name = "MyName";
            person.MiddleName = "MyMiddleName";
            person.LastName = "MyLastName";
            person.Age = 30;

            var car1 = new Car
            {
                Color = "Red",
                FromAbroad = true,
                Price = 100.0M
            };

            var car2 = new Car
            {
                Color = "Red",
                FromAbroad = false,
                Price = 1000.0M
            };

            person.Cars.AddRange(new List<Car> { car1, car2 } );

            streamWriter = new StreamWriter(path);

            xmlSerializer.Serialize(streamWriter, person);
            streamWriter.Close();


            Person deserializedPerson = new Person();
            StreamReader streamReader;
            streamReader = new StreamReader(path);
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            serializer.UnknownNode += new XmlNodeEventHandler(handler);
            deserializedPerson = (Person)serializer.Deserialize(streamReader);

            streamReader.Close();
        }

        private static void handler(object sender, XmlNodeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
