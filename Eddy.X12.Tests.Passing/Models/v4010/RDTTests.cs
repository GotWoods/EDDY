using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDT*P*L*veN*FLJblYiU*aowf*it";

		var expected = new RDT_RevisionDateTime()
		{
			RevisionLevelCode = "P",
			RevisionValue = "L",
			DateTimeQualifier = "veN",
			Date = "FLJblYiU",
			Time = "aowf",
			TimeCode = "it",
		};

		var actual = Map.MapObject<RDT_RevisionDateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "L", true)]
	[InlineData("P", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBRevisionLevelCode(string revisionLevelCode, string revisionValue, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.RevisionLevelCode = revisionLevelCode;
		subject.RevisionValue = revisionValue;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "veN";
			subject.Date = "FLJblYiU";
			subject.Time = "aowf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("veN", "FLJblYiU", "aowf", true)]
	[InlineData("veN", "", "", false)]
	[InlineData("", "FLJblYiU", "aowf", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("it", "aowf", true)]
	[InlineData("it", "", false)]
	[InlineData("", "aowf", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "veN";
			subject.Date = "FLJblYiU";
			subject.Time = "aowf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
