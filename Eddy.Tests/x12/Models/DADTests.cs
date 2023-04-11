using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*0*n*bXS3OgzZ*aWRZ74Aa*u8jEcRH3Zb*wc29Rppfv*t*6*g*3*pE*4te*L*5*g";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "0",
			TransactionHandlingCode = "n",
			Date = "bXS3OgzZ",
			Date2 = "aWRZ74Aa",
			OriginatingCompanyIdentifier = "u8jEcRH3Zb",
			OriginatingCompanySupplementalCode = "wc29Rppfv",
			AmountQualifierCode = "t",
			MonetaryAmount = 6,
			ReferenceIdentification = "g",
			ReferenceIdentification2 = "3",
			DFIIDNumberQualifier = "pE",
			DFIIdentificationNumber = "4te",
			AccountNumber = "L",
			Number = 5,
			FrequencyCode = "g",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.TransactionHandlingCode = "n";
		subject.Date = "bXS3OgzZ";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validatation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.ActionCode = "0";
		subject.Date = "bXS3OgzZ";
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bXS3OgzZ", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.ActionCode = "0";
		subject.TransactionHandlingCode = "n";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("t", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("t", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.ActionCode = "0";
		subject.TransactionHandlingCode = "n";
		subject.Date = "bXS3OgzZ";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("3", "", false)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string referenceIdentification, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.ActionCode = "0";
		subject.TransactionHandlingCode = "n";
		subject.Date = "bXS3OgzZ";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("pE", "4te", true)]
	[InlineData("", "4te", false)]
	[InlineData("pE", "", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		subject.ActionCode = "0";
		subject.TransactionHandlingCode = "n";
		subject.Date = "bXS3OgzZ";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
