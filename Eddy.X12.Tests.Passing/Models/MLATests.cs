using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MLA*B*p*4*8*F*Ra**0hx";

		var expected = new MLA_MortgageLoanAuditInformation()
		{
			ReferenceIdentification = "B",
			ContractNumber = "p",
			MonetaryAmount = 4,
			Quantity = 8,
			ServiceTypeCode = "F",
			StatusCode = "Ra",
			TaxServiceNonPaymentExceptionCode = null,
			CurrencyCode = "0hx",
		};

		var actual = Map.MapObject<MLA_MortgageLoanAuditInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		subject.ContractNumber = "p";
		subject.MonetaryAmount = 4;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		subject.ReferenceIdentification = "B";
		subject.MonetaryAmount = 4;
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		subject.ReferenceIdentification = "B";
		subject.ContractNumber = "p";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
