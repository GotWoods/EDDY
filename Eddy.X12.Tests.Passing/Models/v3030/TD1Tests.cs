using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*g4Uv9*6*M*M*C*5*4*B4";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "g4Uv9",
			LadingQuantity = 6,
			CommodityCodeQualifier = "M",
			CommodityCode = "M",
			LadingDescription = "C",
			WeightQualifier = "5",
			Weight = 4,
			UnitOrBasisForMeasurementCode = "B4",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("g4Uv9", 6, true)]
	[InlineData("g4Uv9", 0, false)]
	[InlineData("", 6, true)]
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
	[InlineData("M", "M", true)]
	[InlineData("M", "", false)]
	[InlineData("", "M", true)]
	public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
