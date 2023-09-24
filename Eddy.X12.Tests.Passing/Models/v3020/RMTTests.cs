using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*Be*O*4*1*6*7*6*1*yU*k";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceNumberQualifier = "Be",
			ReferenceNumber = "O",
			MonetaryAmount = 4,
			TotalInvoiceOrCreditDebitAmount = 1,
			AmountSubjectToTermsDiscount = 6,
			DiscountedAmountDue = 7,
			DiscountAmountTaken = 6,
			MonetaryAmount2 = 1,
			AdjustmentReasonCode = "yU",
			Description = "k",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Be", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumber = "O";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumberQualifier = "Be";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
