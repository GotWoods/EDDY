using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class PYTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PYT+9++l+W+M+0";

		var expected = new PYT_PaymentTerms()
		{
			PaymentTermsTypeCodeQualifier = "9",
			PaymentTerms = null,
			EventTimeReferenceCode = "l",
			TermsTimeRelationCode = "W",
			PeriodTypeCode = "M",
			PeriodCountQuantity = "0",
		};

		var actual = Map.MapObject<PYT_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredPaymentTermsTypeCodeQualifier(string paymentTermsTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new PYT_PaymentTerms();
		//Required fields
		//Test Parameters
		subject.PaymentTermsTypeCodeQualifier = paymentTermsTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
