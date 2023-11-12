using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEG*X0G*Vo*D*u*GPS";

		var expected = new DEG_DegreeRecord()
		{
			AcademicDegreeCode = "X0G",
			DateTimePeriodFormatQualifier = "Vo",
			DateTimePeriod = "D",
			FreeFormMessage = "u",
			StatusReasonCode = "GPS",
		};

		var actual = Map.MapObject<DEG_DegreeRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X0G", true)]
	public void Validation_RequiredAcademicDegreeCode(string academicDegreeCode, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		//Required fields
		//Test Parameters
		subject.AcademicDegreeCode = academicDegreeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vo";
			subject.DateTimePeriod = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vo", "D", true)]
	[InlineData("Vo", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		//Required fields
		subject.AcademicDegreeCode = "X0G";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
