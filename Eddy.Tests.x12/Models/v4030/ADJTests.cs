using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*H*3*6*pM70GfIt*7R87Kblm*1*B*LT*B*U*K*j*7*2*6*RD*C";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "H",
			MonetaryAmount = 3,
			MonetaryAmount2 = 6,
			Date = "pM70GfIt",
			Date2 = "7R87Kblm",
			Number = 1,
			Description = "B",
			ProductServiceIDQualifier = "LT",
			ProductServiceID = "B",
			Amount = "U",
			Amount2 = "K",
			Amount3 = "j",
			Quantity = 7,
			Quantity2 = 2,
			Quantity3 = 6,
			ReferenceIdentificationQualifier = "RD",
			ReferenceIdentification = "C",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pM70GfIt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date2 = "7R87Kblm";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7R87Kblm", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("LT", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("LT", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "B", true)]
	[InlineData("U", "", false)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("U", "K", "j", true)]
	[InlineData("U", "", "", false)]
	[InlineData("", "K", "j", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "B", true)]
	[InlineData("K", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("K", "U", "j", true)]
	[InlineData("K", "", "", false)]
	[InlineData("", "U", "j", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "B", true)]
	[InlineData("j", "", false)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("j", "U", "K", true)]
	[InlineData("j", "", "", false)]
	[InlineData("", "U", "K", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "B", true)]
	[InlineData(7, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(7, 2, 6, true)]
	[InlineData(7, 0, 0, false)]
	[InlineData(0, 2, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
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
	[InlineData(0, "B", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 7, 6, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 7, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
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
	[InlineData(0, "B", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 7, 2, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 7, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
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
	[InlineData("RD", "C", true)]
	[InlineData("", "C", false)]
	[InlineData("RD", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "B", true)]
	[InlineData("C", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "H";
		subject.MonetaryAmount = 3;
		subject.Date = "pM70GfIt";
		subject.Date2 = "7R87Kblm";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
