using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class VDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VDI*Ys**1*3*4*6*6*GO*4*Y8*2*4*o*Bn*JJ";

		var expected = new VDI_ValueDescriptionOrInformation()
		{
			CodeCategory = "Ys",
			CompositeQualifierIdentifier = null,
			Quantity = 1,
			PercentageAsDecimal = 3,
			MonetaryAmount = 4,
			Number = 6,
			Number2 = 6,
			DateTimePeriodFormatQualifier = "GO",
			DateTimePeriod = "4",
			UnitOfTimePeriodOrInterval = "Y8",
			Quantity2 = 2,
			Multiplier = 4,
			RoundingSystemCode = "o",
			LoanPaymentTypeCode = "Bn",
			LoanPaymentTypeCode2 = "JJ",
		};

		var actual = Map.MapObject<VDI_ValueDescriptionOrInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "A", true)]
	[InlineData(1, "", false)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 3, false)]
	[InlineData(1, 0, true)]
	[InlineData(0, 3, true)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "A", true)]
	[InlineData(3, "", false)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 6, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 6, true)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GO", "4", true)]
	[InlineData("GO", "", false)]
	[InlineData("", "4", false)]
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
	[InlineData("Y8", 2, true)]
	[InlineData("Y8", 0, false)]
	[InlineData("", 2, true)]
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
			subject.DateTimePeriodFormatQualifier = "GO";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
