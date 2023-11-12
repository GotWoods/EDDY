using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030.Composites;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class VDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VDI*yk**4*5*6*2*6*oc*1*Cw*9*7*Z*pY*oo";

		var expected = new VDI_ValueDescriptionOrInformation()
		{
			CodeCategory = "yk",
			CompositeQualifierIdentifier = null,
			Quantity = 4,
			PercentageAsDecimal = 5,
			MonetaryAmount = 6,
			Number = 2,
			Number2 = 6,
			DateTimePeriodFormatQualifier = "oc",
			DateTimePeriod = "1",
			UnitOfTimePeriodOrIntervalCode = "Cw",
			Quantity2 = 9,
			Multiplier = 7,
			RoundingSystemCode = "Z",
			LoanPaymentTypeCode = "pY",
			LoanPaymentTypeCode2 = "oo",
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
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 5, false)]
	[InlineData(4, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
        //A Requires B
        if (percentageAsDecimal > 0 || quantity > 0)
            subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBPercentageAsDecimal(decimal percentageAsDecimal, string compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		if (compositeQualifierIdentifier != "") 
			subject.CompositeQualifierIdentifier = new C046_CompositeQualifierIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "A", true)]
	[InlineData(6, "", false)]
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
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 2, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 2, true)]
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
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oc", "1", true)]
	[InlineData("oc", "", false)]
	[InlineData("", "1", false)]
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
	[InlineData("Cw", 9, true)]
	[InlineData("Cw", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, decimal quantity2, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "oc";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
