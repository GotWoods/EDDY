using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*rLE*1*v*7*z*j*8*GC*1*35";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "rLE",
			LadingQuantity = 1,
			CommodityCodeQualifier = "v",
			CommodityCode = "7",
			LadingDescription = "z",
			WeightQualifier = "j",
			Weight = 8,
			UnitOrBasisForMeasurementCode = "GC",
			Volume = 1,
			UnitOrBasisForMeasurementCode2 = "35",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rLE", 1, true)]
	[InlineData("rLE", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBPackagingCode(string packagingCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.PackagingCode = packagingCode;
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode = "GC";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode2 = "35";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "7", true)]
	[InlineData("v", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode = "GC";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode2 = "35";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("j", 8, true)]
	[InlineData("j", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode = "GC";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode2 = "35";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "GC", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "GC", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Volume = 1;
			subject.UnitOrBasisForMeasurementCode2 = "35";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "35", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "35", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new TD1_CarrierDetailsQuantityAndWeight();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 8;
			subject.UnitOrBasisForMeasurementCode = "GC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
