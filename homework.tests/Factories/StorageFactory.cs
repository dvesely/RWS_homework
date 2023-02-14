using Moq;
using Moravia.Homework.Enums;
using Moravia.Homework.Exceptions;
using Moravia.Homework.Factories;
using Moravia.Homework.Serializers;
using Moravia.Homework.Storages;

namespace Moravia.Homework.Tests;

public class StorageFactoryTest
{
    private readonly Mock<ISerializerFactory> serializerFactoryMock;

    public StorageFactoryTest()
    {
        this.serializerFactoryMock = new Mock<ISerializerFactory>();
    }

    [Theory]
    [InlineData("file.json", SerializerType.Json)]
    [InlineData("file.xml", SerializerType.Xml)]
    public void FromFileJson(string filename, SerializerType enumType)
    {
        // arrange
        var serializerMock = new Mock<ISerializer>();
        var factory = new StorageFactory(serializerFactoryMock.Object);
        serializerFactoryMock.Setup(x => x.Create(enumType))
            .Returns(serializerMock.Object);

        // act
        var storage = factory.FromFile(filename);

        // assert
        Assert.IsType<FileStorage>(storage);
        serializerMock.VerifyAll();
        serializerFactoryMock.VerifyAll();
    }
}