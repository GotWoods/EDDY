using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class FCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FCA+v+";

		var expected = new FCA_FinancialChargesAllocation()
		{
			SettlementCoded = "v",
			ChargeAllowanceAccount = null,
		};

		var actual = Map.MapObject<FCA_FinancialChargesAllocation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredSettlementCoded(string settlementCoded, bool isValidExpected)
	{
		var subject = new FCA_FinancialChargesAllocation();
		//Required fields
		//Test Parameters
		subject.SettlementCoded = settlementCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
