using Moravia.Homework.Exceptions;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Tests;

public class JsonSerializerTest
{
    [Fact]
    public void Serialize()
    {
        // arrange
        var serializer = new JsonSerializer();
        var person = new Person
        {
            Name = "George",
            Age = 25,
        };

        // act
        var actual = serializer.Serialize(person);

        // assert
        Assert.Equal("{\"Name\":\"George\",\"Age\":25}", actual);
    }

    [Fact]
    public void Deserialize_Fail()
    {
        // arrange
        var serializer = new JsonSerializer();

        // act
        Assert.Throws<SerializerException>(() => serializer.Deserialize<Person>("\"Name\":\"Adam\",\"Age\":13}"));
    }

    [Fact]
    public void Deserialize()
    {
        // arrange
        var serializer = new JsonSerializer();
        var json = "{\"Name\":\"Adam\",\"Age\":13}";

        // act
        var actual = serializer.Deserialize<Person>(json);

        // assert
        Assert.Equal(new Person
        {
            Name = "Adam",
            Age = 13,
        }, actual);
    }

    class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Age == person.Age;
        }
    }
}