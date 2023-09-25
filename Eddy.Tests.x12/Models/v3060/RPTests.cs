using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RP*9jA*2C*8j*m*R*v*D*4*W";

		var expected = new RP_RetirementProduct()
		{
			MaintenanceTypeCode = "9jA",
			InsuranceLineCode = "2C",
			MaintenanceReasonCode = "8j",
			Description = "m",
			ParticipantStatusCode = "R",
			YesNoConditionOrResponseCode = "v",
			SpecialProcessingType = "D",
			Authority = "4",
			PlanCoverageDescription = "W",
		};

		var actual = Map.MapObject<RP_RetirementProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9jA", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new RP_RetirementProduct();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
