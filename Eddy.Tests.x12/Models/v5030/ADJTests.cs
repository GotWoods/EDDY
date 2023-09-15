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
		string x12Line = "ADJ*P*7*5*gF1W1fUs*ajN4jDAI*9*K*U7*4*G*A*Z*2*5*6*sn*N";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "P",
			MonetaryAmount = 7,
			MonetaryAmount2 = 5,
			Date = "gF1W1fUs",
			Date2 = "ajN4jDAI",
			Number = 9,
			Description = "K",
			ProductServiceIDQualifier = "U7",
			ProductServiceID = "4",
			Amount = "G",
			Amount2 = "A",
			Amount3 = "Z",
			Quantity = 2,
			Quantity2 = 5,
			Quantity3 = 6,
			ReferenceIdentificationQualifier = "sn",
			ReferenceIdentification = "N",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gF1W1fUs", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date2 = "ajN4jDAI";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ajN4jDAI", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U7", "4", true)]
	[InlineData("U7", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "4", true)]
	[InlineData("G", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("G", "A", "Z", true)]
	[InlineData("G", "", "", false)]
	[InlineData("", "A", "Z", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;
		if (amount2 != "")
			subject.ProductServiceID = "4";
		if (amount3 != "")
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "4", true)]
	[InlineData("A", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("A", "G", "Z", true)]
	[InlineData("A", "", "", false)]
	[InlineData("", "G", "Z", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;
		if (amount != "")
			subject.ProductServiceID = "4";
		if (amount3 != "")
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "4", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Z", "G", "A", true)]
	[InlineData("Z", "", "", false)]
	[InlineData("", "G", "A", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;
		if (amount != "")
			subject.ProductServiceID = "4";
		if (amount2 != "")
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "4", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "4", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 5, 6, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 5, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity2 > 0)
			subject.ProductServiceID = "4";
		if (quantity3 > 0)
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "4", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "4", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(5, 2, 6, true)]
	[InlineData(5, 0, 0, false)]
	[InlineData(0, 2, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.ProductServiceID = "4";
		if (quantity3 > 0)
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "4", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "4", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 2, 5, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 2, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.ProductServiceID = "4";
		if (quantity2 > 0)
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sn", "N", true)]
	[InlineData("sn", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		if (referenceIdentification != "")
			subject.ProductServiceID = "4";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "4", true)]
	[InlineData("N", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "P";
		subject.MonetaryAmount = 7;
		subject.Date = "gF1W1fUs";
		subject.Date2 = "ajN4jDAI";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "U7";
			subject.ProductServiceID = "4";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "sn";
			subject.ReferenceIdentification = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
