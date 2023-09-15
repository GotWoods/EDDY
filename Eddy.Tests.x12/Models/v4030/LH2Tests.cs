using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*g*4*mR0kX1f2JGMjXD*SDle*ip*AO*4*1F*6*Cg*4*1*1";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "g",
			HazardousClassQualifier = "4",
			HazardousPlacardNotation = "mR0kX1f2JGMjXD",
			HazardousEndorsement = "SDle",
			ReportableQuantityCode = "ip",
			UnitOrBasisForMeasurementCode = "AO",
			Temperature = 4,
			UnitOrBasisForMeasurementCode2 = "1F",
			Temperature2 = 6,
			UnitOrBasisForMeasurementCode3 = "Cg",
			Temperature3 = 4,
			WeightUnitCode = "1",
			NetExplosiveQuantity = 1,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("AO", 4, true)]
	[InlineData("AO", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "1F";
			subject.Temperature2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Cg";
			subject.Temperature3 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "1";
			subject.NetExplosiveQuantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1F", 6, true)]
	[InlineData("1F", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal temperature2, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (temperature2 > 0)
			subject.Temperature2 = temperature2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "AO";
			subject.Temperature = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Cg";
			subject.Temperature3 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "1";
			subject.NetExplosiveQuantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Cg", 4, true)]
	[InlineData("Cg", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal temperature3, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (temperature3 > 0)
			subject.Temperature3 = temperature3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "AO";
			subject.Temperature = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "1F";
			subject.Temperature2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.NetExplosiveQuantity > 0)
		{
			subject.WeightUnitCode = "1";
			subject.NetExplosiveQuantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1", 1, true)]
	[InlineData("1", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, int netExplosiveQuantity, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.WeightUnitCode = weightUnitCode;
		if (netExplosiveQuantity > 0)
			subject.NetExplosiveQuantity = netExplosiveQuantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "AO";
			subject.Temperature = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "1F";
			subject.Temperature2 = 6;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "Cg";
			subject.Temperature3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
