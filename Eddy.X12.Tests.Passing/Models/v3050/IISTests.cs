using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class IISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IIS*G6*Y*I*0*c*b*L*a*0*9*Z*I";

		var expected = new IIS_InterchangeIdentificationSegment()
		{
			ReportedInterchangeStartSegmentID = "G6",
			ReportedInterchangeControlNumber = "Y",
			ReportedInterchangeDate = "I",
			ReportedInterchangeTime = "0",
			ReportedInterchangeSenderIDQualifier = "c",
			ReportedInterchangeSenderID = "b",
			ReportedInterchangeReceiverIDQualifier = "L",
			ReportedInterchangeReceiverID = "a",
			FirstReferenceIDQualifier = "0",
			FirstReferenceID = "9",
			SecondReferenceIDQualifier = "Z",
			SecondReferenceID = "I",
		};

		var actual = Map.MapObject<IIS_InterchangeIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G6", true)]
	public void Validation_RequiredReportedInterchangeStartSegmentID(string reportedInterchangeStartSegmentID, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeStartSegmentID = reportedInterchangeStartSegmentID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReportedInterchangeControlNumber(string reportedInterchangeControlNumber, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeControlNumber = reportedInterchangeControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReportedInterchangeDate(string reportedInterchangeDate, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeDate = reportedInterchangeDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReportedInterchangeTime(string reportedInterchangeTime, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeTime = reportedInterchangeTime;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReportedInterchangeSenderIDQualifier(string reportedInterchangeSenderIDQualifier, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeSenderIDQualifier = reportedInterchangeSenderIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReportedInterchangeSenderID(string reportedInterchangeSenderID, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeSenderID = reportedInterchangeSenderID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReportedInterchangeReceiverIDQualifier(string reportedInterchangeReceiverIDQualifier, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.ReportedInterchangeReceiverIDQualifier = reportedInterchangeReceiverIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReportedInterchangeReceiverID(string reportedInterchangeReceiverID, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		//Test Parameters
		subject.ReportedInterchangeReceiverID = reportedInterchangeReceiverID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "9", true)]
	[InlineData("0", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredFirstReferenceIDQualifier(string firstReferenceIDQualifier, string firstReferenceID, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.FirstReferenceIDQualifier = firstReferenceIDQualifier;
		subject.FirstReferenceID = firstReferenceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceIDQualifier) || !string.IsNullOrEmpty(subject.SecondReferenceID))
		{
			subject.SecondReferenceIDQualifier = "Z";
			subject.SecondReferenceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "I", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredSecondReferenceIDQualifier(string secondReferenceIDQualifier, string secondReferenceID, bool isValidExpected)
	{
		var subject = new IIS_InterchangeIdentificationSegment();
		//Required fields
		subject.ReportedInterchangeStartSegmentID = "G6";
		subject.ReportedInterchangeControlNumber = "Y";
		subject.ReportedInterchangeDate = "I";
		subject.ReportedInterchangeTime = "0";
		subject.ReportedInterchangeSenderIDQualifier = "c";
		subject.ReportedInterchangeSenderID = "b";
		subject.ReportedInterchangeReceiverIDQualifier = "L";
		subject.ReportedInterchangeReceiverID = "a";
		//Test Parameters
		subject.SecondReferenceIDQualifier = secondReferenceIDQualifier;
		subject.SecondReferenceID = secondReferenceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceIDQualifier) || !string.IsNullOrEmpty(subject.FirstReferenceID))
		{
			subject.FirstReferenceIDQualifier = "0";
			subject.FirstReferenceID = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
