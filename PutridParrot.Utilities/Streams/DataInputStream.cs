using System;
using System.IO;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// The DataInputStream is a .NET implementation of
    /// the Java DataInputStream. 
    /// </summary>
    public class DataInputStream
    {
        /// <summary>
        /// The reader used to get data from the stream.
        /// </summary>
        protected BinaryReader _reader;

        /// <summary>
        /// Initializes a new instances of the <b>DataInputStream</b>
        /// </summary>
        /// <param name="stream">A already instantiated Stream</param>
        public DataInputStream(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }
        /// <summary>
        /// Closes the stream.
        /// </summary>
        public void Close()
        {
            _reader.Close();
        }
        /// <summary>
        /// Reads an array of bytes from the input stream. 
        /// </summary>
        /// <param name="b">The byte array to receive input</param>
        public virtual void ReadFully(byte[] b)
        {
            _reader.Read(b, 0, b.Length);
        }
        /// <summary>
        /// Reads an array of bytes from the input stream starting at 
        /// an offset and for a specified length
        /// </summary>
        /// <param name="b">The yte array to receive input.</param>
        /// <param name="off">The offset where the start of the read takes place.</param>
        /// <param name="len">The number of bytes to be read.</param>
        public virtual void ReadFully(byte[] b, int off, int len)
        {
            _reader.Read(b, off, len);
        }
        /// <summary>
        /// Reads a boolean value from the stream.
        /// </summary>
        /// <returns>The value read from the stream.</returns>
        public virtual bool ReadBoolean()
        {
            byte b = ReadByte();
            return Convert.ToBoolean(b);
        }
        /// <summary>
        /// Reads a byte from the input stream.
        /// </summary>
        /// <returns>The byte read.</returns>
        public virtual byte ReadByte()
        {
            return _reader.ReadByte();
        }
        /// <summary>
        /// Reads a char from the input stream.
        /// </summary>
        /// <returns>The char read.</returns>
        public virtual char ReadChar()
        {
            var b = _reader.ReadBytes(2);
            return (char)((b[0] << 8) | (b[1] & 0xff));
        }
        /// <summary>
        /// Reads a short from the input stream.
        /// </summary>
        /// <returns>The short read.</returns>
        public virtual short ReadShort()
        {
            var b = _reader.ReadBytes(2);
            return (short)(((b[0] & 0xff) << 8) |
                (b[1] & 0xff));
        }
        /// <summary>
        /// Reads an integer from the input stream.
        /// </summary>
        /// <returns>The integer read.</returns>
        public virtual int ReadInt()
        {
            var b = _reader.ReadBytes(4);
            return (int)(((b[0] & 0xff) << 24) |
                ((b[1] & 0xff) << 16) |
                ((b[2] & 0xff) << 8) |
                (b[3] & 0xff));
        }
        /// <summary>
		/// Reads a long from the input stream.
		/// </summary>
		/// <returns>The long read.</returns>
		public virtual long ReadLong()
        {
#pragma warning disable 675
            var b = _reader.ReadBytes(8);
            return (((long)(b[0] & 0xff) << 56) |
                ((long)(b[1] & 0xff) << 48) |
                ((long)(b[2] & 0xff) << 40) |
                ((long)(b[3] & 0xff) << 32) |
                ((long)(b[4] & 0xff) << 24) |
                ((long)(b[5] & 0xff) << 16) |
                ((long)(b[6] & 0xff) << 8) |
                ((long)(b[7] & 0xff)));
#pragma warning restore 675
        }
        /// <summary>
		/// Reads an unsigned byte from the input stream.
		/// </summary>
		/// <returns>The unsigned bye read.</returns>
		public virtual int ReadUnsignedByte()
        {
            return ReadByte();
        }
        /// <summary>
        /// Reads an unsigned short from the input stream.
        /// </summary>
        /// <returns>The unsigned short read.</returns>
        public virtual ushort ReadUnsignedShort()
        {
            var b = _reader.ReadBytes(2);
            return (ushort)(((b[0] & 0xff) << 8) |
                (b[1] & 0xff));
        }
        /// <summary>
        /// Reads a float from the input stream
        /// </summary>
        /// <returns>The float read.</returns>
        public virtual float ReadFloat()
        {
            var v = ReadInt(); // 4 bytes
            var b = BitConverter.GetBytes(v);
            return BitConverter.ToSingle(b, 0);
        }
        /// <summary>
        /// Reads a double from the input stream.
        /// </summary>
        /// <returns>The double read.</returns>
        public virtual double ReadDouble()
        {
            var v = ReadLong(); // 8 bytes
            var b = BitConverter.GetBytes(v);
            return BitConverter.ToDouble(b, 0);
        }
        /// <summary>
        /// Read a line of text from the input stream.
        /// </summary>
        /// <returns>A string representing the text read.</returns>
        public virtual string ReadLine()
        {
            // this needs to be altered
            return ReadUtf();
        }
        /// <summary>
        /// Read a UTF string from the input stream.
        /// </summary>
        /// <returns>The string read.</returns>
        public virtual string ReadUtf()
        {
            var utfLength = ReadUnsignedShort();
            var b = _reader.ReadBytes(utfLength);
            var dec = System.Text.Encoding.UTF8.GetDecoder();
            var cCount = dec.GetCharCount(b, 0, b.Length);
            var c = new char[cCount];
            var charsDecodedCount = dec.GetChars(b, 0, b.Length, c, 0);
            return new string(c);
        }
        /// <summary>
        /// Skips a number bytes along the input stream.
        /// </summary>
        /// <param name="n">The number of bytes to skip</param>
        /// <returns>The new position within the input stream.</returns>
        public virtual long SkipBytes(long n)
        {
            return _reader.BaseStream.Seek(n, SeekOrigin.Current);
        }
    }
}
