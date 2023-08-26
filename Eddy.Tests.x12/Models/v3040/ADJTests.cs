using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*2*9*4*lLTM0N*dhbIRC*5*G*Yw*F*u*j*O*8*9*2*D9*Z";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "2",
			MonetaryAmount = 9,
			MonetaryAmount2 = 4,
			Date = "lLTM0N",
			Date2 = "dhbIRC",
			NumberOfDays = 5,
			Description = "G",
			ProductServiceIDQualifier = "Yw",
			ProductServiceID = "F",
			Amount = "u",
			Amount2 = "j",
			Amount3 = "O",
			Quantity = 8,
			Quantity2 = 9,
			Quantity3 = 2,
			ReferenceNumberQualifier = "D9",
			ReferenceNumber = "Z",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lLTM0N", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date2 = "dhbIRC";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dhbIRC", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Yw", "F", true)]
	[InlineData("", "F", false)]
	[InlineData("Yw", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "F", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "F", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "F", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D9", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("D9", "", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "2";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 4;
		subject.Date = "lLTM0N";
		subject.Date2 = "dhbIRC";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
