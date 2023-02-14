using Moravia.Homework.Enums;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Factories;

public class SerializerFactory : ISerializerFactory
{
    public ISerializer Create(SerializerType type)
    {
        switch (type)
        {
            case SerializerType.Json:
                return new JsonSerializer();

            case SerializerType.Xml:
                return new JsonSerializer();

            default:
                throw new NotSupportedException($"Type {type} is not supported.");
        }
    }
}