using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEG*j7l*hl*r*F*y6h";

		var expected = new DEG_DegreeRecord()
		{
			AcademicDegreeCode = "j7l",
			DateTimePeriodFormatQualifier = "hl",
			DateTimePeriod = "r",
			Description = "F",
			StatusReasonCode = "y6h",
		};

		var actual = Map.MapObject<DEG_DegreeRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j7l", true)]
	public void Validation_RequiredAcademicDegreeCode(string academicDegreeCode, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		//Required fields
		//Test Parameters
		subject.AcademicDegreeCode = academicDegreeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "hl";
			subject.DateTimePeriod = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hl", "r", true)]
	[InlineData("hl", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		//Required fields
		subject.AcademicDegreeCode = "j7l";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
