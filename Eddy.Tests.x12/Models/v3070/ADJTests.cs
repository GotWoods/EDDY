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
		string x12Line = "ADJ*m*4*6*RQGcg0*8W0g5I*8*c*rT*B*9*M*A*2*8*1*pB*B";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "m",
			MonetaryAmount = 4,
			MonetaryAmount2 = 6,
			Date = "RQGcg0",
			Date2 = "8W0g5I",
			Number = 8,
			Description = "c",
			ProductServiceIDQualifier = "rT",
			ProductServiceID = "B",
			Amount = "9",
			Amount2 = "M",
			Amount3 = "A",
			Quantity = 2,
			Quantity2 = 8,
			Quantity3 = 1,
			ReferenceIdentificationQualifier = "pB",
			ReferenceIdentification = "B",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RQGcg0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date2 = "8W0g5I";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8W0g5I", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rT", "B", true)]
	[InlineData("rT", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "B", true)]
	[InlineData("9", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("9", "M", "A", true)]
	[InlineData("9", "", "", false)]
	[InlineData("", "M", "A", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;
		if (amount2 != "")
			subject.ProductServiceID = "B";
		if (amount3 != "")
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "B", true)]
	[InlineData("M", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("M", "9", "A", true)]
	[InlineData("M", "", "", false)]
	[InlineData("", "9", "A", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;
		if (amount != "")
			subject.ProductServiceID = "B";
		if (amount3 != "")
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "B", true)]
	[InlineData("A", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("A", "9", "M", true)]
	[InlineData("A", "", "", false)]
	[InlineData("", "9", "M", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;
		if (amount != "")
			subject.ProductServiceID = "B";
		if (amount2 != "")
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "B", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "B", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 8, 1, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 8, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity2 > 0)
			subject.ProductServiceID = "B";
		if (quantity3 > 0)
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "B", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "B", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(8, 2, 1, true)]
	[InlineData(8, 0, 0, false)]
	[InlineData(0, 2, 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.ProductServiceID = "B";
		if (quantity3 > 0)
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "B", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "B", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(1, 2, 8, true)]
	[InlineData(1, 0, 0, false)]
	[InlineData(0, 2, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.ProductServiceID = "B";
		if (quantity2 > 0)
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pB", "B", true)]
	[InlineData("pB", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		if (referenceIdentification != "")
			subject.ProductServiceID = "B";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "B", true)]
	[InlineData("B", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "m";
		subject.MonetaryAmount = 4;
		subject.Date = "RQGcg0";
		subject.Date2 = "8W0g5I";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "rT";
			subject.ProductServiceID = "B";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "pB";
			subject.ReferenceIdentification = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
