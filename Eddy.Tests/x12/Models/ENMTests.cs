using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ENMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENM*kHK*tx*s**y*Kv*2*i";

		var expected = new ENM_SchoolEnrollmentData()
		{
			StatusReasonCode = "kHK",
			LevelOfIndividualTestOrCourseCode = "tx",
			SessionCode = "s",
			CompositeRaceOrEthnicityInformation = null,
			GenderCode = "y",
			DateTimePeriodFormatQualifier = "Kv",
			DateTimePeriod = "2",
			YesNoConditionOrResponseCode = "i",
		};

		var actual = Map.MapObject<ENM_SchoolEnrollmentData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kHK", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new ENM_SchoolEnrollmentData();
		subject.StatusReasonCode = statusReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Kv", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("Kv", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ENM_SchoolEnrollmentData();
		subject.StatusReasonCode = "kHK";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
