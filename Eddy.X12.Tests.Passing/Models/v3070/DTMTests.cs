using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DTMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DTM*RI3*dIL8Tq*c3zo*Dw*41*BZ*t";

		var expected = new DTM_DateTimeReference()
		{
			DateTimeQualifier = "RI3",
			Date = "dIL8Tq",
			Time = "c3zo",
			TimeCode = "Dw",
			Century = 41,
			DateTimePeriodFormatQualifier = "BZ",
			DateTimePeriod = "t",
		};

		var actual = Map.MapObject<DTM_DateTimeReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RI3", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "BZ";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dw", "c3zo", true)]
	[InlineData("Dw", "", false)]
	[InlineData("", "c3zo", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = "RI3";
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "BZ";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BZ", "t", true)]
	[InlineData("BZ", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = "RI3";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
