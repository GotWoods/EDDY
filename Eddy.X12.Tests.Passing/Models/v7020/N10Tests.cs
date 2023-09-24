using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*1*7*8*4*z*3M*u*1*o*Q*aR*2s*3Vo";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 1,
			FreeFormDescription = "7",
			MarksAndNumbers = "8",
			CommodityCodeQualifier = "4",
			CommodityCode = "z",
			CustomsShipmentValue = "3M",
			WeightUnitCode = "u",
			Weight = 1,
			ReferenceIdentification = "o",
			ManifestUnitCode = "Q",
			CountryCode = "aR",
			CountryCode2 = "2s",
			CurrencyCode = "3Vo",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "z", true)]
	[InlineData("4", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "u";
			subject.Weight = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("u", 1, true)]
	[InlineData("u", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "4";
			subject.CommodityCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3Vo", "3M", true)]
	[InlineData("3Vo", "", false)]
	[InlineData("", "3M", true)]
	public void Validation_ARequiresBCurrencyCode(string currencyCode, string customsShipmentValue, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CurrencyCode = currencyCode;
		subject.CustomsShipmentValue = customsShipmentValue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "4";
			subject.CommodityCode = "z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "u";
			subject.Weight = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
