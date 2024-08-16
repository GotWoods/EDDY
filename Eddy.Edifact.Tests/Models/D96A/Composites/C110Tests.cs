using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C110Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:u:5:t:x";

		var expected = new C110_PaymentTerms()
		{
			TermsOfPaymentIdentification = "P",
			CodeListQualifier = "u",
			CodeListResponsibleAgencyCoded = "5",
			TermsOfPayment = "t",
			TermsOfPayment2 = "x",
		};

		var actual = Map.MapComposite<C110_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTermsOfPaymentIdentification(string termsOfPaymentIdentification, bool isValidExpected)
	{
		var subject = new C110_PaymentTerms();
		//Required fields
		//Test Parameters
		subject.TermsOfPaymentIdentification = termsOfPaymentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
