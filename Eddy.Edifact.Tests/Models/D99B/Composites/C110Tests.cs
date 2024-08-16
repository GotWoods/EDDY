using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C110Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:V:B:d:N";

		var expected = new C110_PaymentTerms()
		{
			PaymentTermsDescriptionIdentifier = "x",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "B",
			PaymentTermsDescription = "d",
			PaymentTermsDescription2 = "N",
		};

		var actual = Map.MapComposite<C110_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPaymentTermsDescriptionIdentifier(string paymentTermsDescriptionIdentifier, bool isValidExpected)
	{
		var subject = new C110_PaymentTerms();
		//Required fields
		//Test Parameters
		subject.PaymentTermsDescriptionIdentifier = paymentTermsDescriptionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
