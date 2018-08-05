using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// General serialization methods
    /// </summary>
    public static class Serialization
    {
        /// <summary>
        /// Clones the object passed into it using serialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data to be cloned</param>
        /// <returns>A cloned copy of the data</returns>
        public static T Clone<T>(T data)
        {
            if (data != null)
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, data);
                stream.Position = 0;

                return (T)bf.Deserialize(stream);
            }
            else
            {
                return default(T);
            }
        }
    }

}
