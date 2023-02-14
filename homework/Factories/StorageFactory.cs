using Moravia.Homework.Enums;
using Moravia.Homework.Serializers;
using Moravia.Homework.Storages;

namespace Moravia.Homework.Factories;

public class StorageFactory : IStorageFactory
{
    private readonly ISerializerFactory serializerFactory;

    public StorageFactory(ISerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory;
    }

    public IStorage FromFile(string filename)
    {
        return new FileStorage(filename, serializerFactory.Create(GetTypeByExtension(filename)));
    }

    private SerializerType GetTypeByExtension(string filename)
    {
        try {
            string ext = Path.GetExtension(filename).TrimStart('.');
            return (SerializerType)Enum.Parse(typeof(SerializerType), ext, true);
        } catch (Exception ex) {
            throw new NotSupportedException($"File storage for file {filename} is not supported.", ex);
        }
    }
}