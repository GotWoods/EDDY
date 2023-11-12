using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class H1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H1*O77a*mg*L*Ii*b*B*H*Vs";

		var expected = new H1_HazardousMaterial()
		{
			HazardousMaterialCode = "O77a",
			HazardousMaterialClassCode = "mg",
			HazardousMaterialCodeQualifier = "L",
			HazardousMaterialDescription = "Ii",
			HazardousMaterialContact = "b",
			HazardousMaterialsPage = "B",
			FlashpointTemperature = "H",
			UnitOrBasisForMeasurementCode = "Vs",
		};

		var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O77a", true)]
	public void Validation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = hazardousMaterialCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.FlashpointTemperature = "H";
			subject.UnitOrBasisForMeasurementCode = "Vs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "Vs", true)]
	[InlineData("H", "", false)]
	[InlineData("", "Vs", false)]
	public void Validation_AllAreRequiredFlashpointTemperature(string flashpointTemperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = "O77a";
		subject.FlashpointTemperature = flashpointTemperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
