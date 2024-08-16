using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PYTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PYT+4++c+g+V+L";

		var expected = new PYT_PaymentTerms()
		{
			PaymentTermsTypeCodeQualifier = "4",
			PaymentTerms = null,
			TimeReferenceCode = "c",
			TermsTimeRelationCode = "g",
			PeriodTypeCode = "V",
			PeriodCountQuantity = "L",
		};

		var actual = Map.MapObject<PYT_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredPaymentTermsTypeCodeQualifier(string paymentTermsTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new PYT_PaymentTerms();
		//Required fields
		//Test Parameters
		subject.PaymentTermsTypeCodeQualifier = paymentTermsTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
