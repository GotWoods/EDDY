using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCS+I+W";

		var expected = new UCS_SegmentErrorIndication()
		{
			SegmentPositionInMessageBody = "I",
			SyntaxErrorCoded = "W",
		};

		var actual = Map.MapObject<UCS_SegmentErrorIndication>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredSegmentPositionInMessageBody(string segmentPositionInMessageBody, bool isValidExpected)
	{
		var subject = new UCS_SegmentErrorIndication();
		//Required fields
		//Test Parameters
		subject.SegmentPositionInMessageBody = segmentPositionInMessageBody;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
