using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*BL8*9*Y*G*U*0*5*7F*6*vd";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "BL8",
			LadingQuantity = 9,
			CommodityCodeQualifier = "Y",
			CommodityCode = "G",
			LadingDescription = "U",
			WeightQualifier = "0",
			Weight = 5,
			UnitOrBasisForMeasurementCode = "7F",
			Volume = 6,
			UnitOrBasisForMeasurementCode2 = "vd",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}
	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 9, true)]
	[InlineData("BL8", 0, false)]
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
	[InlineData("", "G", true)]
	[InlineData("Y", "", false)]
	public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("0", 0, false)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
		{
			subject.Weight = weight;
			subject.UnitOrBasisForMeasurementCode = "AB";
		}

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "7F", true)]
	[InlineData(0, "7F", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		if (weight > 0)
		{
			subject.Weight = weight;
		}
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "vd", true)]
	[InlineData(0, "vd", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
}
