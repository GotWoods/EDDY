using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*Y*U*vLHrrpol0Tndld*tWYX*MO*zp*8*Ef*8*Mx*8*D*2";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassificationCode = "Y",
			HazardousClassQualifier = "U",
			HazardousPlacardNotationCode = "vLHrrpol0Tndld",
			HazardousEndorsementCode = "tWYX",
			ReportableQuantityCode = "MO",
			UnitOrBasisForMeasurementCode = "zp",
			Temperature = 8,
			UnitOrBasisForMeasurementCode2 = "Ef",
			Temperature2 = 8,
			UnitOrBasisForMeasurementCode3 = "Mx",
			Temperature3 = 8,
			WeightUnitCode = "D",
			NetExplosiveQuantity = 2,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("zp", 8, true)]
	[InlineData("zp", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ef";
			subject.Temperature2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Mx";
			subject.Temperature3 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "D";
			subject.NetExplosiveQuantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ef", 8, true)]
	[InlineData("Ef", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal temperature2, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (temperature2 > 0)
			subject.Temperature2 = temperature2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "zp";
			subject.Temperature = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Mx";
			subject.Temperature3 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "D";
			subject.NetExplosiveQuantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Mx", 8, true)]
	[InlineData("Mx", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal temperature3, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (temperature3 > 0)
			subject.Temperature3 = temperature3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "zp";
			subject.Temperature = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ef";
			subject.Temperature2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "D";
			subject.NetExplosiveQuantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 2, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, int netExplosiveQuantity, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.WeightUnitCode = weightUnitCode;
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "zp";
			subject.Temperature = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Ef";
			subject.Temperature2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Mx";
			subject.Temperature3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
