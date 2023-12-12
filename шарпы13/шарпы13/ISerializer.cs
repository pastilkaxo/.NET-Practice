using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace шарпы13 
    {
    public interface ISerializer
    {
         public  void Serialize(Stream serializationStream, Object obj);

       public  T Deserialize<T>(Stream serializationStream);
    }

    public class SerializationException : Exception
    {
        public SerializationException(string message) : base(message) { }
    }
}