using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using шарпы13;

namespace шарпы13
{
    public enum SerializationType
    {
        Binary,
        Soap,
        Xml,
        Json,
    }

    public class Serializer
    {
        public void Serialize(Stream serializationStream, Object obj, SerializationType type)
        {
            BinarySerializer bS = new BinarySerializer();
            SoapSerializer sS = new SoapSerializer();
            XmlSerializer xS = new XmlSerializer();
            JsonSerializer jS = new JsonSerializer();

            switch (type)
            {
                case SerializationType.Binary:
                    bS.Serialize(serializationStream, obj);
                    return;
                case SerializationType.Soap:
                        sS.Serialize(serializationStream, obj);
                    return;
                case SerializationType.Xml:
                    xS.Serialize(serializationStream, obj);
                    return;
                case SerializationType.Json:
                    jS.Serialize(serializationStream, obj);
                    return;
            }
            throw new NotImplementedException($"Can't serialize object to '{type}'");
        }

        public T Deserialize<T>(Stream serializationStream, SerializationType type)
        {
            BinarySerializer bS = new BinarySerializer();
            SoapSerializer sS = new SoapSerializer();
            XmlSerializer xS = new XmlSerializer();
            JsonSerializer jS = new JsonSerializer();
            switch (type)
            {
                case SerializationType.Binary:
                    return bS.Deserialize<T>(serializationStream);
                case SerializationType.Soap:
                    return sS.Deserialize<T>(serializationStream);
                case SerializationType.Xml:
                    return xS.Deserialize<T>(serializationStream);
                case SerializationType.Json:
                    return jS.Deserialize<T>(serializationStream);
            }
            throw new NotImplementedException($"Can't deserialize object from '{type}'");
        }
    }
}