using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRD*tP*5*Ck*N*3*9*9*i*3*4*9";

		var expected = new PRD_MortgageLoanProductDescription()
		{
			LoanPaymentTypeCode = "tP",
			Quantity = 5,
			RateValueQualifier = "Ck",
			LoanRateTypeCode = "N",
			PercentageAsDecimal = 3,
			Quantity2 = 9,
			Quantity3 = 9,
			YesNoConditionOrResponseCode = "i",
			YesNoConditionOrResponseCode2 = "3",
			Quantity4 = 4,
			MonetaryAmount = 9,
		};

		var actual = Map.MapObject<PRD_MortgageLoanProductDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tP", true)]
	public void Validation_RequiredLoanPaymentTypeCode(string loanPaymentTypeCode, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		subject.LoanPaymentTypeCode = loanPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
