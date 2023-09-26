using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSU*1*w*kY*K*IH*X*P*q*9*";

		var expected = new CSU_SupplementalCourseData()
		{
			Name = "1",
			ReferenceIdentification = "w",
			DateTimePeriodFormatQualifier = "kY",
			DateTimePeriod = "K",
			DateTimePeriodFormatQualifier2 = "IH",
			DateTimePeriod2 = "X",
			InstructionalSettingCode = "P",
			AcademicCreditTypeCode = "q",
			Quantity = 9,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<CSU_SupplementalCourseData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kY", "K", true)]
	[InlineData("kY", "", false)]
	[InlineData("", "K", false)]
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
			subject.DateTimePeriodFormatQualifier2 = "IH";
			subject.DateTimePeriod2 = "X";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 9;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IH", "X", true)]
	[InlineData("IH", "", false)]
	[InlineData("", "X", false)]
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
			subject.DateTimePeriodFormatQualifier = "kY";
			subject.DateTimePeriod = "K";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 9;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "A", true)]
	[InlineData(9, "", false)]
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
			subject.DateTimePeriodFormatQualifier = "kY";
			subject.DateTimePeriod = "K";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "IH";
			subject.DateTimePeriod2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
