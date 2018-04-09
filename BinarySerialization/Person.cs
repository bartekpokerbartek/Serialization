using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    [Serializable]
    public class Person : ISerializable, IDeserializationCallback
    {
        public Person()
        {
            Salary = Age + 199;
        }

        [NonSerialized]
        public string NonSerializedField;

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        private int Salary { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("infoName", Name);
            info.AddValue("infoLastName", LastName);
            info.AddValue("infoMiddleName", MiddleName);
            info.AddValue("infoAge", Age);
            info.AddValue("infoSalary", Salary);
            info.AddValue("infoAdditional", "$" + Salary);
        }

        //Deserialization constructor
        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = Convert.ToString(info.GetValue("infoName", typeof(string)));
            LastName = Convert.ToString(info.GetValue("infoLastName", typeof(string)));
            MiddleName = Convert.ToString(info.GetValue("infoMiddleName", typeof(string)));
            Age = Convert.ToInt32(info.GetValue("infoAge", typeof(int)));
            Salary = Convert.ToInt32(info.GetValue("infoSalary", typeof(int)));
            Console.WriteLine(Convert.ToString(info.GetValue("infoAdditional", typeof(string))).Substring(1));
        }

        public void SerializePerson(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);
            stream.Close();
        }


        public Person DeserializePerson(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Person person = (Person)formatter.Deserialize(stream);

            stream.Close();
            return person;
        }

        public void OnDeserialization(object sender)
        {
            Console.WriteLine("On deserialization callback");
        }

        [OnSerialized]
        public void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("OnSerialized fcn.");
        }
    }
}
