using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*Z*4*1*jmN3Qowj*2gjJH4iR*7*1*d2*g*m*A*c*5*3*3*B5*9";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "Z",
			MonetaryAmount = 4,
			MonetaryAmount2 = 1,
			Date = "jmN3Qowj",
			Date2 = "2gjJH4iR",
			Number = 7,
			Description = "1",
			ProductServiceIDQualifier = "d2",
			ProductServiceID = "g",
			Amount = "m",
			Amount2 = "A",
			Amount3 = "c",
			Quantity = 5,
			Quantity2 = 3,
			Quantity3 = 3,
			ReferenceIdentificationQualifier = "B5",
			ReferenceIdentification = "9",
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
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jmN3Qowj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date2 = "2gjJH4iR";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2gjJH4iR", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("d2", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("d2", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("m", "", false)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("m", "A", "c", true)]
	[InlineData("m", "", "", false)]
	[InlineData("", "A", "c", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("A", "m", "c", true)]
	[InlineData("A", "", "", false)]
	[InlineData("", "m", "c", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("c", "", false)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("c", "m", "A", true)]
	[InlineData("c", "", "", false)]
	[InlineData("", "m", "A", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "g", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(5, 3, 3, true)]
	[InlineData(5, 0, 0, false)]
	[InlineData(0, 3, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
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
	[InlineData(0, "g", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(3, 5, 3, true)]
	[InlineData(3, 0, 0, false)]
	[InlineData(0, 5, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
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
	[InlineData(0, "g", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(3, 5, 3, true)]
	[InlineData(3, 0, 0, false)]
	[InlineData(0, 5, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
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
	[InlineData("B5", "9", true)]
	[InlineData("", "9", false)]
	[InlineData("B5", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "g", true)]
	[InlineData("9", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "Z";
		subject.MonetaryAmount = 4;
		subject.Date = "jmN3Qowj";
		subject.Date2 = "2gjJH4iR";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
