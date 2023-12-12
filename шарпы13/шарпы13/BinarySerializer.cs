using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace шарпы13
{
    public class BinarySerializer : ISerializer
    {
        static private BinaryFormatter _formatter = new BinaryFormatter();

        public  void Serialize(Stream serializationStream, Object obj)
        {
            try
            {
#pragma warning disable SYSLIB0011
                _formatter.Serialize(serializationStream, obj);
#pragma warning restore SYSLIB0011
            }
            catch (Exception ex)
            {
                throw new SerializationException($"{ex.GetType().Name} while serialization: {ex.Message}");
            }
        }

        public  T Deserialize<T>(Stream serializationStream)
        {
            try
            {
#pragma warning disable SYSLIB0011
                return (T)_formatter.Deserialize(serializationStream);
#pragma warning restore SYSLIB0011
            }
            catch (Exception ex)
            {
                throw new SerializationException($"{ex.GetType().Name} while deserialization: {ex.Message}");
            }
        }
    }
}