using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DB*fr*U*3*8*2*L";

		var expected = new DB_DisbursementInformation()
		{
			DateTimePeriodFormatQualifier = "fr",
			DateTimePeriod = "U",
			MonetaryAmount = 3,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 2,
			YesNoConditionOrResponseCode = "L",
		};

		var actual = Map.MapObject<DB_DisbursementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fr", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		subject.DateTimePeriod = "U";
		subject.MonetaryAmount = 3;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		subject.DateTimePeriodFormatQualifier = "fr";
		subject.MonetaryAmount = 3;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		subject.DateTimePeriodFormatQualifier = "fr";
		subject.DateTimePeriod = "U";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
