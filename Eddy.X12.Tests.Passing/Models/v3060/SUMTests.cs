using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SUMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUM*t*p*S*5*3*5*7*5*6*a*6*2*r0*2*8*9*7*Z";

		var expected = new SUM_AcademicSummary()
		{
			AcademicCreditTypeCode = "t",
			AcademicGradeOrCourseLevelCode = "p",
			YesNoConditionOrResponseCode = "S",
			Quantity = 5,
			Quantity2 = 3,
			Quantity3 = 5,
			RangeMinimum = 7,
			RangeMaximum = 5,
			AcademicGradePointAverage = 6,
			YesNoConditionOrResponseCode2 = "a",
			ClassRank = 6,
			Quantity4 = 2,
			DateTimePeriodFormatQualifier = "r0",
			DateTimePeriod = "2",
			NumberOfDays = 8,
			Quantity5 = 9,
			Quantity6 = 7,
			AcademicSummarySource = "Z",
		};

		var actual = Map.MapObject<SUM_AcademicSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "t", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "t", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 5;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r0";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "t", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "t", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 5;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r0";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "t", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "t", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		//Required fields
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 5;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r0";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 5, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 5, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		//Required fields
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r0";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r0", "2", true)]
	[InlineData("r0", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(subject.RangeMinimum > 0 || subject.RangeMinimum > 0 || subject.RangeMaximum > 0)
		{
			subject.RangeMinimum = 7;
			subject.RangeMaximum = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
