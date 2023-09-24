using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CST*CFV*9**5";

		var expected = new CST_CostAnalysis()
		{
			CostCode = "CFV",
			MonetaryAmount = 9,
			CompositeUnitOfMeasure = null,
			Quantity = 5,
		};

		var actual = Map.MapObject<CST_CostAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CFV", true)]
	public void Validation_RequiredCostCode(string costCode, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.MonetaryAmount = 9;
		subject.CostCode = costCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.CostCode = "CFV";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
