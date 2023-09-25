using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*G0*tMc*9*1*r9*9G6*7";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "G0",
			PriceIdentifierCode = "tMc",
			UnitPrice = 9,
			Quantity = 1,
			UnitOfMeasurementCode = "r9",
			PriceMultiplierQualifier = "9G6",
			Multiplier = 7,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "r9", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "r9", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9G6", 7, true)]
	[InlineData("9G6", 0, false)]
	[InlineData("", 7, true)]
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
