using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.Tests.Models.v7040;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*6*h*9*w*9*67*r*5*t*k*nQ*Dq*pRi";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 6,
			FreeFormDescription = "h",
			MarksAndNumbers = "9",
			CommodityCodeQualifier = "w",
			CommodityCode = "9",
			CustomsShipmentValue = 67,
			WeightUnitCode = "r",
			Weight = 5,
			ReferenceIdentification = "t",
			ManifestUnitCode = "k",
			CountryCode = "nQ",
			CountryCode2 = "Dq",
			CurrencyCode = "pRi",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "9", true)]
	[InlineData("w", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "r";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("r", 5, true)]
	[InlineData("r", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "w";
			subject.CommodityCode = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pRi", 67, true)]
	[InlineData("pRi", 0, false)]
	[InlineData("", 67, true)]
	public void Validation_ARequiresBCurrencyCode(string currencyCode, int customsShipmentValue, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CurrencyCode = currencyCode;
		if (customsShipmentValue > 0)
			subject.CustomsShipmentValue = customsShipmentValue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "w";
			subject.CommodityCode = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "r";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
