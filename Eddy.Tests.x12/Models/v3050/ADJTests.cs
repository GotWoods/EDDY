using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*s*8*2*GwcMwZ*uQiumk*3*r*CH*R*H*7*y*9*4*9*85*g";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "s",
			MonetaryAmount = 8,
			MonetaryAmount2 = 2,
			Date = "GwcMwZ",
			Date2 = "uQiumk",
			Number = 3,
			Description = "r",
			ProductServiceIDQualifier = "CH",
			ProductServiceID = "R",
			Amount = "H",
			Amount2 = "7",
			Amount3 = "y",
			Quantity = 9,
			Quantity2 = 4,
			Quantity3 = 9,
			ReferenceNumberQualifier = "85",
			ReferenceNumber = "g",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GwcMwZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date2 = "uQiumk";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uQiumk", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CH", "R", true)]
	[InlineData("CH", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "R", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "R", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "R", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "R", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "R", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "R", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "85";
			subject.ReferenceNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("85", "g", true)]
	[InlineData("85", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "s";
		subject.MonetaryAmount = 8;
		subject.Date = "GwcMwZ";
		subject.Date2 = "uQiumk";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "CH";
			subject.ProductServiceID = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
