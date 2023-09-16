using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*dNs*3*4*P*i*h*2*Zf";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "dNs",
			LadingQuantity = 3,
			CommodityCodeQualifier = "4",
			CommodityCode = "P",
			LadingDescription = "i",
			WeightQualifier = "h",
			Weight = 2,
			UnitOrBasisForMeasurementCode = "Zf",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("dNs", 3, true)]
	[InlineData("dNs", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBPackagingCode(string packagingCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.PackagingCode = packagingCode;
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 2;
			subject.UnitOrBasisForMeasurementCode = "Zf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "P", true)]
	[InlineData("4", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 2;
			subject.UnitOrBasisForMeasurementCode = "Zf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 2, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 2;
			subject.UnitOrBasisForMeasurementCode = "Zf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Zf", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Zf", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
