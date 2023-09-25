using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRD*0P*6*s1*h*5*9*4*I*l*7*6";

		var expected = new PRD_MortgageLoanProductDescription()
		{
			LoanPaymentTypeCode = "0P",
			Quantity = 6,
			RateValueQualifier = "s1",
			LoanRateTypeCode = "h",
			Percent = 5,
			Quantity2 = 9,
			Quantity3 = 4,
			YesNoConditionOrResponseCode = "I",
			YesNoConditionOrResponseCode2 = "l",
			Quantity4 = 7,
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<PRD_MortgageLoanProductDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0P", true)]
	public void Validation_RequiredLoanPaymentTypeCode(string loanPaymentTypeCode, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		//Required fields
		//Test Parameters
		subject.LoanPaymentTypeCode = loanPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
