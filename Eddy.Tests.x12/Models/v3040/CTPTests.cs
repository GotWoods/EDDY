using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*4M*GEb*8*4*IW*gqb*9*2*Bu";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "4M",
			PriceIdentifierCode = "GEb",
			UnitPrice = 8,
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "IW",
			PriceMultiplierQualifier = "gqb",
			Multiplier = 9,
			MonetaryAmount = 2,
			BasisOfUnitPriceCode = "Bu",
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "IW", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "IW", true)]
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
	[InlineData("gqb", 9, true)]
	[InlineData("gqb", 0, false)]
	[InlineData("", 9, true)]
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

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bu", "GEb", true)]
	[InlineData("Bu", "", false)]
	[InlineData("", "GEb", true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, string priceIdentifierCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		subject.PriceIdentifierCode = priceIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
