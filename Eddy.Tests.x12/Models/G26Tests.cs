using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G26*kd*sb*XqOS3mkE*mJu*9*p0";

		var expected = new G26_PricingConditions()
		{
			PriceConditionCode = "kd",
			DateQualifier = "sb",
			Date = "XqOS3mkE",
			QuantityBasisCode = "mJu",
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "p0",
		};

		var actual = Map.MapObject<G26_PricingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kd", true)]
	public void Validation_RequiredPriceConditionCode(string priceConditionCode, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = priceConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sb", "XqOS3mkE", true)]
	[InlineData("", "XqOS3mkE", false)]
	[InlineData("sb", "", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = "kd";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
