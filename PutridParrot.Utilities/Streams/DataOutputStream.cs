using System;
using System.IO;

namespace PutridParrot.Utilities;

/// <summary>
/// The DataOutputStream is a .NET implementation of
/// the Java DataOutputStream. 
/// </summary>
public class DataOutputStream
{
    /// <summary>
    /// The writer used to interact with the stream.
    /// </summary>
    protected readonly BinaryWriter _writer;

    /// <summary>
    /// Creates a new instance of a DataOutputStream.
    /// </summary>
    /// <param name="stream">An instantiated output stream.</param>
    public DataOutputStream(Stream stream)
    {
        _writer = new BinaryWriter(stream);
    }
    /// <summary>
    /// Closes the stream.
    /// </summary>
    public void Close()
    {
        _writer.Close();
    }
    /// <summary>
    /// Writes data to the output stream.
    /// </summary>
    /// <param name="b">The buffer to be written.</param>
    public virtual void Write(byte[] b)
    {
        _writer.Write(b);
    }
    /// <summary>
    /// Writes data to the output stream.
    /// </summary>
    /// <param name="b">The buffer to be written</param>
    /// <param name="off">The starting point in the buffer</param>
    /// <param name="len">The length of the buffer to be output</param>
    public virtual void Write(byte[] b, int off, int len)
    {
        _writer.Write(b, off, len);
    }
    /// <summary>
    /// Writes an integer to the output stream.
    /// </summary>
    /// <param name="b">The value to be written.</param>
    public virtual void Write(int b)
    {
        _writer.Write(b);
    }
    /// <summary>
    /// Writes a boolean value to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    /// <example>
    /// This sample shows how to use the WriteBoolean method.
    /// <code>
    /// [C#]
    /// DataOutputStream dos = new DataOutputStream(stream);
    /// 
    /// dos.WriteBoolean(true);
    /// </code>
    /// </example>
    public virtual void WriteBoolean(bool v)
    {
        _writer.Write(Convert.ToByte(v));
    }
    /// <summary>
    /// Writes a byte to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteByte(int v)
    {
        Write(v);
    }
    /// <summary>
    /// Writes a short to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteShort(int v)
    {
        var b = new byte[2];
        b[0] = (byte)(0xff & (v >> 8));
        b[1] = (byte)(0xff & v);
        Write(b);
    }
    /// <summary>
    /// Writes a char to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteChar(int v)
    {
        var b = new byte[2];
        b[0] = (byte)(0xff & (v >> 8));
        b[1] = (byte)(0xff & v);
        Write(b);
    }
    /// <summary>
    /// Writes an integer to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteInt(int v)
    {
        var b = new byte[4];
        b[0] = (byte)(0xff & (v >> 24));
        b[1] = (byte)(0xff & (v >> 16));
        b[2] = (byte)(0xff & (v >> 8));
        b[3] = (byte)(0xff & v);
        Write(b);
    }
    /// <summary>
    /// Writes a long to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteLong(long v)
    {
        var b = new byte[8];
        b[0] = (byte)(0xff & (v >> 56));
        b[1] = (byte)(0xff & (v >> 48));
        b[2] = (byte)(0xff & (v >> 40));
        b[3] = (byte)(0xff & (v >> 32));
        b[4] = (byte)(0xff & (v >> 24));
        b[5] = (byte)(0xff & (v >> 16));
        b[6] = (byte)(0xff & (v >> 8));
        b[7] = (byte)(0xff & v);
        Write(b);
    }
    /// <summary>
    /// Writes a float to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteFloat(float v)
    {
        var b = BitConverter.GetBytes(v);
        WriteInt(BitConverter.ToInt32(b, 0));
    }
    /// <summary>
    /// Writes a double to the output stream.
    /// </summary>
    /// <param name="v">The value to be written.</param>
    public virtual void WriteDouble(double v)
    {
        var b = BitConverter.GetBytes(v);
        WriteLong(BitConverter.ToInt64(b, 0));
    }
    /// <summary>
    /// Writes bytes to the output stream.
    /// </summary>
    /// <param name="s">The value to be written.</param>
    public virtual void WriteBytes(string s)
    {
        var utf8 = new System.Text.UTF8Encoding();
        var sb = utf8.GetBytes(s);
        _writer.Write(sb);
    }
    /// <summary>
    /// Writes characters to the output stream.
    /// </summary>
    /// <param name="s">The value to be written</param>
    public virtual void WriteChars(string s)
    {
        var utf8 = new System.Text.UTF8Encoding();
        var sb = utf8.GetBytes(s);
        _writer.Write(sb);
    }
    /// <summary>
    /// Write a UTF string to the output stream.
    /// </summary>
    /// <param name="str">The value to be written.</param>
    public virtual void WriteUtf(string str)
    {
        var b = new byte[2];
        b[0] = (byte)(0xff & (str.Length >> 8));
        b[1] = (byte)(0xff & str.Length);
        _writer.Write(b);

        var utf8 = new System.Text.UTF8Encoding();
        var sb = utf8.GetBytes(str);
        _writer.Write(sb);
    }
}