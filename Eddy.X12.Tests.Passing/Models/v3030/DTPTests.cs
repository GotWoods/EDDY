using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DTPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DTP*iFT*jN*w";

		var expected = new DTP_DateOrTimeOrPeriod()
		{
			DateTimeQualifier = "iFT",
			DateTimePeriodFormatQualifier = "jN",
			DateTimePeriod = "w",
		};

		var actual = Map.MapObject<DTP_DateOrTimeOrPeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iFT", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "jN";
		subject.DateTimePeriod = "w";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jN", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		//Required fields
		subject.DateTimeQualifier = "iFT";
		subject.DateTimePeriod = "w";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DTP_DateOrTimeOrPeriod();
		//Required fields
		subject.DateTimeQualifier = "iFT";
		subject.DateTimePeriodFormatQualifier = "jN";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
