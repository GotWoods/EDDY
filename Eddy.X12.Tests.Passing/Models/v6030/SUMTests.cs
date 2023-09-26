using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SUMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUM*k*p*g*9*2*9*7*3*7*z*3*6*tb*G*1*8*9*o";

		var expected = new SUM_AcademicSummary()
		{
			AcademicCreditTypeCode = "k",
			AcademicGradeOrCourseLevelCode = "p",
			YesNoConditionOrResponseCode = "g",
			Quantity = 9,
			Quantity2 = 2,
			Quantity3 = 9,
			RangeMinimum = 7,
			RangeMaximum = 3,
			AcademicGradePointAverage = 7,
			YesNoConditionOrResponseCode2 = "z",
			ClassRank = 3,
			Quantity4 = 6,
			DateTimePeriodFormatQualifier = "tb",
			DateTimePeriod = "G",
			NumberOfDays = 1,
			Quantity5 = 8,
			Quantity6 = 9,
			AcademicSummarySourceCode = "o",
		};

		var actual = Map.MapObject<SUM_AcademicSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "k", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "k", true)]
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
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "tb";
			subject.DateTimePeriod = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "k", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "k", true)]
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
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "tb";
			subject.DateTimePeriod = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "k", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "k", true)]
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
			subject.RangeMaximum = 3;
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "tb";
			subject.DateTimePeriod = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(7, 3, true)]
	[InlineData(7, 0, false)]
	[InlineData(0, 3, false)]
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
			subject.DateTimePeriodFormatQualifier = "tb";
			subject.DateTimePeriod = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tb", "G", true)]
	[InlineData("tb", "", false)]
	[InlineData("", "G", false)]
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
			subject.RangeMaximum = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
