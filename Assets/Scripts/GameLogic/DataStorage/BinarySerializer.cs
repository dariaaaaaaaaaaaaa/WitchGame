using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Core.Utils
{
    public static class BinarySerializer
    {
        public static byte[] Serialize(object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static T Deserialize<T>(Stream stream)
        {
            var binaryFormatter = new BinaryFormatter();
            return (T) binaryFormatter.Deserialize(stream);
        }
    }
}