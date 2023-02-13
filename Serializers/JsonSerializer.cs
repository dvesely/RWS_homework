using Moravia.Homework.Exceptions;
using Newtonsoft.Json;

namespace Moravia.Homework.Serializers;

public class JsonSerializer : ISerializer
{
    public T Deserialize<T>(string data) where T : class, new()
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(data)
            ?? throw new SerializerException("Deserialize data from JSON is NULL.", null);
        }
        catch (Exception ex)
        {
            throw new SerializerException("Deserialize from JSON failed.", ex);
        }
    }

    public string Serialize<T>(T obj) where T : class
    {
        try
        {
            return JsonConvert.SerializeObject(obj);
        }
        catch (Exception ex)
        {
            throw new SerializerException("Serialize JSON failed.", ex);
        }
    }
}