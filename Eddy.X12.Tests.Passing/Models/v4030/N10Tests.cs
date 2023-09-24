using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*1*T*x*s*8*bY*l*6*V*u*vv*5u*hmJ";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 1,
			FreeFormDescription = "T",
			MarksAndNumbers = "x",
			CommodityCodeQualifier = "s",
			CommodityCode = "8",
			CustomsShipmentValue = "bY",
			WeightUnitCode = "l",
			Weight = 6,
			ReferenceIdentification = "V",
			ManifestUnitCode = "u",
			CountryCode = "vv",
			CountryCode2 = "5u",
			CurrencyCode = "hmJ",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "8", true)]
	[InlineData("s", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.CustomsShipmentValue = "bY";
			subject.CurrencyCode = "hmJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "l";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bY", "hmJ", true)]
	[InlineData("bY", "", false)]
	[InlineData("", "hmJ", false)]
	public void Validation_AllAreRequiredCustomsShipmentValue(string customsShipmentValue, string currencyCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CustomsShipmentValue = customsShipmentValue;
		subject.CurrencyCode = currencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "s";
			subject.CommodityCode = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "l";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("l", 6, true)]
	[InlineData("l", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "s";
			subject.CommodityCode = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CustomsShipmentValue) || !string.IsNullOrEmpty(subject.CurrencyCode))
		{
			subject.CustomsShipmentValue = "bY";
			subject.CurrencyCode = "hmJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
