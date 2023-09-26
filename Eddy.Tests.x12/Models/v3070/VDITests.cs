using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class VDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VDI*yu**4*7*8*7*8*QC*E*Dy*3*9*a*yd*9t";

		var expected = new VDI_ValueDescriptionOrInformation()
		{
			CodeCategory = "yu",
			CompositeQualifierIdentifier = null,
			Quantity = 4,
			Percent = 7,
			MonetaryAmount = 8,
			Number = 7,
			Number2 = 8,
			DateTimePeriodFormatQualifier = "QC",
			DateTimePeriod = "E",
			UnitOfTimePeriodOrInterval = "Dy",
			Quantity2 = 3,
			Multiplier = 9,
			RoundingSystemCode = "a",
			LoanPaymentTypeCode = "yd",
			LoanPaymentTypeCode2 = "9t",
		};

		var actual = Map.MapObject<VDI_ValueDescriptionOrInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (compositeQualifierIdentifier != "") 
			subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 7, false)]
	[InlineData(4, 0, true)]
	[InlineData(0, 7, true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, decimal percent, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (percent > 0) 
			subject.Percent = percent;
		//A Requires B
		if (percent > 0 || quantity > 0)
			subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required

		

		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBPercent(decimal percent, string compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (compositeQualifierIdentifier != "") 
			subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "A", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (compositeQualifierIdentifier != "") 
			subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 7, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 7, true)]
	public void Validation_ARequiresBNumber2(int number2, int number, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		if (number > 0) 
			subject.Number = number;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QC", "E", true)]
	[InlineData("QC", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Dy", 3, true)]
	[InlineData("Dy", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, decimal quantity2, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QC";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
