using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA3*l9*2*MVr*6b*S*T*C*R*X*4*d*uX*q8TUe1*nN1c*eR*6Vo9PA*4S54*G*2*s*m*AA*u*96*v*06*T";

		var expected = new TA3_InterchangeDeliveryNoticeSegment()
		{
			ServiceRequestHandlerIDQualifier = "l9",
			ServiceRequestHandlerID = "2",
			ErrorReasonCode = "MVr",
			ReportedInterchangeStartSegmentID = "6b",
			ReportedInterchangeControlNumber = "S",
			ReportedInterchangeDate = "T",
			ReportedInterchangeTime = "C",
			ReportedInterchangeSenderIDQualifier = "R",
			ReportedInterchangeSenderID = "X",
			ReportedInterchangeReceiverIDQualifier = "4",
			ReportedInterchangeReceiverID = "d",
			InterchangeActionCode = "uX",
			InterchangeActionDate = "q8TUe1",
			InterchangeActionTime = "nN1c",
			InterchangeActionCode2 = "eR",
			InterchangeActionDate2 = "6Vo9PA",
			InterchangeActionTime2 = "4S54",
			FirstReferenceIDQualifier = "G",
			FirstReferenceID = "2",
			SecondReferenceIDQualifier = "s",
			SecondReferenceID = "m",
			ReferenceCodeQualifier = "AA",
			ReferenceCode = "u",
			ReferenceCodeQualifier2 = "96",
			ReferenceCode2 = "v",
			ReferenceCodeQualifier3 = "06",
			ReferenceCode3 = "T",
		};

		var actual = Map.MapObject<TA3_InterchangeDeliveryNoticeSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l9", true)]
	public void Validation_RequiredServiceRequestHandlerIDQualifier(string serviceRequestHandlerIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ServiceRequestHandlerIDQualifier = serviceRequestHandlerIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredServiceRequestHandlerID(string serviceRequestHandlerID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ServiceRequestHandlerID = serviceRequestHandlerID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MVr", true)]
	public void Validation_RequiredErrorReasonCode(string errorReasonCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ErrorReasonCode = errorReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6b", true)]
	public void Validation_RequiredReportedInterchangeStartSegmentID(string reportedInterchangeStartSegmentID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeStartSegmentID = reportedInterchangeStartSegmentID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReportedInterchangeControlNumber(string reportedInterchangeControlNumber, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeControlNumber = reportedInterchangeControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReportedInterchangeDate(string reportedInterchangeDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeDate = reportedInterchangeDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReportedInterchangeTime(string reportedInterchangeTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeTime = reportedInterchangeTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReportedInterchangeSenderIDQualifier(string reportedInterchangeSenderIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeSenderIDQualifier = reportedInterchangeSenderIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReportedInterchangeSenderID(string reportedInterchangeSenderID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeSenderID = reportedInterchangeSenderID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReportedInterchangeReceiverIDQualifier(string reportedInterchangeReceiverIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeReceiverIDQualifier = reportedInterchangeReceiverIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReportedInterchangeReceiverID(string reportedInterchangeReceiverID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReportedInterchangeReceiverID = reportedInterchangeReceiverID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uX", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.InterchangeActionCode = interchangeActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q8TUe1", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.InterchangeActionDate = interchangeActionDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nN1c", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		//Test Parameters
		subject.InterchangeActionTime = interchangeActionTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AA", "u", true)]
	[InlineData("AA", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier(string referenceCodeQualifier, string referenceCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		subject.ReferenceCode = referenceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("96", "v", true)]
	[InlineData("96", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier2(string referenceCodeQualifier2, string referenceCode2, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReferenceCodeQualifier2 = referenceCodeQualifier2;
		subject.ReferenceCode2 = referenceCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "06";
			subject.ReferenceCode3 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("06", "T", true)]
	[InlineData("06", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier3(string referenceCodeQualifier3, string referenceCode3, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "l9";
		subject.ServiceRequestHandlerID = "2";
		subject.ErrorReasonCode = "MVr";
		subject.ReportedInterchangeStartSegmentID = "6b";
		subject.ReportedInterchangeControlNumber = "S";
		subject.ReportedInterchangeDate = "T";
		subject.ReportedInterchangeTime = "C";
		subject.ReportedInterchangeSenderIDQualifier = "R";
		subject.ReportedInterchangeSenderID = "X";
		subject.ReportedInterchangeReceiverIDQualifier = "4";
		subject.ReportedInterchangeReceiverID = "d";
		subject.InterchangeActionCode = "uX";
		subject.InterchangeActionDate = "q8TUe1";
		subject.InterchangeActionTime = "nN1c";
		//Test Parameters
		subject.ReferenceCodeQualifier3 = referenceCodeQualifier3;
		subject.ReferenceCode3 = referenceCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "AA";
			subject.ReferenceCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "96";
			subject.ReferenceCode2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
