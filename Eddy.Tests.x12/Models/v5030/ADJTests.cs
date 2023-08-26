using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*J*2*3*zEJSEbPE*H8UDpyS6*3*Y*nv*M*X*4*L*4*7*6*PM*A";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "J",
			MonetaryAmount = 2,
			MonetaryAmount2 = 3,
			Date = "zEJSEbPE",
			Date2 = "H8UDpyS6",
			Number = 3,
			Description = "Y",
			ProductServiceIDQualifier = "nv",
			ProductServiceID = "M",
			Amount = "X",
			Amount2 = "4",
			Amount3 = "L",
			Quantity = 4,
			Quantity2 = 7,
			Quantity3 = 6,
			ReferenceIdentificationQualifier = "PM",
			ReferenceIdentification = "A",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zEJSEbPE", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date2 = "H8UDpyS6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H8UDpyS6", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("nv", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("nv", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "M", true)]
	[InlineData("X", "", false)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("X", "4", "L", true)]
	[InlineData("X", "", "", false)]
	[InlineData("", "4", "L", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "M", true)]
	[InlineData("4", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("4", "X", "L", true)]
	[InlineData("4", "", "", false)]
	[InlineData("", "X", "L", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "M", true)]
	[InlineData("L", "", false)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("L", "X", "4", true)]
	[InlineData("L", "", "", false)]
	[InlineData("", "X", "4", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "M", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(4, 7, 6, true)]
	[InlineData(4, 0, 0, false)]
	[InlineData(0, 7, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
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
	[InlineData(0, "M", true)]
	[InlineData(7, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(7, 4, 6, true)]
	[InlineData(7, 0, 0, false)]
	[InlineData(0, 4, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
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
	[InlineData(0, "M", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 4, 7, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 4, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
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
	[InlineData("PM", "A", true)]
	[InlineData("", "A", false)]
	[InlineData("PM", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "M", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "J";
		subject.MonetaryAmount = 2;
		subject.Date = "zEJSEbPE";
		subject.Date2 = "H8UDpyS6";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
