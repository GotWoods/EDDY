using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*3*0*T*O*k*99*Y*7*K*A*jT*pK*b5G";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 3,
			FreeFormDescription = "0",
			MarksAndNumbers = "T",
			CommodityCodeQualifier = "O",
			CommodityCode = "k",
			CustomsShipmentValue = 99,
			WeightUnitCode = "Y",
			Weight = 7,
			ReferenceIdentification = "K",
			ManifestUnitCode = "A",
			CountryCode = "jT",
			CountryCode2 = "pK",
			CurrencyCode = "b5G",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "k", true)]
	[InlineData("O", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "Y";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Y", 7, true)]
	[InlineData("Y", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "O";
			subject.CommodityCode = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b5G", 99, true)]
	[InlineData("b5G", 0, false)]
	[InlineData("", 99, true)]
	public void Validation_ARequiresBCurrencyCode(string currencyCode, int customsShipmentValue, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CurrencyCode = currencyCode;
		if (customsShipmentValue > 0)
			subject.CustomsShipmentValue = customsShipmentValue;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "O";
			subject.CommodityCode = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "Y";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
