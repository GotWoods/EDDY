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
		string x12Line = "ADJ*w*5*4*neWR49Bp*zg8oV02s*1*B*KJ*x*2*L*x*4*6*1*fx*o";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "w",
			MonetaryAmount = 5,
			MonetaryAmount2 = 4,
			Date = "neWR49Bp",
			Date2 = "zg8oV02s",
			Number = 1,
			Description = "B",
			ProductServiceIDQualifier = "KJ",
			ProductServiceID = "x",
			Amount = "2",
			Amount2 = "L",
			Amount3 = "x",
			Quantity = 4,
			Quantity2 = 6,
			Quantity3 = 1,
			ReferenceIdentificationQualifier = "fx",
			ReferenceIdentification = "o",
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
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("neWR49Bp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date2 = "zg8oV02s";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zg8oV02s", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KJ", "x", true)]
	[InlineData("KJ", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "x", true)]
	[InlineData("2", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("2", "L", "x", true)]
	[InlineData("2", "", "", false)]
	[InlineData("", "L", "x", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;
		if (amount2 != "")
			subject.ProductServiceID = "x";
		if (amount3 != "")
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "x", true)]
	[InlineData("L", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("L", "2", "x", true)]
	[InlineData("L", "", "", false)]
	[InlineData("", "2", "x", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;
		if (amount != "")
			subject.ProductServiceID = "x";
		if (amount3 != "")
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "x", true)]
	[InlineData("x", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("x", "2", "L", true)]
	[InlineData("x", "", "", false)]
	[InlineData("", "2", "L", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;
		if (amount != "")
			subject.ProductServiceID = "x";
		if (amount2 != "")
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "x", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(4, 6, 1, true)]
	[InlineData(4, 0, 0, false)]
	[InlineData(0, 6, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity2 > 0)
			subject.ProductServiceID = "x";
		if (quantity3 > 0)
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "x", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(6, 4, 1, true)]
	[InlineData(6, 0, 0, false)]
	[InlineData(0, 4, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.ProductServiceID = "x";
		if (quantity3 > 0)
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "x", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "x", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(1, 4, 6, true)]
	[InlineData(1, 0, 0, false)]
	[InlineData(0, 4, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.ProductServiceID = "x";
		if (quantity2 > 0)
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fx", "o", true)]
	[InlineData("fx", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		if (referenceIdentification != "")
			subject.ProductServiceID = "x";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "x", true)]
	[InlineData("o", "", false)]
	[InlineData("", "x", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "w";
		subject.MonetaryAmount = 5;
		subject.Date = "neWR49Bp";
		subject.Date2 = "zg8oV02s";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "KJ";
			subject.ProductServiceID = "x";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "fx";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
