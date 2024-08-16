using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UGHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UGH+G";

		var expected = new UGH_AntiCollisionSegmentGroupHeader()
		{
			AntiCollisionSegmentGroupIdentification = "G",
		};

		var actual = Map.MapObject<UGH_AntiCollisionSegmentGroupHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredAntiCollisionSegmentGroupIdentification(string antiCollisionSegmentGroupIdentification, bool isValidExpected)
	{
		var subject = new UGH_AntiCollisionSegmentGroupHeader();
		//Required fields
		//Test Parameters
		subject.AntiCollisionSegmentGroupIdentification = antiCollisionSegmentGroupIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
