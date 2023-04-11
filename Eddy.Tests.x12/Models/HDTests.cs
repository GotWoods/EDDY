using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HD*1le*pl*iu*8*76m*3*7*r*T*fY*m";

		var expected = new HD_HealthCoverage()
		{
			MaintenanceTypeCode = "1le",
			MaintenanceReasonCode = "pl",
			InsuranceLineCode = "iu",
			PlanCoverageDescription = "8",
			CoverageLevelCode = "76m",
			Count = 3,
			Count2 = 7,
			UnderwritingDecisionCode = "r",
			YesNoConditionOrResponseCode = "T",
			DrugHouseCode = "fY",
			YesNoConditionOrResponseCode2 = "m",
		};

		var actual = Map.MapObject<HD_HealthCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1le", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new HD_HealthCoverage();
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
