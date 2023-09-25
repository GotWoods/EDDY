using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSU*r*U*Hn*8*CP*e*p*f*5*";

		var expected = new CSU_SupplementalCourseData()
		{
			Name = "r",
			ReferenceIdentification = "U",
			DateTimePeriodFormatQualifier = "Hn",
			DateTimePeriod = "8",
			DateTimePeriodFormatQualifier2 = "CP",
			DateTimePeriod2 = "e",
			InstructionalSettingCode = "p",
			AcademicCreditTypeCode = "f",
			Quantity = 5,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<CSU_SupplementalCourseData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hn", "8", true)]
	[InlineData("Hn", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "CP";
			subject.DateTimePeriod2 = "e";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CP", "e", true)]
	[InlineData("CP", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Hn";
			subject.DateTimePeriod = "8";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CSU_SupplementalCourseData();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Hn";
			subject.DateTimePeriod = "8";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "CP";
			subject.DateTimePeriod2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
