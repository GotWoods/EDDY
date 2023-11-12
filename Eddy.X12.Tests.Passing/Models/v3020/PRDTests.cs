using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRD*Xb*2*lZ*L*1*2*4*d*2*2*6";

		var expected = new PRD_MortgageLoanProductDescription()
		{
			LoanPaymentTypeCode = "Xb",
			Quantity = 2,
			RateValueQualifier = "lZ",
			LoanRateTypeCode = "L",
			Percent = 1,
			Quantity2 = 2,
			Quantity3 = 4,
			YesNoConditionOrResponseCode = "d",
			YesNoConditionOrResponseCode2 = "2",
			Quantity4 = 2,
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<PRD_MortgageLoanProductDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xb", true)]
	public void Validation_RequiredLoanPaymentTypeCode(string loanPaymentTypeCode, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		//Required fields
		subject.Quantity = 2;
		//Test Parameters
		subject.LoanPaymentTypeCode = loanPaymentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PRD_MortgageLoanProductDescription();
		//Required fields
		subject.LoanPaymentTypeCode = "Xb";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
