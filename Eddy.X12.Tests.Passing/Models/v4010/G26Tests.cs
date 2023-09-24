using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G26*qO*2V*V31WaVHb*3Rk*3*dH";

		var expected = new G26_PricingConditions()
		{
			PriceConditionCode = "qO",
			DateQualifier = "2V",
			Date = "V31WaVHb",
			QuantityBasis = "3Rk",
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "dH",
		};

		var actual = Map.MapObject<G26_PricingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qO", true)]
	public void Validation_RequiredPriceConditionCode(string priceConditionCode, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = priceConditionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "2V";
			subject.Date = "V31WaVHb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2V", "V31WaVHb", true)]
	[InlineData("2V", "", false)]
	[InlineData("", "V31WaVHb", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = "qO";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
