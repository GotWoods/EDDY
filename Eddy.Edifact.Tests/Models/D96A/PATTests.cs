using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAT+7++";

		var expected = new PAT_PaymentTermsBasis()
		{
			PaymentTermsTypeQualifier = "7",
			PaymentTerms = null,
			TermsTimeInformation = null,
		};

		var actual = Map.MapObject<PAT_PaymentTermsBasis>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPaymentTermsTypeQualifier(string paymentTermsTypeQualifier, bool isValidExpected)
	{
		var subject = new PAT_PaymentTermsBasis();
		//Required fields
		//Test Parameters
		subject.PaymentTermsTypeQualifier = paymentTermsTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
