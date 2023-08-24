using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CST*BgZ*7*gh*4";

		var expected = new CST_CostAnalysis()
		{
			CostCode = "BgZ",
			MonetaryAmount = 7,
			UnitOfMeasurementCode = "gh",
			Quantity = 4,
		};

		var actual = Map.MapObject<CST_CostAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BgZ", true)]
	public void Validation_RequiredCostCode(string costCode, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.MonetaryAmount = 7;
		subject.CostCode = costCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.CostCode = "BgZ";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
