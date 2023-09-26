using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class FA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FA2*FD*T";

		var expected = new FA2_AccountingData()
		{
			BreakdownStructureDetailCode = "FD",
			FinancialInformationCode = "T",
		};

		var actual = Map.MapObject<FA2_AccountingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FD", true)]
	public void Validation_RequiredBreakdownStructureDetailCode(string breakdownStructureDetailCode, bool isValidExpected)
	{
		var subject = new FA2_AccountingData();
		//Required fields
		subject.FinancialInformationCode = "T";
		//Test Parameters
		subject.BreakdownStructureDetailCode = breakdownStructureDetailCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredFinancialInformationCode(string financialInformationCode, bool isValidExpected)
	{
		var subject = new FA2_AccountingData();
		//Required fields
		subject.BreakdownStructureDetailCode = "FD";
		//Test Parameters
		subject.FinancialInformationCode = financialInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
