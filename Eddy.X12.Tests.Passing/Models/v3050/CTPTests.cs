using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTP*1l*GIW*3*4*QM*tQV*5*3*5P*g";

		var expected = new CTP_PricingInformation()
		{
			ClassOfTradeCode = "1l",
			PriceIdentifierCode = "GIW",
			UnitPrice = 3,
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "QM",
			PriceMultiplierQualifier = "tQV",
			Multiplier = 5,
			MonetaryAmount = 3,
			BasisOfUnitPriceCode = "5P",
			ConditionValue = "g",
		};

		var actual = Map.MapObject<CTP_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "QM", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "QM", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tQV", 5, true)]
	[InlineData("tQV", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0) 
			subject.Multiplier = multiplier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 4;
			subject.UnitOrBasisForMeasurementCode = "QM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5P", "GIW", true)]
	[InlineData("5P", "", false)]
	[InlineData("", "GIW", true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, string priceIdentifierCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		subject.PriceIdentifierCode = priceIdentifierCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 4;
			subject.UnitOrBasisForMeasurementCode = "QM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "GIW", true)]
	[InlineData("g", "", false)]
	[InlineData("", "GIW", true)]
	public void Validation_ARequiresBConditionValue(string conditionValue, string priceIdentifierCode, bool isValidExpected)
	{
		var subject = new CTP_PricingInformation();
		//Required fields
		//Test Parameters
		subject.ConditionValue = conditionValue;
		subject.PriceIdentifierCode = priceIdentifierCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 4;
			subject.UnitOrBasisForMeasurementCode = "QM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
