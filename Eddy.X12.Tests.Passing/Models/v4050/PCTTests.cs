using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCT*A*3";

		var expected = new PCT_PercentAmounts()
		{
			PercentQualifier = "A",
			PercentageAsDecimal = 3,
		};

		var actual = Map.MapObject<PCT_PercentAmounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPercentQualifier(string percentQualifier, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		//Required fields
		subject.PercentageAsDecimal = 3;
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPercentageAsDecimal(decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		//Required fields
		subject.PercentQualifier = "A";
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
