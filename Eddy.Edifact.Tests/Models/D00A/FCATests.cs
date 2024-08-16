using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FCA+h+";

		var expected = new FCA_FinancialChargesAllocation()
		{
			SettlementMeansCode = "h",
			ChargeAllowanceAccount = null,
		};

		var actual = Map.MapObject<FCA_FinancialChargesAllocation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredSettlementMeansCode(string settlementMeansCode, bool isValidExpected)
	{
		var subject = new FCA_FinancialChargesAllocation();
		//Required fields
		//Test Parameters
		subject.SettlementMeansCode = settlementMeansCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
