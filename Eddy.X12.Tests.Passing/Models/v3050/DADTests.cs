using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*2*b*nrYgAL*RACbMy*qolH3Z36Oh*VgWHMbt0v*x*9*f*z*A0*ThQ*V*5*S";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "2",
			TransactionHandlingCode = "b",
			Date = "nrYgAL",
			Date2 = "RACbMy",
			OriginatingCompanyIdentifier = "qolH3Z36Oh",
			OriginatingCompanySupplementalCode = "VgWHMbt0v",
			AmountQualifierCode = "x",
			MonetaryAmount = 9,
			ReferenceNumber = "f",
			ReferenceNumber2 = "z",
			DFIIDNumberQualifier = "A0",
			DFIIdentificationNumber = "ThQ",
			AccountNumber = "V",
			Number = 5,
			FrequencyCode = "S",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.TransactionHandlingCode = "b";
		subject.Date = "nrYgAL";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "x";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "A0";
			subject.DFIIdentificationNumber = "ThQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "2";
		subject.Date = "nrYgAL";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "x";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "A0";
			subject.DFIIdentificationNumber = "ThQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nrYgAL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "2";
		subject.TransactionHandlingCode = "b";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "x";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "A0";
			subject.DFIIdentificationNumber = "ThQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("x", 9, true)]
	[InlineData("x", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "2";
		subject.TransactionHandlingCode = "b";
		subject.Date = "nrYgAL";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "A0";
			subject.DFIIdentificationNumber = "ThQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "f", true)]
	[InlineData("z", "", false)]
	[InlineData("", "f", true)]
	public void Validation_ARequiresBReferenceNumber2(string referenceNumber2, string referenceNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "2";
		subject.TransactionHandlingCode = "b";
		subject.Date = "nrYgAL";
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "x";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "A0";
			subject.DFIIdentificationNumber = "ThQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A0", "ThQ", true)]
	[InlineData("A0", "", false)]
	[InlineData("", "ThQ", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "2";
		subject.TransactionHandlingCode = "b";
		subject.Date = "nrYgAL";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "x";
			subject.MonetaryAmount = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
