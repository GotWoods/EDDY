using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*LVSYqu*x*XJs*Ju1HmV*42Sd*G*BXaF65";

		var expected = new BAX_BeginningSegmentForAdvanceConsist()
		{
			StandardPointLocationCode = "LVSYqu",
			TypeOfConsistCode = "x",
			DateTimeQualifier = "XJs",
			Date = "Ju1HmV",
			Time = "42Sd",
			InterchangeTrainIdentification = "G",
			StandardPointLocationCode2 = "BXaF65",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LVSYqu", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.TypeOfConsistCode = "x";
		subject.DateTimeQualifier = "XJs";
		subject.Date = "Ju1HmV";
		subject.Time = "42Sd";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "LVSYqu";
		subject.DateTimeQualifier = "XJs";
		subject.Date = "Ju1HmV";
		subject.Time = "42Sd";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XJs", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "LVSYqu";
		subject.TypeOfConsistCode = "x";
		subject.Date = "Ju1HmV";
		subject.Time = "42Sd";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ju1HmV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "LVSYqu";
		subject.TypeOfConsistCode = "x";
		subject.DateTimeQualifier = "XJs";
		subject.Time = "42Sd";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("42Sd", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "LVSYqu";
		subject.TypeOfConsistCode = "x";
		subject.DateTimeQualifier = "XJs";
		subject.Date = "Ju1HmV";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
