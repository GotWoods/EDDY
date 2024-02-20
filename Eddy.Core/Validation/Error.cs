namespace Eddy.Core.Validation;

public class Error
{
    public ErrorCodes ErrorCode { get; set; }
    public object[] Data { get; set; }
    //public int Code { get; set; }
    public Error(ErrorCodes errorCode, params string[] data)
    {
        ErrorCode = errorCode;
        Data = data;
    }

    public override string ToString()
    {
        return string.Format(ErrorCode.Message, Data);
    }
}

public class ErrorCodes
{
    public int ErrorCode { get; }
    public string Message { get; }
    
    public static ErrorCodes OutOfRange = new ErrorCodes(1000, "Expected {0} to be between {1} and {2} characters long but was {3}");
    public static ErrorCodes ExactLength = new ErrorCodes(1001, "Expected {0} to be exactly {1} characters long but was {2}");
    public static ErrorCodes ConvertibleToInteger = new ErrorCodes(1002, "Expected {0} to be convertible to an integer but it could not be parsed");
    public static ErrorCodes CollectionSize = new ErrorCodes(1001, "Expected {0} to be between {1} and {2} but was {3}");

    public static ErrorCodes Required = new ErrorCodes(2000, "{0} is required");
    public static ErrorCodes IfOneIsFilledAllAreRequired = new ErrorCodes(2001, "Specifying one of {0} means all are required");
    public static ErrorCodes IfOneIsFilledThenAtLeastOneOtherIsRequired = new ErrorCodes(2006, "If {0} is present, then at least one of {1} is required");
    public static ErrorCodes AtLeastOneIsRequired = new ErrorCodes(2002, "at least one of {0} is required");
    public static ErrorCodes ARequiresB = new ErrorCodes(2003, "When {0} is present, {1} is also required");
    public static ErrorCodes OnlyOneOf = new ErrorCodes(2004, "When {0} is present, {1} can not be specified");
    public static ErrorCodes AorBRequired = new ErrorCodes(2005, "{0} or {1} is required");


    public static ErrorCodes DateIsNotValidFormat = new ErrorCodes(3000, "{0} was not in the format of CCYYMMDD");
    public static ErrorCodes TimeIsNotValidFormat = new ErrorCodes(3001, "{0} was not in the format of HHMM[SS[DD]]");

    //document structural issues
    public static ErrorCodes TransactionSetSegmentCountMismatch = new ErrorCodes(4000, "Expected SE Number of Included Segments to be {0} but was {1}");
    public static ErrorCodes TransactionSetControlNumberMismatch = new ErrorCodes(4001, "Expected SE Control Number to be {0} but was {1}");
    public static ErrorCodes FunctionalGroupSectionCountMismatch = new ErrorCodes(4002, "Expected GE Number of Included Sections to be {0} but was {1}");
    public static ErrorCodes FunctionalGroupControlNumberMismatch = new ErrorCodes(4003, "Expected GE Control Number to be {0} but was {1}");

    private ErrorCodes()
    {
    }

    private ErrorCodes(int errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }
}