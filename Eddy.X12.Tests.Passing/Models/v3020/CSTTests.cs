using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CST*9hf*1*BV*6";

		var expected = new CST_CostAnalysis()
		{
			CostCode = "9hf",
			MonetaryAmount = 1,
			UnitOfMeasurementCode = "BV",
			Quantity = 6,
		};

		var actual = Map.MapObject<CST_CostAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9hf", true)]
	public void Validation_RequiredCostCode(string costCode, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.MonetaryAmount = 1;
		subject.CostCode = costCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.CostCode = "9hf";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "BV", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "BV", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.CostCode = "9hf";
		subject.MonetaryAmount = 1;
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
