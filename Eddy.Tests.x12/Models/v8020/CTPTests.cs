using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*fM*BTY*4*3**zc3*1*1*0z*q*8*";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "fM",
			PriceIdentifierCode = "BTY",
			UnitPrice = 4,
			Quantity = 3,
			CompositeUnitOfMeasure = null,
			PriceMultiplierQualifier = "zc3",
			Multiplier = 1,
			MonetaryAmount = 1,
			BasisOfUnitPriceCode = "0z",
			ConditionValue = "q",
			MultiplePriceQuantity = 8,
			CompositeCurrency = null,
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", false)]
	[InlineData(4, "", true)]
	[InlineData(0, "A", true)]
	public void Validation_OnlyOneOfUnitPrice(decimal unitPrice, string compositeCurrency, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		if (compositeCurrency != "") 
			subject.CompositeCurrency = new C077_CompositeCurrency();
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "A", true)]
	[InlineData(3, "", false)]
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
	[InlineData("zc3", 1, true)]
	[InlineData("zc3", 0, false)]
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
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0z", "BTY", true)]
	[InlineData("0z", "", false)]
	[InlineData("", "BTY", true)]
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
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "BTY", true)]
	[InlineData("q", "", false)]
	[InlineData("", "BTY", true)]
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
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 4, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 4, true)]
	public void Validation_ARequiresBMultiplePriceQuantity(int multiplePriceQuantity, decimal unitPrice, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (multiplePriceQuantity > 0) 
			subject.MultiplePriceQuantity = multiplePriceQuantity;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
