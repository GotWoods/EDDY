using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDT*e*K*8Dm*gUH5twOJ*bb6t*Hv";

		var expected = new RDT_RevisionDateTime()
		{
			RevisionLevelCode = "e",
			RevisionValue = "K",
			DateTimeQualifier = "8Dm",
			Date = "gUH5twOJ",
			Time = "bb6t",
			TimeCode = "Hv",
		};

		var actual = Map.MapObject<RDT_RevisionDateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "K", true)]
	[InlineData("e", "", false)]
	public void Validation_ARequiresBRevisionLevelCode(string revisionLevelCode, string revisionValue, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.RevisionLevelCode = revisionLevelCode;
		subject.RevisionValue = revisionValue;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", "", true)]
	[InlineData("8Dm", "gUH5twOJ", "", true)]
	[InlineData("", "gUH5twOJ", "", true)]
	[InlineData("8Dm", "", "", true)]
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
	[InlineData("", "bb6t", true)]
	[InlineData("Hv", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
