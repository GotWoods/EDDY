using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*oW*r38*8*4**HVK*1*6*x2*W*9";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "oW",
			PriceIdentifierCode = "r38",
			UnitPrice = 8,
			Quantity = 4,
			CompositeUnitOfMeasure = null,
			PriceMultiplierQualifier = "HVK",
			Multiplier = 1,
			MonetaryAmount = 6,
			BasisOfUnitPriceCode = "x2",
			ConditionValue = "W",
			MultiplePriceQuantity = 9,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("HVK", 1, true)]
	[InlineData("HVK", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0) 
			subject.Multiplier = multiplier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x2", "r38", true)]
	[InlineData("x2", "", false)]
	[InlineData("", "r38", true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, string priceIdentifierCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		subject.PriceIdentifierCode = priceIdentifierCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "r38", true)]
	[InlineData("W", "", false)]
	[InlineData("", "r38", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string priceIdentifierCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.PriceIdentifierCode = priceIdentifierCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 4;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
