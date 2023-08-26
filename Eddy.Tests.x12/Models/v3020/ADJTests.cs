using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*6*1*7*zIqzRD*3szseg*3*I*Zm*p*u*h*C*1*9*6*k6*R";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "6",
			MonetaryAmount = 1,
			MonetaryAmount2 = 7,
			Date = "zIqzRD",
			Date2 = "3szseg",
			NumberOfDays = 3,
			Description = "I",
			ProductServiceIDQualifier = "Zm",
			ProductServiceID = "p",
			Amount = "u",
			Amount2 = "h",
			Amount3 = "C",
			Quantity = 1,
			Quantity2 = 9,
			Quantity3 = 6,
			ReferenceNumberQualifier = "k6",
			ReferenceNumber = "R",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zIqzRD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date2 = "3szseg";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3szseg", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Zm", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("Zm", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "p", true)]
	[InlineData(1, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "p", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "p", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("k6", "R", true)]
	[InlineData("", "R", false)]
	[InlineData("k6", "", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "6";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 7;
		subject.Date = "zIqzRD";
		subject.Date2 = "3szseg";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
