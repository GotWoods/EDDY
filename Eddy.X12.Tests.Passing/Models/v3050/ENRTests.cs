using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ENRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENR*dpz*ji*lK*d*o*7*3*7*H*P*P*Yh*D*g*2f*J*uv*P";

		var expected = new ENR_SchoolEnrollmentInformation()
		{
			StatusReasonCode = "dpz",
			LevelOfIndividualOrTestCode = "ji",
			DateTimePeriodFormatQualifier = "lK",
			DateTimePeriod = "d",
			MajorCourseOfStudy = "o",
			RangeMinimum = 7,
			RangeMaximum = 3,
			AcademicGradePointAverage = 7,
			YesNoConditionOrResponseCode = "H",
			YesNoConditionOrResponseCode2 = "P",
			YesNoConditionOrResponseCode3 = "P",
			DateTimePeriodFormatQualifier2 = "Yh",
			DateTimePeriod2 = "D",
			YesNoConditionOrResponseCode4 = "g",
			DateTimePeriodFormatQualifier3 = "2f",
			DateTimePeriod3 = "J",
			DateTimePeriodFormatQualifier4 = "uv",
			DateTimePeriod4 = "P",
		};

		var actual = Map.MapObject<ENR_SchoolEnrollmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dpz", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		//Test Parameters
		subject.StatusReasonCode = statusReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lK";
			subject.DateTimePeriod = "d";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "Yh";
			subject.DateTimePeriod2 = "D";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "2f";
			subject.DateTimePeriod3 = "J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "uv";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lK", "d", true)]
	[InlineData("lK", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "dpz";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "Yh";
			subject.DateTimePeriod2 = "D";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "2f";
			subject.DateTimePeriod3 = "J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "uv";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 3, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 3, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "dpz";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lK";
			subject.DateTimePeriod = "d";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "Yh";
			subject.DateTimePeriod2 = "D";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "2f";
			subject.DateTimePeriod3 = "J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "uv";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Yh", "D", true)]
	[InlineData("Yh", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "dpz";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lK";
			subject.DateTimePeriod = "d";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "2f";
			subject.DateTimePeriod3 = "J";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "uv";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2f", "J", true)]
	[InlineData("2f", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "dpz";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lK";
			subject.DateTimePeriod = "d";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "Yh";
			subject.DateTimePeriod2 = "D";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier4) || !string.IsNullOrEmpty(subject.DateTimePeriod4))
		{
			subject.DateTimePeriodFormatQualifier4 = "uv";
			subject.DateTimePeriod4 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uv", "P", true)]
	[InlineData("uv", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier4(string dateTimePeriodFormatQualifier4, string dateTimePeriod4, bool isValidExpected)
	{
		var subject = new ENR_SchoolEnrollmentInformation();
		//Required fields
		subject.StatusReasonCode = "dpz";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier4 = dateTimePeriodFormatQualifier4;
		subject.DateTimePeriod4 = dateTimePeriod4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lK";
			subject.DateTimePeriod = "d";
		}
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "Yh";
			subject.DateTimePeriod2 = "D";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "2f";
			subject.DateTimePeriod3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
