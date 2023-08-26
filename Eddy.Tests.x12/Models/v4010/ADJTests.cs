using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*Z*2*8*QkiMvghU*4oH8PnFP*8*N*8F*T*G*q*U*9*6*4*C1*c";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "Z",
			MonetaryAmount = 2,
			MonetaryAmount2 = 8,
			Date = "QkiMvghU",
			Date2 = "4oH8PnFP",
			Number = 8,
			Description = "N",
			ProductServiceIDQualifier = "8F",
			ProductServiceID = "T",
			Amount = "G",
			Amount2 = "q",
			Amount3 = "U",
			Quantity = 9,
			Quantity2 = 6,
			Quantity3 = 4,
			ReferenceIdentificationQualifier = "C1",
			ReferenceIdentification = "c",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QkiMvghU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date2 = "4oH8PnFP";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4oH8PnFP", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8F", "T", true)]
	[InlineData("", "T", false)]
	[InlineData("8F", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "T", true)]
	[InlineData("G", "", false)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("G", "q", "U", true)]
	[InlineData("G", "", "", false)]
	[InlineData("", "q", "U", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "T", true)]
	[InlineData("q", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("q", "G", "U", true)]
	[InlineData("q", "", "", false)]
	[InlineData("", "G", "U", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "T", true)]
	[InlineData("U", "", false)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("U", "G", "q", true)]
	[InlineData("U", "", "", false)]
	[InlineData("", "G", "q", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "T", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(9, 6, 4, true)]
	[InlineData(9, 0, 0, false)]
	[InlineData(0, 6, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
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
	[InlineData(0, "T", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 9, 4, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 9, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
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
	[InlineData(0, "T", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(4, 9, 6, true)]
	[InlineData(4, 0, 0, false)]
	[InlineData(0, 9, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
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
	[InlineData("C1", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("C1", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "T", true)]
	[InlineData("c", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 2;
		subject.Date = "QkiMvghU";
		subject.Date2 = "4oH8PnFP";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
