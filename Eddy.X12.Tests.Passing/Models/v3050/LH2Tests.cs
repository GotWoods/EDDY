using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*b*r*52hR2zUxmshhuB*4kkH*fx*rz*2";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "b",
			HazardousClassQualifier = "r",
			HazardousPlacardNotation = "52hR2zUxmshhuB",
			HazardousEndorsement = "4kkH",
			ReportableQuantityCode = "fx",
			UnitOrBasisForMeasurementCode = "rz",
			Temperature = 2,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rz", 2, true)]
	[InlineData("rz", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
