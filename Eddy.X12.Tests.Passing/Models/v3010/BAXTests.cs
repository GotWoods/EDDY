using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*CKPfcc*l*uZr*rBEKPf*Dlul*u*YvtvA7";

		var expected = new BAX_BeginningSegmentForAdvanceConsist()
		{
			StandardPointLocationCode = "CKPfcc",
			TypeOfConsistCode = "l",
			DateTimeQualifier = "uZr",
			Date = "rBEKPf",
			Time = "Dlul",
			InterchangeTrainIdentification = "u",
			StandardPointLocationCode2 = "YvtvA7",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CKPfcc", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.TypeOfConsistCode = "l";
		subject.DateTimeQualifier = "uZr";
		subject.Date = "rBEKPf";
		subject.Time = "Dlul";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "CKPfcc";
		subject.DateTimeQualifier = "uZr";
		subject.Date = "rBEKPf";
		subject.Time = "Dlul";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uZr", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "CKPfcc";
		subject.TypeOfConsistCode = "l";
		subject.Date = "rBEKPf";
		subject.Time = "Dlul";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rBEKPf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "CKPfcc";
		subject.TypeOfConsistCode = "l";
		subject.DateTimeQualifier = "uZr";
		subject.Time = "Dlul";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dlul", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "CKPfcc";
		subject.TypeOfConsistCode = "l";
		subject.DateTimeQualifier = "uZr";
		subject.Date = "rBEKPf";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
