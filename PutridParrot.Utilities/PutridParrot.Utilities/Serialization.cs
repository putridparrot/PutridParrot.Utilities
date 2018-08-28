using System.Collections.Generic;
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
                using (var stream = ToStream(data))
                {
                    return FromStream<T>(stream);
                }
            }
            return default(T);
        }

        /// <summary>
        /// Turns an object into a memory stream, the caller
        /// should dispose of the stream when used
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MemoryStream ToStream<T>(T value)
        {
            var binaryFormatter = new BinaryFormatter();
            var stream = new MemoryStream();
            binaryFormatter.Serialize(stream, value);
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Turns a stream back into an object, the caller
        /// should dispose of the stream when completed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T FromStream<T>(Stream stream)
        {
            var binaryFormatter = new BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }

        public static byte[] ToBytes<T>(T value)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                return null;
            }

            using (var stream = ToStream(value))
            {                
                return stream.ToArray();
            }
        }

        public static T FromBytes<T>(byte[] bytes)
        {
            if (bytes == null)
            {
                return default(T);
            }

            using (var stream = new MemoryStream(bytes))
            {
                return FromStream<T>(stream);
            }
        }
    }
}
