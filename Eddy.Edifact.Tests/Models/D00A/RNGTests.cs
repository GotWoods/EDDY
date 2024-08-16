using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class RNGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RNG+v+";

		var expected = new RNG_RangeDetails()
		{
			RangeTypeCodeQualifier = "v",
			Range = null,
		};

		var actual = Map.MapObject<RNG_RangeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredRangeTypeCodeQualifier(string rangeTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new RNG_RangeDetails();
		//Required fields
		//Test Parameters
		subject.RangeTypeCodeQualifier = rangeTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
