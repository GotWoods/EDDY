using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*c*n*8UR0pH6f*bOgofQL9*bANb1Ey1eY*0x0L1W4wD*b*5*F*Y*US*QEA*C*9*2";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "c",
			TransactionHandlingCode = "n",
			Date = "8UR0pH6f",
			Date2 = "bOgofQL9",
			OriginatingCompanyIdentifier = "bANb1Ey1eY",
			OriginatingCompanySupplementalCode = "0x0L1W4wD",
			AmountQualifierCode = "b",
			MonetaryAmount = 5,
			ReferenceIdentification = "F",
			ReferenceIdentification2 = "Y",
			DFIIDNumberQualifier = "US",
			DFIIdentificationNumber = "QEA",
			AccountNumber = "C",
			Number = 9,
			FrequencyCode = "2",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.TransactionHandlingCode = "n";
		subject.Date = "8UR0pH6f";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "b";
			subject.MonetaryAmount = 5;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "US";
			subject.DFIIdentificationNumber = "QEA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "c";
		subject.Date = "8UR0pH6f";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "b";
			subject.MonetaryAmount = 5;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "US";
			subject.DFIIdentificationNumber = "QEA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8UR0pH6f", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "c";
		subject.TransactionHandlingCode = "n";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "b";
			subject.MonetaryAmount = 5;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "US";
			subject.DFIIdentificationNumber = "QEA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b", 5, true)]
	[InlineData("b", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "c";
		subject.TransactionHandlingCode = "n";
		subject.Date = "8UR0pH6f";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "US";
			subject.DFIIdentificationNumber = "QEA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "F", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string referenceIdentification, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "c";
		subject.TransactionHandlingCode = "n";
		subject.Date = "8UR0pH6f";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "b";
			subject.MonetaryAmount = 5;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "US";
			subject.DFIIdentificationNumber = "QEA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("US", "QEA", true)]
	[InlineData("US", "", false)]
	[InlineData("", "QEA", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "c";
		subject.TransactionHandlingCode = "n";
		subject.Date = "8UR0pH6f";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "b";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
