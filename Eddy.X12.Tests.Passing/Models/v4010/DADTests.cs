using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*b*J*3cPOzFcs*1I888Hbd*ehGUDrESS9*QqdjLTAjp*n*6*b*5*E5*poi*c*1*c";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "b",
			TransactionHandlingCode = "J",
			Date = "3cPOzFcs",
			Date2 = "1I888Hbd",
			OriginatingCompanyIdentifier = "ehGUDrESS9",
			OriginatingCompanySupplementalCode = "QqdjLTAjp",
			AmountQualifierCode = "n",
			MonetaryAmount = 6,
			ReferenceIdentification = "b",
			ReferenceIdentification2 = "5",
			DFIIDNumberQualifier = "E5",
			DFIIdentificationNumber = "poi",
			AccountNumber = "c",
			Number = 1,
			FrequencyCode = "c",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.TransactionHandlingCode = "J";
		subject.Date = "3cPOzFcs";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "E5";
			subject.DFIIdentificationNumber = "poi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "b";
		subject.Date = "3cPOzFcs";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "E5";
			subject.DFIIdentificationNumber = "poi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3cPOzFcs", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "b";
		subject.TransactionHandlingCode = "J";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "E5";
			subject.DFIIdentificationNumber = "poi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 6, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "b";
		subject.TransactionHandlingCode = "J";
		subject.Date = "3cPOzFcs";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "E5";
			subject.DFIIdentificationNumber = "poi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "b", true)]
	[InlineData("5", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string referenceIdentification, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "b";
		subject.TransactionHandlingCode = "J";
		subject.Date = "3cPOzFcs";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "E5";
			subject.DFIIdentificationNumber = "poi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E5", "poi", true)]
	[InlineData("E5", "", false)]
	[InlineData("", "poi", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "b";
		subject.TransactionHandlingCode = "J";
		subject.Date = "3cPOzFcs";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
