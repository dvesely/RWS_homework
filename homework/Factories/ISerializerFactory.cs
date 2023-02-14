using Moravia.Homework.Enums;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Factories;

public interface ISerializerFactory
{
    /// <summary>
    /// Create serializer by type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    ISerializer Create(SerializerType type);
}