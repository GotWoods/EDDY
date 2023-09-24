using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class H1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H1*0gOq*F*P*st*s*J*B*Yq*R";

		var expected = new H1_HazardousMaterial()
		{
			HazardousMaterialCode = "0gOq",
			HazardousMaterialClassCode = "F",
			HazardousMaterialCodeQualifier = "P",
			HazardousMaterialDescription = "st",
			HazardousMaterialContact = "s",
			HazardousMaterialsPage = "J",
			FlashpointTemperature = "B",
			UnitOrBasisForMeasurementCode = "Yq",
			PackingGroupCode = "R",
		};

		var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0gOq", true)]
	public void Validation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = hazardousMaterialCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.FlashpointTemperature = "B";
			subject.UnitOrBasisForMeasurementCode = "Yq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Yq", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Yq", false)]
	public void Validation_AllAreRequiredFlashpointTemperature(string flashpointTemperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = "0gOq";
		subject.FlashpointTemperature = flashpointTemperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
