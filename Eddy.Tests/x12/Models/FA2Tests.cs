using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FA2*RL*q";

		var expected = new FA2_AccountingData()
		{
			BreakdownStructureDetailCode = "RL",
			FinancialInformationCode = "q",
		};

		var actual = Map.MapObject<FA2_AccountingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RL", true)]
	public void Validatation_RequiredBreakdownStructureDetailCode(string breakdownStructureDetailCode, bool isValidExpected)
	{
		var subject = new FA2_AccountingData();
		subject.FinancialInformationCode = "q";
		subject.BreakdownStructureDetailCode = breakdownStructureDetailCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validatation_RequiredFinancialInformationCode(string financialInformationCode, bool isValidExpected)
	{
		var subject = new FA2_AccountingData();
		subject.BreakdownStructureDetailCode = "RL";
		subject.FinancialInformationCode = financialInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
