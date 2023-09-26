using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class IISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IIS*xa*O*B*E*O*I*d*p*g*w*Y*X*v*9Z";

		var expected = new IIS_InterchangeIdentificationSegment()
		{
			ReportedStartSegmentID = "xa",
			ReportedControlNumber = "O",
			ReportedDate = "B",
			ReportedTime = "E",
			ReportedInterchangeSenderIDQualifier = "O",
			ReportedSenderID = "I",
			ReportedInterchangeReceiverIDQualifier = "d",
			ReportedReceiverID = "p",
			FirstReferenceIDQualifier = "g",
			FirstReferenceID = "w",
			SecondReferenceIDQualifier = "Y",
			SecondReferenceID = "X",
			InterchangeMessageDirectionCode = "v",
			ReportedGroupOrTransactionIdentifier = "9Z",
		};

		var actual = Map.MapObject<IIS_InterchangeIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
