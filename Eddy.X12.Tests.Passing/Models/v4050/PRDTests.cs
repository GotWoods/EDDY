using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRD*tz*1*GA*V*9*4*6*R*f*3*2";

		var expected = new PRD_MortgageLoanProductDescription()
		{
			LoanPaymentTypeCode = "tz",
			Quantity = 1,
			RateValueQualifier = "GA",
			LoanRateTypeCode = "V",
			PercentageAsDecimal = 9,
			Quantity2 = 4,
			Quantity3 = 6,
			YesNoConditionOrResponseCode = "R",
			YesNoConditionOrResponseCode2 = "f",
			Quantity4 = 3,
			MonetaryAmount = 2,
		};

		var actual = Map.MapObject<PRD_MortgageLoanProductDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tz", true)]
	public void Validation_RequiredLoanPaymentTypeCode(string loanPaymentTypeCode, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		//Required fields
		//Test Parameters
		subject.LoanPaymentTypeCode = loanPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
