namespace Eddy.Core.Validation;

/// <summary>How serious a validation <see cref="Error"/> is. <see cref="ValidationResult.IsValid"/> only
/// counts <see cref="Error"/>-severity entries; a result with only Warning or Info entries is still valid.</summary>
public enum ErrorSeverity
{
    Error,
    Warning,
    Info,
}

public class Error
{
    public ErrorCodes ErrorCode { get; set; }
    public object[] Data { get; set; }

    /// <summary>The model property the error is about, when it concerns one element (e.g. "EntityIdentifierCode").</summary>
    public string PropertyName { get; set; }

    /// <summary>The element's position within its segment (the [Position] value), when known.</summary>
    public int? ElementPosition { get; set; }

    /// <summary>How serious this entry is. Defaults to <see cref="ErrorSeverity.Error"/>, matching every
    /// rule that predates severities.</summary>
    public ErrorSeverity Severity { get; set; } = ErrorSeverity.Error;
    //public int Code { get; set; }
    public Error(ErrorCodes errorCode, params string[] data)
    {
        ErrorCode = errorCode;
        Data = data;
    }

    public override string ToString()
    {
        var message = string.Format(ErrorCode.Message, Data);
        return Severity == ErrorSeverity.Warning ? "warning: " + message : message;
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

    //x12document structural issues
    public static ErrorCodes TransactionSetSegmentCountMismatch = new ErrorCodes(4000, "Expected SE Number of Included Segments to be {0} but was {1}");
    public static ErrorCodes TransactionSetControlNumberMismatch = new ErrorCodes(4001, "Expected SE Control Number to be {0} but was {1}");
    public static ErrorCodes FunctionalGroupSectionCountMismatch = new ErrorCodes(4002, "Expected GE Number of Included Sections to be {0} but was {1}");
    public static ErrorCodes FunctionalGroupControlNumberMismatch = new ErrorCodes(4003, "Expected GE Control Number to be {0} but was {1}");

    public static ErrorCodes UnknownSegment = new ErrorCodes(4004, "Segment '{0}' is not defined in version {1}");
    public static ErrorCodes InvalidInterchangeHeader = new ErrorCodes(4005, "The ISA interchange header is invalid: {0}");
    public static ErrorCodes MissingFunctionalGroupHeader = new ErrorCodes(4006, "A GS record was expected after the ISA record but it was not found");
    public static ErrorCodes SegmentOutsideTransactionSet = new ErrorCodes(4007, "Segment '{0}' appeared outside of an ST/SE transaction set");
    public static ErrorCodes UnexpectedTrailer = new ErrorCodes(4008, "Trailer '{0}' appeared without a matching header");
    public static ErrorCodes MissingTrailer = new ErrorCodes(4009, "Expected trailer '{0}' for {1} was not found");
    public static ErrorCodes InterchangeControlNumberMismatch = new ErrorCodes(4010, "Expected IEA Control Number to be {0} but was {1}");
    public static ErrorCodes InterchangeGroupCountMismatch = new ErrorCodes(4011, "Expected IEA Number of Included Functional Groups to be {0} but was {1}");
    public static ErrorCodes SegmentParseFailure = new ErrorCodes(4012, "Segment '{0}' could not be parsed: {1}");

    //edifact document structural issues
    public static ErrorCodes EdiFactTransactionSetSegmentCountMismatch = new ErrorCodes(5000, "Expected SE Number of Included Segments to be {0} but was {1}");
    public static ErrorCodes EdiFactTransactionSetControlNumberMismatch = new ErrorCodes(5001, "Expected SE Control Number to be {0} but was {1}");
    public static ErrorCodes EdiFactFunctionalGroupSectionCountMismatch = new ErrorCodes(5002, "Expected GE Number of Included Sections to be {0} but was {1}");
    public static ErrorCodes EdiFactFunctionalGroupControlNumberMismatch = new ErrorCodes(5003, "Expected GE Control Number to be {0} but was {1}");
    public static ErrorCodes EdiFactUnknownSegment = new ErrorCodes(5004, "Segment '{0}' is not defined in version {1}");
    public static ErrorCodes EdiFactInvalidInterchangeHeader = new ErrorCodes(5005, "The UNB interchange header is invalid: {0}");
    public static ErrorCodes EdiFactSegmentOutsideMessage = new ErrorCodes(5006, "Segment '{0}' appeared outside of a UNH/UNT message");
    public static ErrorCodes EdiFactUnexpectedTrailer = new ErrorCodes(5007, "Trailer '{0}' appeared without a matching header");
    public static ErrorCodes EdiFactMissingTrailer = new ErrorCodes(5008, "Expected trailer '{0}' for {1} was not found");
    public static ErrorCodes EdiFactMessageSegmentCountMismatch = new ErrorCodes(5009, "Expected UNT Number of Segments to be {0} but was {1}");
    public static ErrorCodes EdiFactMessageReferenceMismatch = new ErrorCodes(5010, "Expected UNT Message Reference to be {0} but was {1}");
    public static ErrorCodes EdiFactInterchangeControlReferenceMismatch = new ErrorCodes(5011, "Expected UNZ Interchange Control Reference to be {0} but was {1}");
    public static ErrorCodes EdiFactInterchangeMessageCountMismatch = new ErrorCodes(5012, "Expected UNZ Interchange Control Count to be {0} but was {1}");
    public static ErrorCodes EdiFactUnsupportedVersion = new ErrorCodes(5013, "Message version {0} is not available; segments were read with version {1}");
    public static ErrorCodes EdiFactSegmentParseFailure = new ErrorCodes(5014, "Segment '{0}' could not be parsed: {1}");

    //code list validation
    public static ErrorCodes UnknownCodeValue = new ErrorCodes(6000, "{0} value '{1}' is not in code list {2}");

    private ErrorCodes()
    {
    }

    private ErrorCodes(int errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }
}