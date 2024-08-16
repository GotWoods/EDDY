using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCS+P+U";

		var expected = new UCS_SegmentErrorIndication()
		{
			SegmentPositionInMessage = "P",
			SyntaxErrorCoded = "U",
		};

		var actual = Map.MapObject<UCS_SegmentErrorIndication>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredSegmentPositionInMessage(string segmentPositionInMessage, bool isValidExpected)
	{
		var subject = new UCS_SegmentErrorIndication();
		//Required fields
		//Test Parameters
		subject.SegmentPositionInMessage = segmentPositionInMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
