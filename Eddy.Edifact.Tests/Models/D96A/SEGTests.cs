using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEG+U+t+S";

		var expected = new SEG_SegmentIdentification()
		{
			SegmentTag = "U",
			ClassDesignatorCoded = "t",
			MaintenanceOperationCoded = "S",
		};

		var actual = Map.MapObject<SEG_SegmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredSegmentTag(string segmentTag, bool isValidExpected)
	{
		var subject = new SEG_SegmentIdentification();
		//Required fields
		//Test Parameters
		subject.SegmentTag = segmentTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
