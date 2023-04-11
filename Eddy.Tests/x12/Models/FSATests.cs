using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FSA*4I2*X*Kj**w*H*h*N*N";

		var expected = new FSA_TaxAdvantageAccount()
		{
			MaintenanceTypeCode = "4I2",
			FlexibleSpendingAccountSelectionCode = "X",
			MaintenanceReasonCode = "Kj",
			TaxAdvantageAccountInformation = null,
			FrequencyCode = "w",
			PlanCoverageDescription = "H",
			ProductOptionCode = "h",
			ProductOptionCode2 = "N",
			ProductOptionCode3 = "N",
		};

		var actual = Map.MapObject<FSA_TaxAdvantageAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4I2", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new FSA_TaxAdvantageAccount();
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
