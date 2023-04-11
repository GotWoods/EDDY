using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RP*cCQ*dy*wM*D*K*m*2*s*U";

		var expected = new RP_RetirementProduct()
		{
			MaintenanceTypeCode = "cCQ",
			InsuranceLineCode = "dy",
			MaintenanceReasonCode = "wM",
			Description = "D",
			ParticipantStatusCode = "K",
			YesNoConditionOrResponseCode = "m",
			SpecialProcessingType = "2",
			Authority = "s",
			PlanCoverageDescription = "U",
		};

		var actual = Map.MapObject<RP_RetirementProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cCQ", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new RP_RetirementProduct();
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
