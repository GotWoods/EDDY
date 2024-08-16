using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAT+C++";

		var expected = new PAT_PaymentTermsBasis()
		{
			PaymentTermsTypeCodeQualifier = "C",
			PaymentTerms = null,
			TermsTimeInformation = null,
		};

		var actual = Map.MapObject<PAT_PaymentTermsBasis>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredPaymentTermsTypeCodeQualifier(string paymentTermsTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new PAT_PaymentTermsBasis();
		//Required fields
		//Test Parameters
		subject.PaymentTermsTypeCodeQualifier = paymentTermsTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
