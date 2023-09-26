using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCT*V*3";

		var expected = new PCT_PercentAmounts()
		{
			PercentQualifier = "V",
			Percent = 3,
		};

		var actual = Map.MapObject<PCT_PercentAmounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredPercentQualifier(string percentQualifier, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		//Required fields
		subject.Percent = 3;
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPercent(decimal percent, bool isValidExpected)
	{
		var subject = new PCT_PercentAmounts();
		//Required fields
		subject.PercentQualifier = "V";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
