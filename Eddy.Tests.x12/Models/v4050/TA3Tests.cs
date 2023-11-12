using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA3*tP*v*neK*cI*8*q*4*p*D*5*u*O0*ZCbaPv*J0PK*LF*TQt3SE*RcdY*y*5*8*J*KT*i*t4*9*uy*S";

		var expected = new TA3_InterchangeDeliveryNoticeSegment()
		{
			ServiceRequestHandlerIDQualifier = "tP",
			ServiceRequestHandlerID = "v",
			ErrorReasonCode = "neK",
			ReportedStartSegmentID = "cI",
			ReportedControlNumber = "8",
			ReportedDate = "q",
			ReportedTime = "4",
			ReportedInterchangeSenderIDQualifier = "p",
			ReportedSenderID = "D",
			ReportedInterchangeReceiverIDQualifier = "5",
			ReportedReceiverID = "u",
			InterchangeActionCode = "O0",
			InterchangeActionDate = "ZCbaPv",
			InterchangeActionTime = "J0PK",
			InterchangeActionCode2 = "LF",
			InterchangeActionDate2 = "TQt3SE",
			InterchangeActionTime2 = "RcdY",
			FirstReferenceIDQualifier = "y",
			FirstReferenceID = "5",
			SecondReferenceIDQualifier = "8",
			SecondReferenceID = "J",
			ReferenceCodeQualifier = "KT",
			ReferenceCode = "i",
			ReferenceCodeQualifier2 = "t4",
			ReferenceCode2 = "9",
			ReferenceCodeQualifier3 = "uy",
			ReferenceCode3 = "S",
		};

		var actual = Map.MapObject<TA3_InterchangeDeliveryNoticeSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tP", true)]
	public void Validation_RequiredServiceRequestHandlerIDQualifier(string serviceRequestHandlerIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ServiceRequestHandlerIDQualifier = serviceRequestHandlerIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredServiceRequestHandlerID(string serviceRequestHandlerID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ServiceRequestHandlerID = serviceRequestHandlerID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("neK", true)]
	public void Validation_RequiredErrorReasonCode(string errorReasonCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ErrorReasonCode = errorReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cI", true)]
	public void Validation_RequiredReportedStartSegmentID(string reportedStartSegmentID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedStartSegmentID = reportedStartSegmentID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReportedControlNumber(string reportedControlNumber, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedControlNumber = reportedControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReportedDate(string reportedDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedDate = reportedDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReportedTime(string reportedTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedTime = reportedTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReportedInterchangeSenderIDQualifier(string reportedInterchangeSenderIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedInterchangeSenderIDQualifier = reportedInterchangeSenderIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReportedSenderID(string reportedSenderID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedSenderID = reportedSenderID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReportedInterchangeReceiverIDQualifier(string reportedInterchangeReceiverIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedInterchangeReceiverIDQualifier = reportedInterchangeReceiverIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReportedReceiverID(string reportedReceiverID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReportedReceiverID = reportedReceiverID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O0", true)]
	public void Validation_RequiredInterchangeActionCode(string interchangeActionCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.InterchangeActionCode = interchangeActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZCbaPv", true)]
	public void Validation_RequiredInterchangeActionDate(string interchangeActionDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.InterchangeActionDate = interchangeActionDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J0PK", true)]
	public void Validation_RequiredInterchangeActionTime(string interchangeActionTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		//Test Parameters
		subject.InterchangeActionTime = interchangeActionTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KT", "i", true)]
	[InlineData("KT", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier(string referenceCodeQualifier, string referenceCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		subject.ReferenceCode = referenceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t4", "9", true)]
	[InlineData("t4", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier2(string referenceCodeQualifier2, string referenceCode2, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReferenceCodeQualifier2 = referenceCodeQualifier2;
		subject.ReferenceCode2 = referenceCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "uy";
			subject.ReferenceCode3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uy", "S", true)]
	[InlineData("uy", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier3(string referenceCodeQualifier3, string referenceCode3, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "tP";
		subject.ServiceRequestHandlerID = "v";
		subject.ErrorReasonCode = "neK";
		subject.ReportedStartSegmentID = "cI";
		subject.ReportedControlNumber = "8";
		subject.ReportedDate = "q";
		subject.ReportedTime = "4";
		subject.ReportedInterchangeSenderIDQualifier = "p";
		subject.ReportedSenderID = "D";
		subject.ReportedInterchangeReceiverIDQualifier = "5";
		subject.ReportedReceiverID = "u";
		subject.InterchangeActionCode = "O0";
		subject.InterchangeActionDate = "ZCbaPv";
		subject.InterchangeActionTime = "J0PK";
		//Test Parameters
		subject.ReferenceCodeQualifier3 = referenceCodeQualifier3;
		subject.ReferenceCode3 = referenceCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "KT";
			subject.ReferenceCode = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "t4";
			subject.ReferenceCode2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
