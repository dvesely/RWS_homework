namespace Moravia.Homework.Exceptions;

class StorageException : GeneralException
{
    public StorageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}