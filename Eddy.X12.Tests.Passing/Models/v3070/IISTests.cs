using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IIS*cw*g*b*Y*f*D*q*h*X*k*P*D*U*wx";

		var expected = new IIS_InterchangeIdentificationSegment()
		{
			ReportedStartSegmentID = "cw",
			ReportedControlNumber = "g",
			ReportedDate = "b",
			ReportedTime = "Y",
			ReportedInterchangeSenderIDQualifier = "f",
			ReportedSenderID = "D",
			ReportedInterchangeReceiverIDQualifier = "q",
			ReportedReceiverID = "h",
			FirstReferenceIDQualifier = "X",
			FirstReferenceID = "k",
			SecondReferenceIDQualifier = "P",
			SecondReferenceID = "D",
			MessageDirectionCode = "U",
			ReportedGroupOrTransactionIdentifier = "wx",
		};

		var actual = Map.MapObject<IIS_InterchangeIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
