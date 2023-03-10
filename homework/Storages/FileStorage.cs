using Moravia.Homework.Exceptions;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Storages;

public class FileStorage : IStorage
{
    private readonly string filename;
    private readonly ISerializer serializer;

    public ISerializer Serializer => serializer;

    public FileStorage(string filename, ISerializer serializer)
    {
        this.filename = filename;
        this.serializer = serializer;
    }

    public T Load<T>() where T : class, new()
    {
        try {
            using var reader = new StreamReader(File.Open(filename, FileMode.Open));
            string content = reader.ReadToEnd();

            return serializer.Deserialize<T>(content);
        } catch (Exception ex) {
            throw new StorageException($"Load data from file {filename} failed.", ex);
        }
    }

    public void Save<T>(T obj) where T : class
    {
        try {
            using var writer = new StreamWriter(filename, false);
            string content = serializer.Serialize(obj);

            writer.Write(content);
        } catch (Exception ex) {
            throw new StorageException($"Save data to file {filename} failed.", ex);
        }
    }
}