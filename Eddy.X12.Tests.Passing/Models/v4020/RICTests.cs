using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class RICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RIC*rEH*U*4*3*q*c*A*Pd*FJF*4*y*6h*QI0*m*h*AS*vXh*9h2bxceu";

		var expected = new RIC_FinancialReturn()
		{
			PaymentMethodCode = "rEH",
			CodeListQualifierCode = "U",
			IndustryCode = "4",
			MonetaryAmount = 3,
			CreditDebitFlagCode = "q",
			AccountNumber = "c",
			AccountNumberQualifier = "A",
			DFIIDNumberQualifier = "Pd",
			DFIIdentificationNumber = "FJF",
			AccountNumber2 = "4",
			AccountNumberQualifier2 = "y",
			DFIIDNumberQualifier2 = "6h",
			DFIIdentificationNumber2 = "QI0",
			AccountNumber3 = "m",
			AccountNumberQualifier3 = "h",
			DFIIDNumberQualifier3 = "AS",
			DFIIdentificationNumber3 = "vXh",
			Date = "9h2bxceu",
		};

		var actual = Map.MapObject<RIC_FinancialReturn>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rEH", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.PaymentMethodCode = paymentMethodCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.IndustryCode = industryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.CreditDebitFlagCode = "q";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "c", true)]
	[InlineData("A", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pd", "FJF", true)]
	[InlineData("Pd", "", false)]
	[InlineData("", "FJF", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "4", true)]
	[InlineData("y", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAccountNumberQualifier2(string accountNumberQualifier2, string accountNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.AccountNumberQualifier2 = accountNumberQualifier2;
		subject.AccountNumber2 = accountNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6h", "QI0", true)]
	[InlineData("6h", "", false)]
	[InlineData("", "QI0", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier2(string dFIIDNumberQualifier2, string dFIIdentificationNumber2, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.DFIIDNumberQualifier2 = dFIIDNumberQualifier2;
		subject.DFIIdentificationNumber2 = dFIIdentificationNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "m", true)]
	[InlineData("h", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBAccountNumberQualifier3(string accountNumberQualifier3, string accountNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.AccountNumberQualifier3 = accountNumberQualifier3;
		subject.AccountNumber3 = accountNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier3) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber3))
		{
			subject.DFIIDNumberQualifier3 = "AS";
			subject.DFIIdentificationNumber3 = "vXh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AS", "vXh", true)]
	[InlineData("AS", "", false)]
	[InlineData("", "vXh", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier3(string dFIIDNumberQualifier3, string dFIIdentificationNumber3, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.PaymentMethodCode = "rEH";
		subject.CodeListQualifierCode = "U";
		subject.IndustryCode = "4";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "q";
		subject.DFIIDNumberQualifier3 = dFIIDNumberQualifier3;
		subject.DFIIdentificationNumber3 = dFIIdentificationNumber3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Pd";
			subject.DFIIdentificationNumber = "FJF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier2) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber2))
		{
			subject.DFIIDNumberQualifier2 = "6h";
			subject.DFIIdentificationNumber2 = "QI0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
