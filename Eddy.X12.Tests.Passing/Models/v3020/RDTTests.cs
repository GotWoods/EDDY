using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDT*R*h*oSs*Q22LHL*UrrC*TN";

		var expected = new RDT_RevisionDateTime()
		{
			RevisionLevelCode = "R",
			RevisionValue = "h",
			DateTimeQualifier = "oSs",
			Date = "Q22LHL",
			Time = "UrrC",
			TimeCode = "TN",
		};

		var actual = Map.MapObject<RDT_RevisionDateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "h", true)]
	[InlineData("R", "", false)]
	[InlineData("", "h", true)]
	public void Validation_ARequiresBRevisionLevelCode(string revisionLevelCode, string revisionValue, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.RevisionLevelCode = revisionLevelCode;
		subject.RevisionValue = revisionValue;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "oSs";
			subject.Date = "Q22LHL";
			subject.Time = "UrrC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("oSs", "Q22LHL", "UrrC", true)]
	[InlineData("oSs", "", "", false)]
	[InlineData("", "Q22LHL", "UrrC", true)]
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
	[InlineData("TN", "UrrC", true)]
	[InlineData("TN", "", false)]
	[InlineData("", "UrrC", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "oSs";
			subject.Date = "Q22LHL";
			subject.Time = "UrrC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
