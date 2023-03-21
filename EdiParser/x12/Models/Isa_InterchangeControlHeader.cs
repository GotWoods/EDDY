using System;
using System.Globalization;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("ISA")]
public class ISA_InterchangeControlHeader : EdiX12Segment
{
	[Position(01)]
	public string AuthorizationInformationQualifier { get; set; }

	[Position(02)]
	public string AuthorizationInformation { get; set; }

	[Position(03)]
	public string SecurityInformationQualifier { get; set; }

	[Position(04)]
	public string SecurityInformation { get; set; }

	[Position(05)]
	public string InterchangeSenderIdQualifier { get; set; }

	[Position(06)]
	public string InterchangeSenderId { get; set; }

	[Position(07)]
	public string InterchangeReceiverIdQualifier { get; set; }

	[Position(08)]
	public string InterchangeReceiverId { get; set; }

	[Position(09)]
	public string InterchangeDate { get; set; }

	[Position(10)]
	public string InterchangeTime { get; set; }

	[Position(11)]
	public string RepetitionSeparator { get; set; }

	[Position(12)]
	public int InterchangeControlVersionNumberCode { get; set; }

	[Position(13)]
	public string InterchangeControlNumber { get; set; }

	[Position(14)]
	public string AcknowledgmentRequestedCode { get; set; }

	[Position(15)]
	public string InterchangeUsageIndicatorCode { get; set; }

	[Position(16)]
	public string ComponentElementSeparator { get; set; }

	//ISA is fixed width so we don't use the default mapper for this
	public string ToString(MapOptions options)
    {
		var result = new StringBuilder();
		result.Append("ISA" + options.Separator);
		result.Append(AuthorizationInformationQualifier + options.Separator);  //2 characters
        result.Append(ToFixedLengthString(AuthorizationInformation,10, ' ') + options.Separator);  //10 characters
        result.Append(ToFixedLengthString(SecurityInformationQualifier,2, ' ') + options.Separator);  //2 characters
        result.Append(ToFixedLengthString(SecurityInformation,10, ' ') + options.Separator);  //10 characters
        result.Append(ToFixedLengthString(InterchangeSenderIdQualifier,2, ' ') + options.Separator);  //2 characters
        result.Append(ToFixedLengthString(InterchangeSenderId,15, ' ') + options.Separator);  //15 characters
        result.Append(ToFixedLengthString(InterchangeReceiverIdQualifier,2, ' ') + options.Separator);  //2 characters
        result.Append(ToFixedLengthString(InterchangeReceiverId,15, ' ') + options.Separator);  //15 characters
        result.Append(ToFixedLengthString(InterchangeDate,6, ' ') + options.Separator);  //6 characters
        result.Append(ToFixedLengthString(InterchangeTime,4, ' ') + options.Separator);  //4 characters
        result.Append(ToFixedLengthString(RepetitionSeparator,1, ' ') + options.Separator);  //1 characters (should this be options.Seperator
        result.Append(ToFixedLengthString(InterchangeControlVersionNumberCode.ToString(),5, '0') + options.Separator);  //5 characters
        result.Append(ToFixedLengthString(InterchangeControlNumber.ToString(),9, '0') + options.Separator);  //9 characters
        result.Append(ToFixedLengthString(AcknowledgmentRequestedCode,1, ' ') + options.Separator);  //1 characters
        result.Append(InterchangeUsageIndicatorCode + options.Separator);  //1 characters
        result.Append(ComponentElementSeparator);  //1 characters
        var resultAsString = result.ToString();
		if (!resultAsString.EndsWith(options.LineEnding))
			resultAsString += options.LineEnding;
        return resultAsString;

		/*
		 * Assert.Equal() Failure
	Expected: ISA*00*          *00*          *02*PNII           *02*FGHT           *230301*1506*U*00401*000011501*0*P*:
	Actual:   ISA*00**00**02*PNII*02*FGHT*230301*1506*U*00401*000011501*0*P*:
		 */
	}

	private string ToFixedLengthString(string input, int length, char paddingCharacter)
    {
		if (string.IsNullOrEmpty(input))
			return "".PadRight(length, paddingCharacter);
		if (paddingCharacter == ' ')//strings get padded right but numbers get padded left
		    return input.PadRight(length, paddingCharacter);
        
        return input.PadLeft(length, paddingCharacter);
    }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISA_InterchangeControlHeader>(this);
		validator.Length(x => x.AuthorizationInformationQualifier, 2);
		validator.Length(x => x.AuthorizationInformation, 10);
		validator.Length(x => x.SecurityInformationQualifier, 2);
		validator.Length(x => x.SecurityInformation, 10);
		validator.Length(x => x.InterchangeSenderIdQualifier, 2);
		validator.Length(x => x.InterchangeSenderId, 15);
		validator.Length(x => x.InterchangeReceiverIdQualifier, 2);
		validator.Length(x => x.InterchangeReceiverId, 15);
		validator.Length(x => x.InterchangeDate, 6);
		validator.Length(x => x.InterchangeTime, 4);
		validator.Length(x => x.RepetitionSeparator, 1);
		validator.Length(x => x.InterchangeControlVersionNumberCode, 5);
		validator.Length(x => x.InterchangeControlNumber, 9);
		validator.Length(x => x.AcknowledgmentRequestedCode, 1);
		validator.Length(x => x.InterchangeUsageIndicatorCode, 1);
		validator.Length(x => x.ComponentElementSeparator, 1);
		return validator.Results;
	}

    
}