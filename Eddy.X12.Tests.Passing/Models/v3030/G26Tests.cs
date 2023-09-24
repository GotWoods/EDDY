using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G26*q4*oI*AEsaXN*yr0*3*hy";

		var expected = new G26_PricingConditions()
		{
			PriceConditionCode = "q4",
			DateQualifier = "oI",
			Date = "AEsaXN",
			QuantityBasis = "yr0",
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "hy",
		};

		var actual = Map.MapObject<G26_PricingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q4", true)]
	public void Validation_RequiredPriceConditionCode(string priceConditionCode, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = priceConditionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "oI";
			subject.Date = "AEsaXN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oI", "AEsaXN", true)]
	[InlineData("oI", "", false)]
	[InlineData("", "AEsaXN", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = "q4";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
