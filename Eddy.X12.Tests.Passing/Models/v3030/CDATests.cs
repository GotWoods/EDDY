using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*S*5*7*5*7*5t*V*2*3*mc*W*8*5*D*m*v";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "S",
			MonetaryAmount = 5,
			MonetaryAmount2 = 7,
			MonetaryAmount3 = 5,
			MonetaryAmount4 = 7,
			TypeOfAccount = "5t",
			TypeOfCreditAccountCode = "V",
			Quantity = 2,
			Quantity2 = 3,
			DateTimePeriodFormatQualifier = "mc",
			DateTimePeriod = "W",
			DateTimePeriod2 = "8",
			DateTimePeriod3 = "5",
			DateTimePeriod4 = "D",
			DateTimePeriod5 = "m",
			Description = "v",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "mc", true)]
	[InlineData("W", "", false)]
	[InlineData("", "mc", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "mc", true)]
	[InlineData("8", "", false)]
	[InlineData("", "mc", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "mc", true)]
	[InlineData("5", "", false)]
	[InlineData("", "mc", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "mc", true)]
	[InlineData("D", "", false)]
	[InlineData("", "mc", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "mc", true)]
	[InlineData("m", "", false)]
	[InlineData("", "mc", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		subject.AccountNumber = "S";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
