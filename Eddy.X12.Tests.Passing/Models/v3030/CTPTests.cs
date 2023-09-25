using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*rE*S5r*8*6*4D*jya*8*5";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "rE",
			PriceIdentifierCode = "S5r",
			UnitPrice = 8,
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "4D",
			PriceMultiplierQualifier = "jya",
			Multiplier = 8,
			MonetaryAmount = 5,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "4D", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "4D", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("jya", 8, true)]
	[InlineData("jya", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0) 
			subject.Multiplier = multiplier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
