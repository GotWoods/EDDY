using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*tLxCiP*t*pii*2De0ow*OR2h*f*SLa3LL";

		var expected = new BAX_BeginningSegmentForAdvanceConsist()
		{
			StandardPointLocationCode = "tLxCiP",
			TypeOfConsistCode = "t",
			DateTimeQualifier = "pii",
			Date = "2De0ow",
			Time = "OR2h",
			InterchangeTrainIdentification = "f",
			StandardPointLocationCode2 = "SLa3LL",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tLxCiP", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.TypeOfConsistCode = "t";
		subject.DateTimeQualifier = "pii";
		subject.Date = "2De0ow";
		subject.Time = "OR2h";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "tLxCiP";
		subject.DateTimeQualifier = "pii";
		subject.Date = "2De0ow";
		subject.Time = "OR2h";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pii", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "tLxCiP";
		subject.TypeOfConsistCode = "t";
		subject.Date = "2De0ow";
		subject.Time = "OR2h";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2De0ow", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "tLxCiP";
		subject.TypeOfConsistCode = "t";
		subject.DateTimeQualifier = "pii";
		subject.Time = "OR2h";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OR2h", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "tLxCiP";
		subject.TypeOfConsistCode = "t";
		subject.DateTimeQualifier = "pii";
		subject.Date = "2De0ow";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
