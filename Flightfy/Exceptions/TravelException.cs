namespace Flightfy.Exceptions;

public class TravelException : Exception
{
    public string ErrorType { get; }

    public TravelException(string message, string errorType = "GENERAL") : base(message)
    {
        ErrorType = errorType;
    } 
}