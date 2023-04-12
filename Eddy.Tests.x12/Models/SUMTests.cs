using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SUMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUM*Z*P*q*9*8*4*9*9*7*9*1*7*pi*b*5*5*8*F";

		var expected = new SUM_AcademicSummary()
		{
			AcademicCreditTypeCode = "Z",
			AcademicGradeOrCourseLevelCode = "P",
			YesNoConditionOrResponseCode = "q",
			Quantity = 9,
			Quantity2 = 8,
			Quantity3 = 4,
			RangeMinimum = 9,
			RangeMaximum = 9,
			AcademicGradePointAverage = 7,
			YesNoConditionOrResponseCode2 = "9",
			ClassRank = 1,
			Quantity4 = 7,
			DateTimePeriodFormatQualifier = "pi",
			DateTimePeriod = "b",
			NumberOfDays = 5,
			Quantity5 = 5,
			Quantity6 = 8,
			AcademicSummarySourceCode = "F",
		};

		var actual = Map.MapObject<SUM_AcademicSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Z", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Z", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Z", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string academicCreditTypeCode, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.AcademicCreditTypeCode = academicCreditTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(9, 9, true)]
	[InlineData(0, 9, false)]
	[InlineData(9, 0, false)]
	public void Validation_AllAreRequiredRangeMinimum(decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("pi", "b", true)]
	[InlineData("", "b", false)]
	[InlineData("pi", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SUM_AcademicSummary();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
