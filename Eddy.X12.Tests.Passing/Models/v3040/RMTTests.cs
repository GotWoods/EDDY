using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*N2*y*6*7*9*8*5*9*1z*j";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceNumberQualifier = "N2",
			ReferenceNumber = "y",
			MonetaryAmount = 6,
			TotalInvoiceOrCreditDebitAmount = 7,
			AmountSubjectToTermsDiscount = 9,
			DiscountedAmountDue = 8,
			AmountOfDiscountTaken = 5,
			MonetaryAmount2 = 9,
			AdjustmentReasonCode = "1z",
			Description = "j",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N2", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumber = "y";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumberQualifier = "N2";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
