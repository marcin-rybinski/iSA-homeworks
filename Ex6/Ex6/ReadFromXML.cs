using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ex6
{
    class ReadFromXml
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Assignment>));
        public Queue<Assignment> FromFileToQueue()
        {
            StreamReader stream = new StreamReader(@"C:\Temp\homework\datastructures\assignments.xml");
            var deserializedList = (List<Assignment>)_serializer.Deserialize(stream);
            return new Queue<Assignment>(deserializedList);
        }
    }
}