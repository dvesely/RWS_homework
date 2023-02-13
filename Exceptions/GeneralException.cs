namespace Moravia.Homework.Exceptions;

public class GeneralException : Exception
{
    public GeneralException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}