namespace Moravia.Homework.Exceptions;

public class SerializerException : GeneralException
{
    public SerializerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}