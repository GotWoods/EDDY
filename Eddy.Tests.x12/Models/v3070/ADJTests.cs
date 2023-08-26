using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*E*8*7*8jSVIk*moWpSm*8*S*cI*1*S*W*l*2*6*8*CC*l";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "E",
			MonetaryAmount = 8,
			MonetaryAmount2 = 7,
			Date = "8jSVIk",
			Date2 = "moWpSm",
			Number = 8,
			Description = "S",
			ProductServiceIDQualifier = "cI",
			ProductServiceID = "1",
			Amount = "S",
			Amount2 = "W",
			Amount3 = "l",
			Quantity = 2,
			Quantity2 = 6,
			Quantity3 = 8,
			ReferenceIdentificationQualifier = "CC",
			ReferenceIdentification = "l",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8jSVIk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date2 = "moWpSm";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("moWpSm", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("cI", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("cI", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("S", "", false)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("S", "W", "l", true)]
	[InlineData("S", "", "", false)]
	[InlineData("", "W", "l", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("W", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("W", "S", "l", true)]
	[InlineData("W", "", "", false)]
	[InlineData("", "S", "l", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("l", "", false)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("l", "S", "W", true)]
	[InlineData("l", "", "", false)]
	[InlineData("", "S", "W", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "1", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 6, 8, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 6, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity > 0)
		subject.Quantity = quantity;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "1", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 2, 8, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 2, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		if (quantity > 0)
		subject.Quantity = quantity;
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "1", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(8, 2, 6, true)]
	[InlineData(8, 0, 0, false)]
	[InlineData(0, 2, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		if (quantity > 0)
		subject.Quantity = quantity;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("CC", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("CC", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("l", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "E";
		subject.MonetaryAmount = 8;
		subject.Date = "8jSVIk";
		subject.Date2 = "moWpSm";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
