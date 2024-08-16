using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UGTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UGT+i";

		var expected = new UGT_AntiCollisionSegmentGroupTrailer()
		{
			AntiCollisionSegmentGroupIdentification = "i",
		};

		var actual = Map.MapObject<UGT_AntiCollisionSegmentGroupTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAntiCollisionSegmentGroupIdentification(string antiCollisionSegmentGroupIdentification, bool isValidExpected)
	{
		var subject = new UGT_AntiCollisionSegmentGroupTrailer();
		//Required fields
		//Test Parameters
		subject.AntiCollisionSegmentGroupIdentification = antiCollisionSegmentGroupIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
