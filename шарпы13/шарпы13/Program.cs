using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace шарпы13
{
    public class Program
    {
        static readonly string LAB_PATH = "C:\\Users\\Влад\\source\\repos\\шарпы13\\шарпы13\\ser\\";
        static readonly string BIN_FILE = Path.Combine(LAB_PATH, "ser", "serialized.bin");
        static readonly string SOAP_FILE = Path.Combine(LAB_PATH, "ser", "serialize.soap");
        static readonly string XML_FILE = Path.Combine(LAB_PATH, "ser", "serialized.xml");
        static readonly string JSON_FILE = Path.Combine(LAB_PATH, "ser", "serialized.json");

        static void Main(string[] args)
        {
            Organization org = new Organization();
            org.Address = "Minsk";
            org.OrgName = "Vlad";


            Serialize(org);
            Deserialize();
        }

        static void Serialize(Organization org)
        {
            Serializer serializer = new Serializer();
            if (!Directory.Exists(Path.GetDirectoryName(BIN_FILE)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(BIN_FILE));
            }

            using (var fs = new FileStream(BIN_FILE, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, org, SerializationType.Binary);
            }

            using (var fs = new FileStream(SOAP_FILE, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, org, SerializationType.Soap);
            }
            using (var fs = new FileStream(XML_FILE, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, org, SerializationType.Xml);
            }

            using (var fs = new FileStream(JSON_FILE, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, org, SerializationType.Json);
            }
        }

        static void Deserialize()
        {
            Organization resBin;
            Organization resSoap;
            Organization resXml;
            Organization resJson;
            Serializer serializer = new Serializer();

            using (var fs = new FileStream(BIN_FILE, FileMode.OpenOrCreate))
            {
                resBin = serializer.Deserialize<Organization>(fs, SerializationType.Binary);
            }

            using (var fs = new FileStream(SOAP_FILE, FileMode.OpenOrCreate))
            {
                resSoap = serializer.Deserialize<Organization>(fs, SerializationType.Soap);
            }

            using (var fs = new FileStream(XML_FILE, FileMode.OpenOrCreate))
            {
                resXml = serializer.Deserialize<Organization>(fs, SerializationType.Xml);
            }

            using (var fs = new FileStream(JSON_FILE, FileMode.OpenOrCreate))
            {
                resJson = serializer.Deserialize<Organization>(fs, SerializationType.Json);
            }

            Console.WriteLine("\tBinary");
            Console.WriteLine($"resBin: {resBin}");
            Console.WriteLine($"value: '{resBin.Address}'");


            Console.WriteLine("\tSoap");
            Console.WriteLine($"resSoap: {resSoap}");
            Console.WriteLine($"value: '{resSoap.Address}'");

            Console.WriteLine("\tXml");
            Console.WriteLine($"resXml: {resXml}");
            Console.WriteLine($"value: '{resXml.Address}'");

            Console.WriteLine("\tJson");
            Console.WriteLine($"resJson: {resJson}");
            Console.WriteLine($"value: '{resJson.Address}'");
        }
    }
}