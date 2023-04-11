using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIS*a*9*9*1";

		var expected = new FIS_MortgageLoanFiscalData()
		{
			AmountQualifierCode = "a",
			MonetaryAmount = 9,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 1,
		};

		var actual = Map.MapObject<FIS_MortgageLoanFiscalData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new FIS_MortgageLoanFiscalData();
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
