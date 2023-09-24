using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class H1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H1*VCAb*pG*o*yB*v*T*H*et";

		var expected = new H1_HazardousMaterial()
		{
			HazardousMaterialCode = "VCAb",
			HazardousMaterialClassCode = "pG",
			HazardousMaterialCodeQualifier = "o",
			HazardousMaterialDescription = "yB",
			HazardousMaterialContact = "v",
			HazardousMaterialsPage = "T",
			FlashpointTemperature = "H",
			UnitOfMeasurementCode = "et",
		};

		var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VCAb", true)]
	public void Validation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = hazardousMaterialCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.FlashpointTemperature) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.FlashpointTemperature = "H";
			subject.UnitOfMeasurementCode = "et";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "et", true)]
	[InlineData("H", "", false)]
	[InlineData("", "et", false)]
	public void Validation_AllAreRequiredFlashpointTemperature(string flashpointTemperature, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = "VCAb";
		subject.FlashpointTemperature = flashpointTemperature;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
