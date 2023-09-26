using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class CFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFI*LY*SS*r*dSY*F*H*9E";

		var expected = new CFI_CompensationFinancialInformation()
		{
			CodeCategory = "LY",
			AdjustmentReasonCode = "SS",
			AdjustmentReasonCodeCharacteristic = "r",
			MaintenanceTypeCode = "dSY",
			FrequencyCode = "F",
			SettlementTypeCode = "H",
			LateReasonCode = "9E",
		};

		var actual = Map.MapObject<CFI_CompensationFinancialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LY", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CFI_CompensationFinancialInformation();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
