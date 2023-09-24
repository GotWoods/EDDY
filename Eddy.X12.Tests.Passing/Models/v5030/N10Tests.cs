using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*3*o*t*V*j*1l*k*1*9*O*Jq*E9*NVV";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 3,
			FreeFormDescription = "o",
			MarksAndNumbers = "t",
			CommodityCodeQualifier = "V",
			CommodityCode = "j",
			CustomsShipmentValue = "1l",
			WeightUnitCode = "k",
			Weight = 1,
			ReferenceIdentification = "9",
			ManifestUnitCode = "O",
			CountryCode = "Jq",
			CountryCode2 = "E9",
			CurrencyCode = "NVV",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "j", true)]
	[InlineData("V", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "k";
			subject.Weight = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 1, true)]
	[InlineData("k", 0, false)]
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
			subject.CommodityCodeQualifier = "V";
			subject.CommodityCode = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NVV", "1l", true)]
	[InlineData("NVV", "", false)]
	[InlineData("", "1l", true)]
	public void Validation_ARequiresBCurrencyCode(string currencyCode, string customsShipmentValue, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CurrencyCode = currencyCode;
		subject.CustomsShipmentValue = customsShipmentValue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "V";
			subject.CommodityCode = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "k";
			subject.Weight = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
