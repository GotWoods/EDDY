using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA3*8y*3*ZV8*MX*w*P*k*4*2*u*J*1w*0AWhOq*Gi7z*kR*Ml0QnI*Q9R4*f*G*y*H*5C*G*yr*9*Bc*k";

		var expected = new TA3_InterchangeDeliveryNoticeSegment()
		{
			ServiceRequestHandlerIDQualifier = "8y",
			ServiceRequestHandlerID = "3",
			ErrorReasonCode = "ZV8",
			ReportedStartSegmentID = "MX",
			ReportedControlNumber = "w",
			ReportedDate = "P",
			ReportedTime = "k",
			ReportedInterchangeSenderIDQualifier = "4",
			ReportedSenderID = "2",
			ReportedInterchangeReceiverIDQualifier = "u",
			ReportedReceiverID = "J",
			ActionCode = "1w",
			ActionDate = "0AWhOq",
			ActionTime = "Gi7z",
			ActionCode2 = "kR",
			ActionDate2 = "Ml0QnI",
			ActionTime2 = "Q9R4",
			FirstReferenceIDQualifier = "f",
			FirstReferenceID = "G",
			SecondReferenceIDQualifier = "y",
			SecondReferenceID = "H",
			ReferenceCodeQualifier = "5C",
			ReferenceCode = "G",
			ReferenceCodeQualifier2 = "yr",
			ReferenceCode2 = "9",
			ReferenceCodeQualifier3 = "Bc",
			ReferenceCode3 = "k",
		};

		var actual = Map.MapObject<TA3_InterchangeDeliveryNoticeSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8y", true)]
	public void Validation_RequiredServiceRequestHandlerIDQualifier(string serviceRequestHandlerIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ServiceRequestHandlerIDQualifier = serviceRequestHandlerIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredServiceRequestHandlerID(string serviceRequestHandlerID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ServiceRequestHandlerID = serviceRequestHandlerID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZV8", true)]
	public void Validation_RequiredErrorReasonCode(string errorReasonCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ErrorReasonCode = errorReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MX", true)]
	public void Validation_RequiredReportedStartSegmentID(string reportedStartSegmentID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedStartSegmentID = reportedStartSegmentID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReportedControlNumber(string reportedControlNumber, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedControlNumber = reportedControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReportedDate(string reportedDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedDate = reportedDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReportedTime(string reportedTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedTime = reportedTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReportedInterchangeSenderIDQualifier(string reportedInterchangeSenderIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedInterchangeSenderIDQualifier = reportedInterchangeSenderIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReportedSenderID(string reportedSenderID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedSenderID = reportedSenderID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReportedInterchangeReceiverIDQualifier(string reportedInterchangeReceiverIDQualifier, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedInterchangeReceiverIDQualifier = reportedInterchangeReceiverIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReportedReceiverID(string reportedReceiverID, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReportedReceiverID = reportedReceiverID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1w", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0AWhOq", true)]
	public void Validation_RequiredActionDate(string actionDate, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ActionDate = actionDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gi7z", true)]
	public void Validation_RequiredActionTime(string actionTime, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		//Test Parameters
		subject.ActionTime = actionTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5C", "G", true)]
	[InlineData("5C", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier(string referenceCodeQualifier, string referenceCode, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReferenceCodeQualifier = referenceCodeQualifier;
		subject.ReferenceCode = referenceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yr", "9", true)]
	[InlineData("yr", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier2(string referenceCodeQualifier2, string referenceCode2, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReferenceCodeQualifier2 = referenceCodeQualifier2;
		subject.ReferenceCode2 = referenceCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier3) || !string.IsNullOrEmpty(subject.ReferenceCode3))
		{
			subject.ReferenceCodeQualifier3 = "Bc";
			subject.ReferenceCode3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bc", "k", true)]
	[InlineData("Bc", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredReferenceCodeQualifier3(string referenceCodeQualifier3, string referenceCode3, bool isValidExpected)
	{
		var subject = new TA3_InterchangeDeliveryNoticeSegment();
		//Required fields
		subject.ServiceRequestHandlerIDQualifier = "8y";
		subject.ServiceRequestHandlerID = "3";
		subject.ErrorReasonCode = "ZV8";
		subject.ReportedStartSegmentID = "MX";
		subject.ReportedControlNumber = "w";
		subject.ReportedDate = "P";
		subject.ReportedTime = "k";
		subject.ReportedInterchangeSenderIDQualifier = "4";
		subject.ReportedSenderID = "2";
		subject.ReportedInterchangeReceiverIDQualifier = "u";
		subject.ReportedReceiverID = "J";
		subject.ActionCode = "1w";
		subject.ActionDate = "0AWhOq";
		subject.ActionTime = "Gi7z";
		//Test Parameters
		subject.ReferenceCodeQualifier3 = referenceCodeQualifier3;
		subject.ReferenceCode3 = referenceCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier) || !string.IsNullOrEmpty(subject.ReferenceCode))
		{
			subject.ReferenceCodeQualifier = "5C";
			subject.ReferenceCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCodeQualifier2) || !string.IsNullOrEmpty(subject.ReferenceCode2))
		{
			subject.ReferenceCodeQualifier2 = "yr";
			subject.ReferenceCode2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
