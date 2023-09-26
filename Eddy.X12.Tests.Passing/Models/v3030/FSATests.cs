using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FSA*sHl*q*5L*4*d*w*f*H*y";

		var expected = new FSA_FlexibleSpendingAccount()
		{
			MaintenanceTypeCode = "sHl",
			FlexibleSpendingAccountSelectionCode = "q",
			MaintenanceReasonCode = "5L",
			AccountNumber = "4",
			FrequencyCode = "d",
			PlanCoverageDescription = "w",
			ProductOptionCode = "f",
			ProductOptionCode2 = "H",
			ProductOptionCode3 = "y",
		};

		var actual = Map.MapObject<FSA_FlexibleSpendingAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sHl", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new FSA_FlexibleSpendingAccount();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
