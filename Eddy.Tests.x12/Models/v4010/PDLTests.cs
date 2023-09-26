using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PDLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDL*7Fh*j*1*1*M*c*Ex*XKH*r*t*t2*N";

		var expected = new PDL_PaymentDetails()
		{
			PaymentMethodCode = "7Fh",
			AmountQualifierCode = "j",
			MonetaryAmount = 1,
			Percent = 1,
			CreditDebitFlagCode = "M",
			FrequencyCode = "c",
			DFIIDNumberQualifier = "Ex",
			DFIIdentificationNumber = "XKH",
			AccountNumberQualifier = "r",
			AccountNumber = "t",
			DateTimePeriodFormatQualifier = "t2",
			DateTimePeriod = "N",
		};

		var actual = Map.MapObject<PDL_PaymentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7Fh", true)]
	public void Validation_RequiredPaymentMethodCode(string paymentMethodCode, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		//Test Parameters
		subject.PaymentMethodCode = paymentMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "j";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Ex";
			subject.DFIIdentificationNumber = "XKH";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "r";
			subject.AccountNumber = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t2";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("j", 1, true)]
	[InlineData("j", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "7Fh";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Ex";
			subject.DFIIdentificationNumber = "XKH";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "r";
			subject.AccountNumber = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t2";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 1, false)]
	[InlineData(1, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "7Fh";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "j";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Ex";
			subject.DFIIdentificationNumber = "XKH";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "r";
			subject.AccountNumber = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t2";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ex", "XKH", true)]
	[InlineData("Ex", "", false)]
	[InlineData("", "XKH", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "7Fh";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "j";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "r";
			subject.AccountNumber = "t";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t2";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "t", true)]
	[InlineData("r", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "7Fh";
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "j";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Ex";
			subject.DFIIdentificationNumber = "XKH";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t2";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t2", "N", true)]
	[InlineData("t2", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PDL_PaymentDetails();
		//Required fields
		subject.PaymentMethodCode = "7Fh";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "j";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "Ex";
			subject.DFIIdentificationNumber = "XKH";
		}
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "r";
			subject.AccountNumber = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
