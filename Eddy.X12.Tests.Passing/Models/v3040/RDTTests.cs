using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDT*T*a*nIK*l9uAzd*yenK*nR";

		var expected = new RDT_RevisionDateTime()
		{
			RevisionLevelCode = "T",
			RevisionValue = "a",
			DateTimeQualifier = "nIK",
			Date = "l9uAzd",
			Time = "yenK",
			TimeCode = "nR",
		};

		var actual = Map.MapObject<RDT_RevisionDateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "a", true)]
	[InlineData("T", "", false)]
	[InlineData("", "a", true)]
	public void Validation_ARequiresBRevisionLevelCode(string revisionLevelCode, string revisionValue, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.RevisionLevelCode = revisionLevelCode;
		subject.RevisionValue = revisionValue;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "nIK";
			subject.Date = "l9uAzd";
			subject.Time = "yenK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("nIK", "l9uAzd", "yenK", true)]
	[InlineData("nIK", "", "", false)]
	[InlineData("", "l9uAzd", "yenK", true)]
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
	[InlineData("nR", "yenK", true)]
	[InlineData("nR", "", false)]
	[InlineData("", "yenK", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new RDT_RevisionDateTime();
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "nIK";
			subject.Date = "l9uAzd";
			subject.Time = "yenK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
