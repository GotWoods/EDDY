using System;

namespace Eddy.Core;

public class InvalidFileFormatException : Exception
{
    public InvalidFileFormatException(string message) : base(message)
    {
    }
}