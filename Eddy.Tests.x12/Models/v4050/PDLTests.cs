using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PDLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDL*uut*X*6*1*g*H*QT*Mc5*t*O*H6*t";

		var expected = new PDL_PaymentDetails()
		{
			PaymentMethodCode = "uut",
			AmountQualifierCode = "X",
			MonetaryAmount = 6,
			PercentageAsDecimal = 1,
			CreditDebitFlagCode = "g",
			FrequencyCode = "H",
			DFIIDNumberQualifier = "QT",
			DFIIdentificationNumber = "Mc5",
			AccountNumberQualifier = "t",
			AccountNumber = "O",
			DateTimePeriodFormatQualifier = "H6",
			DateTimePeriod = "t",
		};

		var actual = Map.MapObject<PDL_PaymentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uut", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "X";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "QT";
			subject.DFIIdentificationNumber = "Mc5";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "t";
			subject.AccountNumber = "O";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "H6";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 6, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "uut";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "QT";
			subject.DFIIdentificationNumber = "Mc5";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "t";
			subject.AccountNumber = "O";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "H6";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 1, false)]
	[InlineData(6, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "uut";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "X";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "QT";
			subject.DFIIdentificationNumber = "Mc5";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "t";
			subject.AccountNumber = "O";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "H6";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QT", "Mc5", true)]
	[InlineData("QT", "", false)]
	[InlineData("", "Mc5", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "uut";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "X";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "t";
			subject.AccountNumber = "O";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "H6";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "O", true)]
	[InlineData("t", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "uut";
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "X";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "QT";
			subject.DFIIdentificationNumber = "Mc5";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "H6";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H6", "t", true)]
	[InlineData("H6", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "uut";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "X";
			subject.MonetaryAmount = 6;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "QT";
			subject.DFIIdentificationNumber = "Mc5";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "t";
			subject.AccountNumber = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
