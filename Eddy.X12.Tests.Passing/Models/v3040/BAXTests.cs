using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*44tHZz*Q*7bH*ulLdf1*xWA5*k*JPI8j6";

		var expected = new BAX_BeginningSegmentForAdvanceConsist()
		{
			StandardPointLocationCode = "44tHZz",
			TypeOfConsistCode = "Q",
			DateTimeQualifier = "7bH",
			Date = "ulLdf1",
			Time = "xWA5",
			InterchangeTrainIdentification = "k",
			StandardPointLocationCode2 = "JPI8j6",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("44tHZz", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.TypeOfConsistCode = "Q";
		subject.DateTimeQualifier = "7bH";
		subject.Date = "ulLdf1";
		subject.Time = "xWA5";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "44tHZz";
		subject.DateTimeQualifier = "7bH";
		subject.Date = "ulLdf1";
		subject.Time = "xWA5";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7bH", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "44tHZz";
		subject.TypeOfConsistCode = "Q";
		subject.Date = "ulLdf1";
		subject.Time = "xWA5";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ulLdf1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "44tHZz";
		subject.TypeOfConsistCode = "Q";
		subject.DateTimeQualifier = "7bH";
		subject.Time = "xWA5";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xWA5", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "44tHZz";
		subject.TypeOfConsistCode = "Q";
		subject.DateTimeQualifier = "7bH";
		subject.Date = "ulLdf1";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
