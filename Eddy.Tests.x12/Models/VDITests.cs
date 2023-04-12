using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VDI*K8**5*5*2*9*1*Yw*a*bC*4*9*1*p9*5o";

		var expected = new VDI_ValueDescriptionOrInformation()
		{
			CodeCategory = "K8",
			CompositeQualifierIdentifier = "",
			Quantity = 5,
			PercentageAsDecimal = 5,
			MonetaryAmount = 2,
			Number = 9,
			Number2 = 1,
			DateTimePeriodFormatQualifier = "Yw",
			DateTimePeriod = "a",
			UnitOfTimePeriodOrIntervalCode = "bC",
			Quantity2 = 4,
			Multiplier = 9,
			RoundingSystemCode = "1",
			LoanPaymentTypeCode = "p9",
			LoanPaymentTypeCode2 = "5o",
		};

		var actual = Map.MapObject<VDI_ValueDescriptionOrInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, C046_CompositeQualifierIdentifier compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.CompositeQualifierIdentifier = compositeQualifierIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(5, 5, false)]
	[InlineData(0, 5, true)]
	[InlineData(5, 0, true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		if (quantity > 0)
		subject.Quantity = quantity;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBPercentageAsDecimal(decimal percentageAsDecimal, C046_CompositeQualifierIdentifier compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;
		subject.CompositeQualifierIdentifier = compositeQualifierIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, C046_CompositeQualifierIdentifier compositeQualifierIdentifier, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.CompositeQualifierIdentifier = compositeQualifierIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 9, true)]
	[InlineData(1, 0, false)]
	public void Validation_ARequiresBNumber2(int number2, int number, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		if (number2 > 0)
		subject.Number2 = number2;
		if (number > 0)
		subject.Number = number;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Yw", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("Yw", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 4, true)]
	[InlineData("bC", 0, false)]
	public void Validation_ARequiresBUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, decimal quantity2, bool isValidExpected)
	{
		var subject = new VDI_ValueDescriptionOrInformation();
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
