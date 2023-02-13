namespace Moravia.Homework.Exceptions;

class GeneralException : Exception
{
    public GeneralException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}