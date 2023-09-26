using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AES*f*y*L*Q*4";

		var expected = new AES_AutomaticEquipmentIdentificationSiteInformation()
		{
			AutomaticEquipmentIdentificationSiteStatusCode = "f",
			MovementTypeCode = "y",
			TrainTerminationStatusCode = "L",
			AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "Q",
			IndustryCode = "4",
		};

		var actual = Map.MapObject<AES_AutomaticEquipmentIdentificationSiteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredAutomaticEquipmentIdentificationSiteStatusCode(string automaticEquipmentIdentificationSiteStatusCode, bool isValidExpected)
	{
		var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
		//Required fields
		subject.MovementTypeCode = "y";
		subject.TrainTerminationStatusCode = "L";
		subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "Q";
		//Test Parameters
		subject.AutomaticEquipmentIdentificationSiteStatusCode = automaticEquipmentIdentificationSiteStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredMovementTypeCode(string movementTypeCode, bool isValidExpected)
	{
		var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
		//Required fields
		subject.AutomaticEquipmentIdentificationSiteStatusCode = "f";
		subject.TrainTerminationStatusCode = "L";
		subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "Q";
		//Test Parameters
		subject.MovementTypeCode = movementTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredTrainTerminationStatusCode(string trainTerminationStatusCode, bool isValidExpected)
	{
		var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
		//Required fields
		subject.AutomaticEquipmentIdentificationSiteStatusCode = "f";
		subject.MovementTypeCode = "y";
		subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "Q";
		//Test Parameters
		subject.TrainTerminationStatusCode = trainTerminationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAutomaticEquipmentIdentificationConsistConfidenceLevelCode(string automaticEquipmentIdentificationConsistConfidenceLevelCode, bool isValidExpected)
	{
		var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
		//Required fields
		subject.AutomaticEquipmentIdentificationSiteStatusCode = "f";
		subject.MovementTypeCode = "y";
		subject.TrainTerminationStatusCode = "L";
		//Test Parameters
		subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = automaticEquipmentIdentificationConsistConfidenceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
