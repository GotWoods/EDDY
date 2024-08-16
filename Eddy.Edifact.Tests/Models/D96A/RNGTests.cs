using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class RNGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RNG+n+";

		var expected = new RNG_RangeDetails()
		{
			RangeTypeQualifier = "n",
			Range = null,
		};

		var actual = Map.MapObject<RNG_RangeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredRangeTypeQualifier(string rangeTypeQualifier, bool isValidExpected)
	{
		var subject = new RNG_RangeDetails();
		//Required fields
		//Test Parameters
		subject.RangeTypeQualifier = rangeTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
