using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RIC*5*2*A*k*K*PU*MC0";

		var expected = new RIC_FinancialReturn()
		{
			ApplicationErrorConditionCode = "5",
			MonetaryAmount = 2,
			CreditDebitFlagCode = "A",
			AccountNumber = "k",
			AccountNumberQualifier = "K",
			DFIIDNumberQualifier = "PU",
			DFIIdentificationNumber = "MC0",
		};

		var actual = Map.MapObject<RIC_FinancialReturn>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "A";
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "PU";
			subject.DFIIdentificationNumber = "MC0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "5";
		subject.CreditDebitFlagCode = "A";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "PU";
			subject.DFIIdentificationNumber = "MC0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "5";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "PU";
			subject.DFIIdentificationNumber = "MC0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "k", true)]
	[InlineData("K", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "5";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "A";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "PU";
			subject.DFIIdentificationNumber = "MC0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PU", "MC0", true)]
	[InlineData("PU", "", false)]
	[InlineData("", "MC0", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "5";
		subject.MonetaryAmount = 2;
		subject.CreditDebitFlagCode = "A";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
