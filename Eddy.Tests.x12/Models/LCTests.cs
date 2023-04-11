using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LC*nUJ*VA*Lp*e*1*U*1";

		var expected = new LC_LifeCoverage()
		{
			MaintenanceTypeCode = "nUJ",
			MaintenanceReasonCode = "VA",
			InsuranceLineCode = "Lp",
			PlanCoverageDescription = "e",
			Quantity = 1,
			ProductOptionCode = "U",
			YesNoConditionOrResponseCode = "1",
		};

		var actual = Map.MapObject<LC_LifeCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nUJ", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new LC_LifeCoverage();
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
