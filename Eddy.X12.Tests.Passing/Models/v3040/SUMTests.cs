using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SUMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUM*F*v*U*9*8*2*6*9*5*b*6*6*in*U*3*1*8";

		var expected = new SUM_AcademicSummary()
		{
			AcademicCreditTypeCode = "F",
			AcademicGradeOrCourseLevelCode = "v",
			YesNoConditionOrResponseCode = "U",
			Quantity = 9,
			Quantity2 = 8,
			Quantity3 = 2,
			RangeMinimum = 6,
			RangeMaximum = 9,
			AcademicGradePointAverage = 5,
			YesNoConditionOrResponseCode2 = "b",
			ClassRank = 6,
			Quantity4 = 6,
			DateTimePeriodFormatQualifier = "in",
			DateTimePeriod = "U",
			Quantity5 = 3,
			Quantity6 = 1,
			Quantity7 = 8,
		};

		var actual = Map.MapObject<SUM_AcademicSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "F", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "F", true)]
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
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 9;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "in";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "F", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "F", true)]
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
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 9;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "in";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "F", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "F", true)]
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
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 9;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "in";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 9, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 9, false)]
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
			subject.DateTimePeriodFormatQualifier = "in";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("in", "U", true)]
	[InlineData("in", "", false)]
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
			subject.RangeMinimum = 6;
			subject.RangeMaximum = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
