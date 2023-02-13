namespace Moravia.Homework.Interfaces;

interface ISerializer
{
    string Serialize<T>(T obj) where T : class;

    T Deserialize<T>(string data) where T : class, new();
}