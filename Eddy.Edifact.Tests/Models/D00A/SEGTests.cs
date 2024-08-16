using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEG+7+N+D";

		var expected = new SEG_SegmentIdentification()
		{
			SegmentTagIdentifier = "7",
			DesignatedClassCode = "N",
			MaintenanceOperationCode = "D",
		};

		var actual = Map.MapObject<SEG_SegmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredSegmentTagIdentifier(string segmentTagIdentifier, bool isValidExpected)
	{
		var subject = new SEG_SegmentIdentification();
		//Required fields
		//Test Parameters
		subject.SegmentTagIdentifier = segmentTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
