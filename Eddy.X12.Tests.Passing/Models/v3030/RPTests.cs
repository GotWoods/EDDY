using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RP*w4l*fM*mx*B*p*Z*M";

		var expected = new RP_RetirementProduct()
		{
			MaintenanceTypeCode = "w4l",
			InsuranceLineCode = "fM",
			MaintenanceReasonCode = "mx",
			Description = "B",
			ParticipantStatusCode = "p",
			YesNoConditionOrResponseCode = "Z",
			SpecialProcessingType = "M",
		};

		var actual = Map.MapObject<RP_RetirementProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w4l", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new RP_RetirementProduct();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
