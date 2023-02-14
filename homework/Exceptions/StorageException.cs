namespace Moravia.Homework.Exceptions;

public class StorageException : GeneralException
{
    public StorageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}