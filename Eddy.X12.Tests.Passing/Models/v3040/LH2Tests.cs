using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*K*G*F8QCJZk7JldT5S*qbve*Tq*7W*3";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "K",
			HazardousClassQualifier = "G",
			HazardousPlacardNotation = "F8QCJZk7JldT5S",
			HazardousEndorsement = "qbve",
			ReportableQuantityCode = "Tq",
			UnitOrBasisForMeasurementCode = "7W",
			Temperature = 3,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7W", 3, true)]
	[InlineData("7W", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, int temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
