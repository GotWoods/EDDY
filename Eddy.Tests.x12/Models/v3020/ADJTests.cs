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
		string x12Line = "ADJ*k*9*8*CAD0SZ*a6jCOe*2*Q*Qz*A*S*5*2*5*1*4*fX*6";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "k",
			MonetaryAmount = 9,
			MonetaryAmount2 = 8,
			Date = "CAD0SZ",
			Date2 = "a6jCOe",
			NumberOfDays = 2,
			Description = "Q",
			ProductServiceIDQualifier = "Qz",
			ProductServiceID = "A",
			Amount = "S",
			Amount2 = "5",
			Amount3 = "2",
			Quantity = 5,
			Quantity2 = 1,
			Quantity3 = 4,
			ReferenceNumberQualifier = "fX",
			ReferenceNumber = "6",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CAD0SZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date2 = "a6jCOe";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a6jCOe", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qz", "A", true)]
	[InlineData("Qz", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "A", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		if(subject.ReferenceNumberQualifier != ""||subject.ReferenceNumberQualifier != ""||subject.ReferenceNumber != "")
		{
			subject.ReferenceNumberQualifier = "fX";
			subject.ReferenceNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fX", "6", true)]
	[InlineData("fX", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "k";
		subject.MonetaryAmount = 9;
		subject.MonetaryAmount2 = 8;
		subject.Date = "CAD0SZ";
		subject.Date2 = "a6jCOe";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "Qz";
			subject.ProductServiceID = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
