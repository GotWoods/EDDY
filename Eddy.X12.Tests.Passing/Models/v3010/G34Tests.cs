using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G34Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G34*N5*C*zE*s*R*Q*b*Gi*s1*v";

		var expected = new G34_TotalInvoiceMemoAmount()
		{
			ReferenceNumberQualifier = "N5",
			ReferenceNumber = "C",
			TotalNetInvoicePayment = "zE",
			TotalInvoiceAmount = "s",
			AmountSubjectToTermsDiscount = "R",
			DiscountedAmountDue = "Q",
			TermsDiscountAmount = "b",
			AmountOfAdjustment = "Gi",
			AdjustmentReasonCode = "s1",
			FreeFormMessage = "v",
		};

		var actual = Map.MapObject<G34_TotalInvoiceMemoAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N5", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new G34_TotalInvoiceMemoAmount();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
