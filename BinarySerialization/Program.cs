using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:/bin.txt";
            var person = new Person();
            person.Age = 54;
            person.Name = "Mic";
            person.LastName = "Poto";
            person.MiddleName = "Midasd";


            person.SerializePerson(path);

            var deserializedPerson = person.DeserializePerson(path);
        }
    }
}
