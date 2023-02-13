namespace Moravia.Homework.Exceptions;

class SerializerException : GeneralException
{
    public SerializerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}