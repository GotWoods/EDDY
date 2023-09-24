using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*B*6*Q8FDf4c97YtET8*HjpT*Bw*EW*8*iB*3*LS*2";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "B",
			HazardousClassQualifier = "6",
			HazardousPlacardNotation = "Q8FDf4c97YtET8",
			HazardousEndorsement = "HjpT",
			ReportableQuantityCode = "Bw",
			UnitOrBasisForMeasurementCode = "EW",
			Temperature = 8,
			UnitOrBasisForMeasurementCode2 = "iB",
			Temperature2 = 3,
			UnitOrBasisForMeasurementCode3 = "LS",
			Temperature3 = 2,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("EW", 8, true)]
	[InlineData("EW", 0, false)]
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
			subject.UnitOrBasisForMeasurementCode2 = "iB";
			subject.Temperature2 = 3;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "LS";
			subject.Temperature3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iB", 3, true)]
	[InlineData("iB", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal temperature2, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (temperature2 > 0)
			subject.Temperature2 = temperature2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "EW";
			subject.Temperature = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3) || subject.Temperature3 > 0)
		{
			subject.UnitOrBasisForMeasurementCode3 = "LS";
			subject.Temperature3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("LS", 2, true)]
	[InlineData("LS", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal temperature3, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (temperature3 > 0)
			subject.Temperature3 = temperature3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "EW";
			subject.Temperature = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "iB";
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
