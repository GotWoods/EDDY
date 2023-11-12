using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class HDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HD*kIq*DS*Mu*Q*vju*9*9*N*6*XF*X";

		var expected = new HD_HealthCoverage()
		{
			MaintenanceTypeCode = "kIq",
			MaintenanceReasonCode = "DS",
			InsuranceLineCode = "Mu",
			PlanCoverageDescription = "Q",
			CoverageLevelCode = "vju",
			Count = 9,
			Count2 = 9,
			UnderwritingDecisionCode = "N",
			YesNoConditionOrResponseCode = "6",
			DrugHouseCode = "XF",
			YesNoConditionOrResponseCode2 = "X",
		};

		var actual = Map.MapObject<HD_HealthCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kIq", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new HD_HealthCoverage();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
