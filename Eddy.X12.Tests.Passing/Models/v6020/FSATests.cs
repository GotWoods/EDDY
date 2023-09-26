using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class FSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FSA*nID*m*Wq**y*C*b*a*6";

		var expected = new FSA_TaxAdvantageAccount()
		{
			MaintenanceTypeCode = "nID",
			FlexibleSpendingAccountSelectionCode = "m",
			MaintenanceReasonCode = "Wq",
			TaxAdvantageAccountInformation = null,
			FrequencyCode = "y",
			PlanCoverageDescription = "C",
			ProductOptionCode = "b",
			ProductOptionCode2 = "a",
			ProductOptionCode3 = "6",
		};

		var actual = Map.MapObject<FSA_TaxAdvantageAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nID", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new FSA_TaxAdvantageAccount();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
