using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DEGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEG*WlX*H1*k*f*Xp2";

		var expected = new DEG_DegreeRecord()
		{
			AcademicDegreeCode = "WlX",
			DateTimePeriodFormatQualifier = "H1",
			DateTimePeriod = "k",
			Description = "f",
			StatusReasonCode = "Xp2",
		};

		var actual = Map.MapObject<DEG_DegreeRecord>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WlX", true)]
	public void Validatation_RequiredAcademicDegreeCode(string academicDegreeCode, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		subject.AcademicDegreeCode = academicDegreeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("H1", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("H1", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEG_DegreeRecord();
		subject.AcademicDegreeCode = "WlX";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
