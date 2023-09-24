using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*f6kEV*2*1*9*u*u*4*dT";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "f6kEV",
			LadingQuantity = 2,
			CommodityCodeQualifier = "1",
			CommodityCode = "9",
			LadingDescription = "u",
			WeightQualifier = "u",
			Weight = 4,
			UnitOfMeasurementCode = "dT",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("f6kEV", 2, true)]
	[InlineData("f6kEV", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBPackagingCode(string packagingCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.PackagingCode = packagingCode;
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "9", true)]
	[InlineData("1", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("u", 4, true)]
	[InlineData("u", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
