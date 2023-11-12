using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ENMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENM*dgH*TP*4**6*Wr*u*v";

		var expected = new ENM_SchoolEnrollmentData()
		{
			StatusReasonCode = "dgH",
			LevelOfIndividualTestOrCourseCode = "TP",
			SessionCode = "4",
			CompositeRaceOrEthnicityInformation = null,
			GenderCode = "6",
			DateTimePeriodFormatQualifier = "Wr",
			DateTimePeriod = "u",
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<ENM_SchoolEnrollmentData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dgH", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new ENM_SchoolEnrollmentData();
		//Required fields
		//Test Parameters
		subject.StatusReasonCode = statusReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Wr";
			subject.DateTimePeriod = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Wr", "u", true)]
	[InlineData("Wr", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ENM_SchoolEnrollmentData();
		//Required fields
		subject.StatusReasonCode = "dgH";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
