using System;

namespace EdiParser;

public class InvalidFileFormatException : Exception
{
    public InvalidFileFormatException(string message) : base(message)
    {
    }
}