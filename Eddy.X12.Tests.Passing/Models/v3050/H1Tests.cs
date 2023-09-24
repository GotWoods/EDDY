using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class H1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H1*yEp3*f5*L*HQ*L*c*A*Z6*H";

		var expected = new H1_HazardousMaterial()
		{
			HazardousMaterialCode = "yEp3",
			HazardousMaterialClassCode = "f5",
			HazardousMaterialCodeQualifier = "L",
			HazardousMaterialDescription = "HQ",
			HazardousMaterialContact = "L",
			HazardousMaterialsPage = "c",
			FlashpointTemperature = "A",
			UnitOrBasisForMeasurementCode = "Z6",
			PackingGroupCode = "H",
		};

		var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yEp3", true)]
	public void Validation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = hazardousMaterialCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.FlashpointTemperature = "A";
			subject.UnitOrBasisForMeasurementCode = "Z6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "Z6", true)]
	[InlineData("A", "", false)]
	[InlineData("", "Z6", false)]
	public void Validation_AllAreRequiredFlashpointTemperature(string flashpointTemperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = "yEp3";
		subject.FlashpointTemperature = flashpointTemperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
