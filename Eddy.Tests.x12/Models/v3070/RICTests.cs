using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RIC*c*1*T*v*m*1Q*HdX*m*q*tL*GzW*q*T*ZA*foY";

		var expected = new RIC_FinancialReturn()
		{
			ApplicationErrorConditionCode = "c",
			MonetaryAmount = 1,
			CreditDebitFlagCode = "T",
			AccountNumber = "v",
			AccountNumberQualifier = "m",
			DFIIDNumberQualifier = "1Q",
			DFIIdentificationNumber = "HdX",
			AccountNumber2 = "m",
			AccountNumberQualifier2 = "q",
			DFIIDNumberQualifier2 = "tL",
			DFIIdentificationNumber2 = "GzW",
			AccountNumber3 = "q",
			AccountNumberQualifier3 = "T",
			DFIIDNumberQualifier3 = "ZA",
			DFIIdentificationNumber3 = "foY",
		};

		var actual = Map.MapObject<RIC_FinancialReturn>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.CreditDebitFlagCode = "T";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "v", true)]
	[InlineData("m", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1Q", "HdX", true)]
	[InlineData("1Q", "", false)]
	[InlineData("", "HdX", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "m", true)]
	[InlineData("q", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tL", "GzW", true)]
	[InlineData("tL", "", false)]
	[InlineData("", "GzW", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "q", true)]
	[InlineData("T", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "ZA";
			subject.DFIIdentificationNumber3 = "foY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZA", "foY", true)]
	[InlineData("ZA", "", false)]
	[InlineData("", "foY", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "c";
		subject.MonetaryAmount = 1;
		subject.CreditDebitFlagCode = "T";
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "1Q";
			subject.DFIIdentificationNumber = "HdX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "tL";
			subject.DFIIdentificationNumber2 = "GzW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
