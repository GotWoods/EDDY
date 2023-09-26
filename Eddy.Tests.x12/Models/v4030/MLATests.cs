using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MLA*0*a*9*6*f*ZU**2c8";

		var expected = new MLA_MortgageLoanAuditInformation()
		{
			ReferenceIdentification = "0",
			ContractNumber = "a",
			MonetaryAmount = 9,
			Quantity = 6,
			ServiceTypeCode = "f",
			StatusCode = "ZU",
			TaxServiceNonPaymentExceptionCode = null,
			CurrencyCode = "2c8",
		};

		var actual = Map.MapObject<MLA_MortgageLoanAuditInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ContractNumber = "a";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new MLA_MortgageLoanAuditInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.ContractNumber = "a";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
