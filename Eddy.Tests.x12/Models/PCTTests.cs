using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCT*S*1";

		var expected = new PCT_PercentAmounts()
		{
			PercentQualifier = "S",
			PercentageAsDecimal = 1,
		};

		var actual = Map.MapObject<PCT_PercentAmounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredPercentQualifier(string percentQualifier, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		subject.PercentageAsDecimal = 1;
		subject.PercentQualifier = percentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPercentageAsDecimal(decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		subject.PercentQualifier = "S";
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
