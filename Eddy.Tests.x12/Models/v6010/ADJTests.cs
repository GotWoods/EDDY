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
		string x12Line = "ADJ*S*7*9*6GWbT4Vq*1TjbRxMb*6*2*nb*l*p*e*t*3*8*9*aw*7";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "S",
			MonetaryAmount = 7,
			MonetaryAmount2 = 9,
			Date = "6GWbT4Vq",
			Date2 = "1TjbRxMb",
			Number = 6,
			Description = "2",
			ProductServiceIDQualifier = "nb",
			ProductServiceID = "l",
			Amount = "p",
			Amount2 = "e",
			Amount3 = "t",
			Quantity = 3,
			Quantity2 = 8,
			Quantity3 = 9,
			ReferenceIdentificationQualifier = "aw",
			ReferenceIdentification = "7",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6GWbT4Vq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date2 = "1TjbRxMb";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1TjbRxMb", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nb", "l", true)]
	[InlineData("nb", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "l", true)]
	[InlineData("p", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("p", "e", "t", true)]
	[InlineData("p", "", "", false)]
	[InlineData("", "e", "t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;
		if (amount2 != "")
			subject.ProductServiceID = "l";
		if (amount3 != "")
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "l", true)]
	[InlineData("e", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("e", "p", "t", true)]
	[InlineData("e", "", "", false)]
	[InlineData("", "p", "t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;
		if (amount != "")
			subject.ProductServiceID = "l";
		if (amount3 != "")
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "l", true)]
	[InlineData("t", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("t", "p", "e", true)]
	[InlineData("t", "", "", false)]
	[InlineData("", "p", "e", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;
		if (amount != "")
			subject.ProductServiceID = "l";
		if (amount2 != "")
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "l", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "l", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(3, 8, 9, true)]
	[InlineData(3, 0, 0, false)]
	[InlineData(0, 8, 9, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity2 > 0)
			subject.ProductServiceID = "l";
		if (quantity3 > 0)
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "l", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "l", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(8, 3, 9, true)]
	[InlineData(8, 0, 0, false)]
	[InlineData(0, 3, 9, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.ProductServiceID = "l";
		if (quantity3 > 0)
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "l", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "l", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(9, 3, 8, true)]
	[InlineData(9, 0, 0, false)]
	[InlineData(0, 3, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.ProductServiceID = "l";
		if (quantity2 > 0)
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aw", "7", true)]
	[InlineData("aw", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		if (referenceIdentification != "")
			subject.ProductServiceID = "l";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "l", true)]
	[InlineData("7", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 7;
		subject.Date = "6GWbT4Vq";
		subject.Date2 = "1TjbRxMb";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nb";
			subject.ProductServiceID = "l";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "aw";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
