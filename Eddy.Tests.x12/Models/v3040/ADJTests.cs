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
		string x12Line = "ADJ*S*1*2*JrOzMV*z9sxVe*9*Y*sU*E*M*g*9*6*5*2*hk*6";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "S",
			MonetaryAmount = 1,
			MonetaryAmount2 = 2,
			Date = "JrOzMV",
			Date2 = "z9sxVe",
			NumberOfDays = 9,
			Description = "Y",
			ProductServiceIDQualifier = "sU",
			ProductServiceID = "E",
			Amount = "M",
			Amount2 = "g",
			Amount3 = "9",
			Quantity = 6,
			Quantity2 = 5,
			Quantity3 = 2,
			ReferenceNumberQualifier = "hk",
			ReferenceNumber = "6",
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
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JrOzMV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date2 = "z9sxVe";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z9sxVe", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sU", "E", true)]
	[InlineData("sU", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "E", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "E", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "E", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "E", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "E", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "E", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "hk";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hk", "6", true)]
	[InlineData("hk", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "S";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 2;
		subject.Date = "JrOzMV";
		subject.Date2 = "z9sxVe";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "sU";
			subject.ProductServiceID = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
