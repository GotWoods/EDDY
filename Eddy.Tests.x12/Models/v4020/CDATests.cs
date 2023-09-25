using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*2*8*9*2*5*Bh*b*1*2*ME*2*O*Y*v*U*e*T*T*N*R*htr*AU";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "2",
			MonetaryAmount = 8,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 5,
			TypeOfAccountCode = "Bh",
			TypeOfCreditAccountCode = "b",
			Quantity = 1,
			Quantity2 = 2,
			DateTimePeriodFormatQualifier = "ME",
			DateTimePeriod = "2",
			DateTimePeriod2 = "O",
			DateTimePeriod3 = "Y",
			DateTimePeriod4 = "v",
			DateTimePeriod5 = "U",
			Description = "e",
			ReferenceIdentification = "T",
			LoanTypeCode = "T",
			FrequencyCode = "N",
			ReferenceIdentification2 = "R",
			MaintenanceTypeCode = "htr",
			StatusCode = "AU",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("ME", "2", "O", "Y", "v", "U", true)]
	[InlineData("ME", "", "", "", "", "", false)]
	[InlineData("", "2", "O", "Y", "v", "U", true)]
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
			subject.DateTimePeriodFormatQualifier = "ME";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "ME";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "ME";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "ME";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "ME";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "ME", true)]
	[InlineData("2", "", false)]
	[InlineData("", "ME", true)]
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
			subject.DateTimePeriod2 = "O";
			subject.DateTimePeriod3 = "Y";
			subject.DateTimePeriod4 = "v";
			subject.DateTimePeriod5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "ME", true)]
	[InlineData("O", "", false)]
	[InlineData("", "ME", true)]
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
			subject.DateTimePeriod = "2";
			subject.DateTimePeriod3 = "Y";
			subject.DateTimePeriod4 = "v";
			subject.DateTimePeriod5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "ME", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "ME", true)]
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
			subject.DateTimePeriod = "2";
			subject.DateTimePeriod2 = "O";
			subject.DateTimePeriod4 = "v";
			subject.DateTimePeriod5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "ME", true)]
	[InlineData("v", "", false)]
	[InlineData("", "ME", true)]
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
			subject.DateTimePeriod = "2";
			subject.DateTimePeriod2 = "O";
			subject.DateTimePeriod3 = "Y";
			subject.DateTimePeriod5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "ME", true)]
	[InlineData("U", "", false)]
	[InlineData("", "ME", true)]
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
			subject.DateTimePeriod = "2";
			subject.DateTimePeriod2 = "O";
			subject.DateTimePeriod3 = "Y";
			subject.DateTimePeriod4 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 5, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 5, true)]
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
			subject.DateTimePeriodFormatQualifier = "ME";
			subject.DateTimePeriod = "2";
			subject.DateTimePeriod2 = "O";
			subject.DateTimePeriod3 = "Y";
			subject.DateTimePeriod4 = "v";
			subject.DateTimePeriod5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
