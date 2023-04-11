using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N10*4*l*I*z*O*24*j*5*U*K*cd*vP*3ue";

		var expected = new N10_QuantityAndDescription()
		{
			Quantity = 4,
			FreeFormDescription = "l",
			MarksAndNumbers = "I",
			CommodityCodeQualifier = "z",
			CommodityCode = "O",
			CustomsShipmentValue = 24,
			WeightUnitCode = "j",
			Weight = 5,
			ReferenceIdentification = "U",
			ManifestUnitCode = "K",
			CountryCode = "cd",
			CountryCode2 = "vP",
			CurrencyCode = "3ue",
		};

		var actual = Map.MapObject<N10_QuantityAndDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("z", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("j", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("j", 0, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 24, true)]
	[InlineData("3ue", 0, false)]
	public void Validation_ARequiresBCurrencyCode(string currencyCode, int customsShipmentValue, bool isValidExpected)
	{
		var subject = new N10_QuantityAndDescription();
		subject.CurrencyCode = currencyCode;
		if (customsShipmentValue > 0)
		subject.CustomsShipmentValue = customsShipmentValue;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
