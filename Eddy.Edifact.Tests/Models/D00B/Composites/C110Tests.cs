using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C110Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:2:U:R:V";

		var expected = new C110_PaymentTerms()
		{
			PaymentTermsDescriptionIdentifier = "Z",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "U",
			PaymentTermsDescription = "R",
			PaymentTermsDescription2 = "V",
		};

		var actual = Map.MapComposite<C110_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredPaymentTermsDescriptionIdentifier(string paymentTermsDescriptionIdentifier, bool isValidExpected)
	{
		var subject = new C110_PaymentTerms();
		//Required fields
		//Test Parameters
		subject.PaymentTermsDescriptionIdentifier = paymentTermsDescriptionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
