using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class HDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HD*rIp*GH*7u*Q*5ur*8*4*l*A*Ks*3";

		var expected = new HD_HealthCoverage()
		{
			MaintenanceTypeCode = "rIp",
			MaintenanceReasonCode = "GH",
			InsuranceLineCode = "7u",
			PlanCoverageDescription = "Q",
			CoverageLevelCode = "5ur",
			Count = 8,
			Count2 = 4,
			UnderwritingDecisionCode = "l",
			YesNoConditionOrResponseCode = "A",
			DrugHouseCode = "Ks",
			YesNoConditionOrResponseCode2 = "3",
		};

		var actual = Map.MapObject<HD_HealthCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rIp", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new HD_HealthCoverage();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
