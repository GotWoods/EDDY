using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDA*B*2*8*3*1*9D*z*6*3*KL*x*l*V*C*0*0*p";

		var expected = new CDA_ConsumerCreditAccount()
		{
			AccountNumber = "B",
			MonetaryAmount = 2,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 3,
			MonetaryAmount4 = 1,
			TypeOfAccountCode = "9D",
			TypeOfCreditAccountCode = "z",
			Quantity = 6,
			Quantity2 = 3,
			DateTimePeriodFormatQualifier = "KL",
			DateTimePeriod = "x",
			DateTimePeriod2 = "l",
			DateTimePeriod3 = "V",
			DateTimePeriod4 = "C",
			DateTimePeriod5 = "0",
			Description = "0",
			ReferenceNumber = "p",
		};

		var actual = Map.MapObject<CDA_ConsumerCreditAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", "", "", "", true)]
	[InlineData("KL", "x", "l", "V", "C", "0", true)]
	[InlineData("KL", "", "", "", "", "", false)]
	[InlineData("", "x", "l", "V", "C", "0", true)]
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
			subject.DateTimePeriodFormatQualifier = "KL";
		if (dateTimePeriod2 != "")
			subject.DateTimePeriodFormatQualifier = "KL";
		if (dateTimePeriod3 != "")
			subject.DateTimePeriodFormatQualifier = "KL";
		if (dateTimePeriod4 != "")
			subject.DateTimePeriodFormatQualifier = "KL";
		if (dateTimePeriod5 != "")
			subject.DateTimePeriodFormatQualifier = "KL";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "KL", true)]
	[InlineData("x", "", false)]
	[InlineData("", "KL", true)]
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
			subject.DateTimePeriod2 = "l";
			subject.DateTimePeriod3 = "V";
			subject.DateTimePeriod4 = "C";
			subject.DateTimePeriod5 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "KL", true)]
	[InlineData("l", "", false)]
	[InlineData("", "KL", true)]
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
			subject.DateTimePeriod = "x";
			subject.DateTimePeriod3 = "V";
			subject.DateTimePeriod4 = "C";
			subject.DateTimePeriod5 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "KL", true)]
	[InlineData("V", "", false)]
	[InlineData("", "KL", true)]
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
			subject.DateTimePeriod = "x";
			subject.DateTimePeriod2 = "l";
			subject.DateTimePeriod4 = "C";
			subject.DateTimePeriod5 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "KL", true)]
	[InlineData("C", "", false)]
	[InlineData("", "KL", true)]
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
			subject.DateTimePeriod = "x";
			subject.DateTimePeriod2 = "l";
			subject.DateTimePeriod3 = "V";
			subject.DateTimePeriod5 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "KL", true)]
	[InlineData("0", "", false)]
	[InlineData("", "KL", true)]
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
			subject.DateTimePeriod = "x";
			subject.DateTimePeriod2 = "l";
			subject.DateTimePeriod3 = "V";
			subject.DateTimePeriod4 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
