using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IIS*px*n*5*1*F*x*g*C*9*9*7*w*V*x4";

		var expected = new IIS_InterchangeIdentificationSegment()
		{
			ReportedStartSegmentID = "px",
			ReportedControlNumber = "n",
			ReportedDate = "5",
			ReportedTime = "1",
			ReportedInterchangeSenderIDQualifier = "F",
			ReportedSenderID = "x",
			ReportedInterchangeReceiverIDQualifier = "g",
			ReportedReceiverID = "C",
			FirstReferenceIDQualifier = "9",
			FirstReferenceID = "9",
			SecondReferenceIDQualifier = "7",
			SecondReferenceID = "w",
			InterchangeMessageDirectionCode = "V",
			ReportedGroupOrTransactionIdentifier = "x4",
		};

		var actual = Map.MapObject<IIS_InterchangeIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
