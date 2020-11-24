using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ex6
{
    class WriteToXml
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Assignment>));

        public void WriteToFile(List<Assignment> assignments)
        {
            if (new DirectoryInfo(@"C:\Temp\homework\datastructures\").Exists == false) 
                Directory.CreateDirectory(@"C:\Temp\homework\datastructures\");
            using var fs = File.CreateText(@"C:\Temp\homework\datastructures\assignments.xml");
            _serializer.Serialize(fs, assignments);
        }
    }
}