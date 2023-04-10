using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSU*K*j*TA*U*tc*H*X*H*1*";

		var expected = new CSU_SupplementalCourseData()
		{
			Name = "K",
			ReferenceIdentification = "j",
			DateTimePeriodFormatQualifier = "TA",
			DateTimePeriod = "U",
			DateTimePeriodFormatQualifier2 = "tc",
			DateTimePeriod2 = "H",
			InstructionalSettingCode = "X",
			AcademicCreditTypeCode = "H",
			Quantity = 1,
			CompositeUnitOfMeasure = "",
		};

		var actual = Map.MapObject<CSU_SupplementalCourseData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("TA", "U", true)]
	[InlineData("", "U", false)]
	[InlineData("TA", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("tc", "H", true)]
	[InlineData("", "H", false)]
	[InlineData("tc", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "", true)]
	[InlineData(0, "", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, C001_CompositeUnitOfMeasure compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
