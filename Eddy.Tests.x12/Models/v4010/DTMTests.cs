using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DTMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DTM*NCl*f9q27ltN*PSp2*DR*7U*f";

		var expected = new DTM_DateTimeReference()
		{
			DateTimeQualifier = "NCl",
			Date = "f9q27ltN",
			Time = "PSp2",
			TimeCode = "DR",
			DateTimePeriodFormatQualifier = "7U",
			DateTimePeriod = "f",
		};

		var actual = Map.MapObject<DTM_DateTimeReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NCl", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "7U";
			subject.DateTimePeriod = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DR", "PSp2", true)]
	[InlineData("DR", "", false)]
	[InlineData("", "PSp2", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = "NCl";
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "7U";
			subject.DateTimePeriod = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7U", "f", true)]
	[InlineData("7U", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = "NCl";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
