using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ENRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENR*Cz9*s5*sn*G*6*2*4*2*V*C*y*rL*S*R*7G*C";

		var expected = new ENR_SchoolEnrollmentInformation()
		{
			StatusReasonCode = "Cz9",
			LevelOfStudentOrTestCode = "s5",
			DateTimePeriodFormatQualifier = "sn",
			DateTimePeriod = "G",
			MajorCourseOfStudy = "6",
			RangeMinimum = 2,
			RangeMaximum = 4,
			AcademicGradePointAverage = 2,
			YesNoConditionOrResponseCode = "V",
			YesNoConditionOrResponseCode2 = "C",
			YesNoConditionOrResponseCode3 = "y",
			DateTimePeriodFormatQualifier2 = "rL",
			DateTimePeriod2 = "S",
			YesNoConditionOrResponseCode4 = "R",
			DateTimePeriodFormatQualifier3 = "7G",
			DateTimePeriod3 = "C",
		};

		var actual = Map.MapObject<ENR_SchoolEnrollmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cz9", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.LevelOfStudentOrTestCode = "s5";
		//Test Parameters
		subject.StatusReasonCode = statusReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sn";
			subject.DateTimePeriod = "G";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 4;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "rL";
			subject.DateTimePeriod2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "7G";
			subject.DateTimePeriod3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s5", true)]
	public void Validation_RequiredLevelOfStudentOrTestCode(string levelOfStudentOrTestCode, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "Cz9";
		//Test Parameters
		subject.LevelOfStudentOrTestCode = levelOfStudentOrTestCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sn";
			subject.DateTimePeriod = "G";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 4;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "rL";
			subject.DateTimePeriod2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "7G";
			subject.DateTimePeriod3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sn", "G", true)]
	[InlineData("sn", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "Cz9";
		subject.LevelOfStudentOrTestCode = "s5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 4;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "rL";
			subject.DateTimePeriod2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "7G";
			subject.DateTimePeriod3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 4, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 4, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "Cz9";
		subject.LevelOfStudentOrTestCode = "s5";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sn";
			subject.DateTimePeriod = "G";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "rL";
			subject.DateTimePeriod2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "7G";
			subject.DateTimePeriod3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rL", "S", true)]
	[InlineData("rL", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "Cz9";
		subject.LevelOfStudentOrTestCode = "s5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sn";
			subject.DateTimePeriod = "G";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 4;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "7G";
			subject.DateTimePeriod3 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7G", "C", true)]
	[InlineData("7G", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "Cz9";
		subject.LevelOfStudentOrTestCode = "s5";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sn";
			subject.DateTimePeriod = "G";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 2;
			subject.RangeMaximum = 4;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "rL";
			subject.DateTimePeriod2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
