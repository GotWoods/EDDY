using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*R*1*3*6*6*MX*J*4*5*Cz*S*5*s*l*H*f*P*u*A*2*iFv*DC";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "R",
			MonetaryAmount = 1,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 6,
			MonetaryAmount4 = 6,
			TypeOfAccountCode = "MX",
			TypeOfCreditAccountCode = "J",
			Quantity = 4,
			Quantity2 = 5,
			DateTimePeriodFormatQualifier = "Cz",
			DateTimePeriod = "S",
			DateTimePeriod2 = "5",
			DateTimePeriod3 = "s",
			DateTimePeriod4 = "l",
			DateTimePeriod5 = "H",
			Description = "f",
			ReferenceIdentification = "P",
			LoanTypeCode = "u",
			FrequencyCode = "A",
			ReferenceIdentification2 = "2",
			MaintenanceTypeCode = "iFv",
			StatusCode = "DC",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	//TODO: fix this
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("Cz", "S", false)]
	// [InlineData("","S", true)]
	// [InlineData("Cz", "", true)]
	// public void Validation_NEWDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	// {
	// 	var subject = new CDA_ConsumerCreditAccount();
	// 	subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
	// 	subject.DateTimePeriod = dateTimePeriod;
	// 	subject.DateTimePeriod2 = dateTimePeriod2;
	// 	subject.DateTimePeriod3 = dateTimePeriod3;
	// 	subject.DateTimePeriod4 = dateTimePeriod4;
	// 	subject.DateTimePeriod5 = dateTimePeriod5;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	// }

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AA", "Cz", true)]
	[InlineData("S", "", false)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AA", "Cz", true)]
	[InlineData("5", "", false)]
    public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aa", "Cz", true)]
	[InlineData("s", "", false)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aa", "Cz", true)]
	[InlineData("l", "", false)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aa", "Cz", true)]
	[InlineData("H", "", false)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 6, true)]
	[InlineData("A", 0, false)]
	public void Validation_ARequiresBFrequencyCode(string frequencyCode, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount4 > 0)
		subject.MonetaryAmount4 = monetaryAmount4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
