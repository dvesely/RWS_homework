using Moravia.Homework.Exceptions;
using Moravia.Homework.Interfaces;
using Newtonsoft.Json;

namespace Moravia.Homework;

class JsonSerializer : ISerializer
{
    public T Deserialize<T>(string data) where T : class, new()
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(data)
            ?? throw new SerializerException("Deserialize data is NULL.", null);
        }
        catch (Exception ex)
        {
            throw new SerializerException("Deserialize data failed.", ex);
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
            throw new SerializerException("Serialize data failed.", ex);
        }
    }
}