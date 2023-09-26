using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*Q*3*8*4*2*Ou*e*6*9*DV*c*d*s*d*5*S*U*y*V";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "Q",
			MonetaryAmount = 3,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 2,
			TypeOfAccountCode = "Ou",
			TypeOfCreditAccountCode = "e",
			Quantity = 6,
			Quantity2 = 9,
			DateTimePeriodFormatQualifier = "DV",
			DateTimePeriod = "c",
			DateTimePeriod2 = "d",
			DateTimePeriod3 = "s",
			DateTimePeriod4 = "d",
			DateTimePeriod5 = "5",
			Description = "S",
			ReferenceIdentification = "U",
			LoanTypeCode = "y",
			FrequencyCode = "V",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("DV", "c", "d", "s", "d", "5", true)]
	[InlineData("DV", "", "", "", "", "", false)]
	[InlineData("", "c", "d", "s", "d", "5", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, string dateTimePeriod4, string dateTimePeriod5, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriod5 = dateTimePeriod5;
		//A Requires B
		if (dateTimePeriod != "")
			subject.DateTimePeriodFormatQualifier = "DV";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "DV";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "DV";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "DV";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "DV";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "DV", true)]
	[InlineData("c", "", false)]
	[InlineData("", "DV", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod2 = "d";
			subject.DateTimePeriod3 = "s";
			subject.DateTimePeriod4 = "d";
			subject.DateTimePeriod5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "DV", true)]
	[InlineData("d", "", false)]
	[InlineData("", "DV", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "c";
			subject.DateTimePeriod3 = "s";
			subject.DateTimePeriod4 = "d";
			subject.DateTimePeriod5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "DV", true)]
	[InlineData("s", "", false)]
	[InlineData("", "DV", true)]
	public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod3 = dateTimePeriod3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "c";
			subject.DateTimePeriod2 = "d";
			subject.DateTimePeriod4 = "d";
			subject.DateTimePeriod5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "DV", true)]
	[InlineData("d", "", false)]
	[InlineData("", "DV", true)]
	public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod4 = dateTimePeriod4;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriod = "c";
			subject.DateTimePeriod2 = "d";
			subject.DateTimePeriod3 = "s";
			subject.DateTimePeriod5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "DV", true)]
	[InlineData("5", "", false)]
	[InlineData("", "DV", true)]
	public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod5 = dateTimePeriod5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriod = "c";
			subject.DateTimePeriod2 = "d";
			subject.DateTimePeriod3 = "s";
			subject.DateTimePeriod4 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("V", 2, true)]
	[InlineData("V", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBFrequencyCode(string frequencyCode, decimal monetaryAmount4, bool isValidExpected)
	{
		var subject = new CDA_ConsumerCreditAccount();
		//Required fields
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod) || !string.IsNullOrEmpty(subject.DateTimePeriod2) || !string.IsNullOrEmpty(subject.DateTimePeriod3) || !string.IsNullOrEmpty(subject.DateTimePeriod4) || !string.IsNullOrEmpty(subject.DateTimePeriod5))
		{
			subject.DateTimePeriodFormatQualifier = "DV";
			subject.DateTimePeriod = "c";
			subject.DateTimePeriod2 = "d";
			subject.DateTimePeriod3 = "s";
			subject.DateTimePeriod4 = "d";
			subject.DateTimePeriod5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
