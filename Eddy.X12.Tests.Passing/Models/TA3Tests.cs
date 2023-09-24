using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA3*kx*W*5Gy*uP*N*h*l*h*Z*E*w*fi*eToxwf*3vjJ*du*DirxLa*vgF4*6*3*o*q*FX*2*Ob*s*a6*G";

		var expected = new TA3_InterchangeDeliveryNoticeSegment()
		{
			ServiceRequestHandlerIDQualifier = "kx",
			ServiceRequestHandlerID = "W",
			ErrorReasonCode = "5Gy",
			ReportedStartSegmentID = "uP",
			ReportedControlNumber = "N",
			ReportedDate = "h",
			ReportedTime = "l",
			ReportedInterchangeSenderIDQualifier = "h",
			ReportedSenderID = "Z",
			ReportedInterchangeReceiverIDQualifier = "E",
			ReportedReceiverID = "w",
			InterchangeActionCode = "fi",
			InterchangeActionDate = "eToxwf",
			InterchangeActionTime = "3vjJ",
			InterchangeActionCode2 = "du",
			InterchangeActionDate2 = "DirxLa",
			InterchangeActionTime2 = "vgF4",
			FirstReferenceIDQualifier = "6",
			FirstReferenceID = "3",
			SecondReferenceIDQualifier = "o",
			SecondReferenceID = "q",
			ReferenceCodeQualifier = "FX",
			ReferenceCode = "2",
			ReferenceCodeQualifier2 = "Ob",
			ReferenceCode2 = "s",
			ReferenceCodeQualifier3 = "a6",
			ReferenceCode3 = "G",
		};

		var actual = Map.MapObject<TA3_InterchangeDeliveryNoticeSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kx", true)]
	public void Validation_RequiredServiceRequestHandlerIDQualifier(string serviceRequestHandlerIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ServiceRequestHandlerIDQualifier = serviceRequestHandlerIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredServiceRequestHandlerID(string serviceRequestHandlerID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ServiceRequestHandlerID = serviceRequestHandlerID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5Gy", true)]
	public void Validation_RequiredErrorReasonCode(string errorReasonCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ErrorReasonCode = errorReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validation_RequiredReportedStartSegmentID(string reportedStartSegmentID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedStartSegmentID = reportedStartSegmentID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReportedControlNumber(string reportedControlNumber, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedControlNumber = reportedControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReportedDate(string reportedDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedDate = reportedDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReportedTime(string reportedTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedTime = reportedTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReportedInterchangeSenderIDQualifier(string reportedInterchangeSenderIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedInterchangeSenderIDQualifier = reportedInterchangeSenderIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReportedSenderID(string reportedSenderID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedSenderID = reportedSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReportedInterchangeReceiverIDQualifier(string reportedInterchangeReceiverIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedInterchangeReceiverIDQualifier = reportedInterchangeReceiverIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReportedReceiverID(string reportedReceiverID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReportedReceiverID = reportedReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fi", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.InterchangeActionCode = interchangeActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eToxwf", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionTime = "3vjJ";
		subject.InterchangeActionDate = interchangeActionDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3vjJ", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = interchangeActionTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("FX", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("FX", "", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier(string referenceCodeQualifier, string referenceCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		subject.ReferenceCode = referenceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ob", "s", true)]
	[InlineData("", "s", false)]
	[InlineData("Ob", "", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier2(string referenceCodeQualifier2, string referenceCode2, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReferenceCodeQualifier2 = referenceCodeQualifier2;
		subject.ReferenceCode2 = referenceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a6", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("a6", "", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier3(string referenceCodeQualifier3, string referenceCode3, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		subject.ServiceRequestHandlerIDQualifier = "kx";
		subject.ServiceRequestHandlerID = "W";
		subject.ErrorReasonCode = "5Gy";
		subject.ReportedStartSegmentID = "uP";
		subject.ReportedControlNumber = "N";
		subject.ReportedDate = "h";
		subject.ReportedTime = "l";
		subject.ReportedInterchangeSenderIDQualifier = "h";
		subject.ReportedSenderID = "Z";
		subject.ReportedInterchangeReceiverIDQualifier = "E";
		subject.ReportedReceiverID = "w";
		subject.InterchangeActionCode = "fi";
		subject.InterchangeActionDate = "eToxwf";
		subject.InterchangeActionTime = "3vjJ";
		subject.ReferenceCodeQualifier3 = referenceCodeQualifier3;
		subject.ReferenceCode3 = referenceCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
