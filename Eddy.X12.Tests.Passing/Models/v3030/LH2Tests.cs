using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*Yq*B*sTEXVI0OXebn5f*1wXt*Wj*Ly*2";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "Yq",
			HazardousClassQualifier = "B",
			HazardousPlacardNotation = "sTEXVI0OXebn5f",
			HazardousEndorsement = "1wXt",
			ReportableQuantityCode = "Wj",
			UnitOrBasisForMeasurementCode = "Ly",
			Temperature = 2,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ly", 2, true)]
	[InlineData("Ly", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, int temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
