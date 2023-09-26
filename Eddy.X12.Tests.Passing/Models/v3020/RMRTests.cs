using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*Yb*l*py*6*1*6";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceNumberQualifier = "Yb",
			ReferenceNumber = "l",
			PaymentActionCode = "py",
			MonetaryAmount = 6,
			TotalInvoiceOrCreditDebitAmount = 1,
			DiscountAmountTaken = 6,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "Yb", true)]
	[InlineData("l", "", false)]
	[InlineData("", "Yb", true)]
	public void Validation_ARequiresBReferenceNumber(string referenceNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
