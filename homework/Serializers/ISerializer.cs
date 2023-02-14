namespace Moravia.Homework.Serializers;

public interface ISerializer
{
    string Serialize<T>(T obj) where T : class;

    T Deserialize<T>(string data) where T : class, new();
}