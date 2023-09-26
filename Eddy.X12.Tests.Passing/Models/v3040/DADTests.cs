using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*C*A*YUb2Os*oapNmS*QJjG0ynS6N*0wKQLetH6*Y*2*Q*I*iZ*kvr*o*8*k";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "C",
			TransactionHandlingCode = "A",
			Date = "YUb2Os",
			Date2 = "oapNmS",
			OriginatingCompanyIdentifier = "QJjG0ynS6N",
			OriginatingCompanySupplementalCode = "0wKQLetH6",
			AmountQualifierCode = "Y",
			MonetaryAmount = 2,
			ReferenceNumber = "Q",
			ReferenceNumber2 = "I",
			DFIIDNumberQualifier = "iZ",
			DFIIdentificationNumber = "kvr",
			AccountNumber = "o",
			NumberOfDays = 8,
			FrequencyCode = "k",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.TransactionHandlingCode = "A";
		subject.Date = "YUb2Os";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "Y";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iZ";
			subject.DFIIdentificationNumber = "kvr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "C";
		subject.Date = "YUb2Os";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "Y";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iZ";
			subject.DFIIdentificationNumber = "kvr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YUb2Os", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "C";
		subject.TransactionHandlingCode = "A";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "Y";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iZ";
			subject.DFIIdentificationNumber = "kvr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Y", 2, true)]
	[InlineData("Y", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "C";
		subject.TransactionHandlingCode = "A";
		subject.Date = "YUb2Os";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iZ";
			subject.DFIIdentificationNumber = "kvr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "Q", true)]
	[InlineData("I", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBReferenceNumber2(string referenceNumber2, string referenceNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "C";
		subject.TransactionHandlingCode = "A";
		subject.Date = "YUb2Os";
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "Y";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "iZ";
			subject.DFIIdentificationNumber = "kvr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iZ", "kvr", true)]
	[InlineData("iZ", "", false)]
	[InlineData("", "kvr", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "C";
		subject.TransactionHandlingCode = "A";
		subject.Date = "YUb2Os";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "Y";
			subject.MonetaryAmount = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
