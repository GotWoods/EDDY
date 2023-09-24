using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*5*2*x*p*b*Fv*P*8*S*g*lT*XV*Eym";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 5,
			FreeFormDescription = "2",
			MarksAndNumbers = "x",
			CommodityCodeQualifier = "p",
			CommodityCode = "b",
			CustomsShipmentValue = "Fv",
			WeightUnitCode = "P",
			Weight = 8,
			ReferenceIdentification = "S",
			ManifestUnitCode = "g",
			CountryCode = "lT",
			CountryCode2 = "XV",
			CurrencyCode = "Eym",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "b", true)]
	[InlineData("p", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.CustomsShipmentValue = "Fv";
			subject.CurrencyCode = "Eym";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "P";
			subject.Weight = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fv", "Eym", true)]
	[InlineData("Fv", "", false)]
	[InlineData("", "Eym", false)]
	public void Validation_AllAreRequiredCustomsShipmentValue(string customsShipmentValue, string currencyCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CustomsShipmentValue = customsShipmentValue;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "p";
			subject.CommodityCode = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "P";
			subject.Weight = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P", 8, true)]
	[InlineData("P", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "p";
			subject.CommodityCode = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.CustomsShipmentValue = "Fv";
			subject.CurrencyCode = "Eym";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
