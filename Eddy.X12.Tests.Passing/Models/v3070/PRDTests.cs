using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRD*v6*4*0I*t*5*8*4*R*f*1*8";

		var expected = new PRD_MortgageLoanProductDescription()
		{
			LoanPaymentTypeCode = "v6",
			Quantity = 4,
			RateValueQualifier = "0I",
			LoanRateTypeCode = "t",
			Percent = 5,
			Quantity2 = 8,
			Quantity3 = 4,
			YesNoConditionOrResponseCode = "R",
			YesNoConditionOrResponseCode2 = "f",
			Quantity4 = 1,
			MonetaryAmount = 8,
		};

		var actual = Map.MapObject<PRD_MortgageLoanProductDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v6", true)]
	public void Validation_RequiredLoanPaymentTypeCode(string loanPaymentTypeCode, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		//Required fields
		//Test Parameters
		subject.LoanPaymentTypeCode = loanPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
