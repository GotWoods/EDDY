using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DTP*tib*WL*A";

		var expected = new DTP_DateOrTimeOrPeriod()
		{
			DateTimeQualifier = "tib",
			DateTimePeriodFormatQualifier = "WL",
			DateTimePeriod = "A",
		};

		var actual = Map.MapObject<DTP_DateOrTimeOrPeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tib", true)]
	public void Validatation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		subject.DateTimePeriodFormatQualifier = "WL";
		subject.DateTimePeriod = "A";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WL", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		subject.DateTimeQualifier = "tib";
		subject.DateTimePeriod = "A";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		subject.DateTimeQualifier = "tib";
		subject.DateTimePeriodFormatQualifier = "WL";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
