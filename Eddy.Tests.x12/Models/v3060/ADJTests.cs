using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*w*8*4*tk6nzZ*xA0gv1*8*i*7I*P*h*b*V*4*6*9*OE*n";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "w",
			MonetaryAmount = 8,
			MonetaryAmount2 = 4,
			Date = "tk6nzZ",
			Date2 = "xA0gv1",
			Number = 8,
			Description = "i",
			ProductServiceIDQualifier = "7I",
			ProductServiceID = "P",
			Amount = "h",
			Amount2 = "b",
			Amount3 = "V",
			Quantity = 4,
			Quantity2 = 6,
			Quantity3 = 9,
			ReferenceIdentificationQualifier = "OE",
			ReferenceIdentification = "n",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tk6nzZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date2 = "xA0gv1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xA0gv1", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("7I", "P", true)]
	[InlineData("", "P", false)]
	[InlineData("7I", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "P", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "P", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "P", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OE", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("OE", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 8;
		subject.Date = "tk6nzZ";
		subject.Date2 = "xA0gv1";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
