using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SST*qFF*Rg*u*FIs*FS*b*VBu*a1*t";

		var expected = new SST_StudentAcademicStatus()
		{
			StatusReasonCode = "qFF",
			DateTimePeriodFormatQualifier = "Rg",
			DateTimePeriod = "u",
			StatusReasonCode2 = "FIs",
			DateTimePeriodFormatQualifier2 = "FS",
			DateTimePeriod2 = "b",
			StatusReasonCode3 = "VBu",
			LevelOfIndividualTestOrCourseCode = "a1",
			YesNoConditionOrResponseCode = "t",
		};

		var actual = Map.MapObject<SST_StudentAcademicStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Rg", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("Rg", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SST_StudentAcademicStatus();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("FS", "b", true)]
	[InlineData("", "b", false)]
	[InlineData("FS", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SST_StudentAcademicStatus();
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
