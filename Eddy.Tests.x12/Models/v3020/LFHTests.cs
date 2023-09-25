using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LFHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFH*lFc*Q*f*P";

		var expected = new LFH_FreeformHazardousMaterialInformation()
		{
			HazardousMaterialShipmentInformationQualifier = "lFc",
			HazardousMaterialShipmentInformation = "Q",
			HazardousMaterialShipmentInformation2 = "f",
			HazardZoneCode = "P",
		};

		var actual = Map.MapObject<LFH_FreeformHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lFc", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformationQualifier(string hazardousMaterialShipmentInformationQualifier, bool isValidExpected)
	{
		var subject = new LFH_FreeformHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformation = "Q";
		//Test Parameters
		subject.HazardousMaterialShipmentInformationQualifier = hazardousMaterialShipmentInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformation(string hazardousMaterialShipmentInformation, bool isValidExpected)
	{
		var subject = new LFH_FreeformHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformationQualifier = "lFc";
		//Test Parameters
		subject.HazardousMaterialShipmentInformation = hazardousMaterialShipmentInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
