using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*F*6*9*2*3*JC*1*7*6*HK*m*U*r*U*C*S*E*u*i*0*7U8*n4";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "F",
			MonetaryAmount = 6,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 3,
			TypeOfAccountCode = "JC",
			TypeOfCreditAccountCode = "1",
			Quantity = 7,
			Quantity2 = 6,
			DateTimePeriodFormatQualifier = "HK",
			DateTimePeriod = "m",
			DateTimePeriod2 = "U",
			DateTimePeriod3 = "r",
			DateTimePeriod4 = "U",
			DateTimePeriod5 = "C",
			Description = "S",
			ReferenceIdentification = "E",
			LoanTypeCode = "u",
			FrequencyCode = "i",
			ReferenceIdentification2 = "0",
			MaintenanceTypeCode = "7U8",
			StatusCode = "n4",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("HK", "m", "U", "r", "U", "C", true)]
	[InlineData("HK", "", "", "", "", "", false)]
	[InlineData("", "m", "U", "r", "U", "C", true)]
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
			subject.DateTimePeriodFormatQualifier = "HK";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "HK";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "HK";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "HK";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "HK";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "HK", true)]
	[InlineData("m", "", false)]
	[InlineData("", "HK", true)]
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
			subject.DateTimePeriod2 = "U";
			subject.DateTimePeriod3 = "r";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "HK", true)]
	[InlineData("U", "", false)]
	[InlineData("", "HK", true)]
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
			subject.DateTimePeriod = "m";
			subject.DateTimePeriod3 = "r";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "HK", true)]
	[InlineData("r", "", false)]
	[InlineData("", "HK", true)]
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
			subject.DateTimePeriod = "m";
			subject.DateTimePeriod2 = "U";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "HK", true)]
	[InlineData("U", "", false)]
	[InlineData("", "HK", true)]
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
			subject.DateTimePeriod = "m";
			subject.DateTimePeriod2 = "U";
			subject.DateTimePeriod3 = "r";
			subject.DateTimePeriod5 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "HK", true)]
	[InlineData("C", "", false)]
	[InlineData("", "HK", true)]
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
			subject.DateTimePeriod = "m";
			subject.DateTimePeriod2 = "U";
			subject.DateTimePeriod3 = "r";
			subject.DateTimePeriod4 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("i", 3, true)]
	[InlineData("i", 0, false)]
	[InlineData("", 3, true)]
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
			subject.DateTimePeriodFormatQualifier = "HK";
			subject.DateTimePeriod = "m";
			subject.DateTimePeriod2 = "U";
			subject.DateTimePeriod3 = "r";
			subject.DateTimePeriod4 = "U";
			subject.DateTimePeriod5 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
