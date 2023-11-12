using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LC*3RR*tT*ir*p*7*5*v";

		var expected = new LC_LifeCoverage()
		{
			MaintenanceTypeCode = "3RR",
			MaintenanceReasonCode = "tT",
			InsuranceLineCode = "ir",
			PlanCoverageDescription = "p",
			Quantity = 7,
			ProductOptionCode = "5",
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<LC_LifeCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3RR", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new LC_LifeCoverage();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
