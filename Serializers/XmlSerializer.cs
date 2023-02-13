using Moravia.Homework.Exceptions;

namespace Moravia.Homework.Serializers;

class XmlSerializer : ISerializer
{
    public T Deserialize<T>(string data) where T : class, new()
    {
        try
        {
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);

            writer.Write(data);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            object obj = xml.Deserialize(stream)
                ?? throw new SerializerException("Deserialize from XML is NULL.", null);

            return (T)obj;
        }
        catch (Exception ex)
        {
            throw new SerializerException("Deserialize from XML failed.", ex);
        }
    }

    public string Serialize<T>(T obj) where T : class
    {
        try
        {
            var xml = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using var stream = new MemoryStream();

            xml.Serialize(stream, obj);

            using var reader = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            throw new SerializerException("Serialize to XML failed.", ex);
        }
    }
}