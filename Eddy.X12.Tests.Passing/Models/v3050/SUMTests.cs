using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SUMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUM*U*3*f*2*6*5*4*1*2*O*7*7*jL*U*8*3*3";

		var expected = new SUM_AcademicSummary()
		{
			AcademicCreditTypeCode = "U",
			AcademicGradeOrCourseLevelCode = "3",
			YesNoConditionOrResponseCode = "f",
			Quantity = 2,
			Quantity2 = 6,
			Quantity3 = 5,
			RangeMinimum = 4,
			RangeMaximum = 1,
			AcademicGradePointAverage = 2,
			YesNoConditionOrResponseCode2 = "O",
			ClassRank = 7,
			Quantity4 = 7,
			DateTimePeriodFormatQualifier = "jL",
			DateTimePeriod = "U",
			NumberOfDays = 8,
			Quantity5 = 3,
			Quantity6 = 3,
		};

		var actual = Map.MapObject<SUM_AcademicSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "U", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "U", true)]
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
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "jL";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "U", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "U", true)]
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
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "jL";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "U", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "U", true)]
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
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "jL";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 1, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 1, false)]
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
			subject.DateTimePeriodFormatQualifier = "jL";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jL", "U", true)]
	[InlineData("jL", "", false)]
	[InlineData("", "U", false)]
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
			subject.RangeMinimum = 4;
			subject.RangeMaximum = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
