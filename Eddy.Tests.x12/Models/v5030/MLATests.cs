using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class MLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MLA*A*v*7*2*4*Fm**ap1";

		var expected = new MLA_MortgageLoanAuditInformation()
		{
			ReferenceIdentification = "A",
			ContractNumber = "v",
			MonetaryAmount = 7,
			Quantity = 2,
			ServiceTypeCode = "4",
			StatusCode = "Fm",
			TaxServiceNonPaymentExceptionCode = null,
			CurrencyCode = "ap1",
		};

		var actual = Map.MapObject<MLA_MortgageLoanAuditInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ContractNumber = "v";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ReferenceIdentification = "A";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ReferenceIdentification = "A";
		subject.ContractNumber = "v";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
