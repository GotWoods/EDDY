using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ADJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADJ*n*3*4*3POPJUzZ*P3MUND6b*9*E*nd*g*j*L*3*7*7*2*S3*d";

		var expected = new ADJ_AdjustmentsToBalancesOrServices()
		{
			AdjustmentApplicationCode = "n",
			MonetaryAmount = 3,
			MonetaryAmount2 = 4,
			Date = "3POPJUzZ",
			Date2 = "P3MUND6b",
			Number = 9,
			Description = "E",
			ProductServiceIDQualifier = "nd",
			ProductServiceID = "g",
			Amount = "j",
			Amount2 = "L",
			Amount3 = "3",
			Quantity = 7,
			Quantity2 = 7,
			Quantity3 = 2,
			ReferenceIdentificationQualifier = "S3",
			ReferenceIdentification = "d",
		};

		var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.AdjustmentApplicationCode = adjustmentApplicationCode;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3POPJUzZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date2 = "P3MUND6b";
		subject.Date = date;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P3MUND6b", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = date2;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nd", "g", true)]
	[InlineData("nd", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "g", true)]
	[InlineData("j", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount = amount;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("j", "L", "3", true)]
	[InlineData("j", "", "", false)]
	[InlineData("", "L", "3", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount = amount;
		subject.Amount2 = amount2;
		subject.Amount3 = amount3;
		if (amount2 != "")
			subject.ProductServiceID = "g";
		if (amount3 != "")
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "g", true)]
	[InlineData("L", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount2 = amount2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("L", "j", "3", true)]
	[InlineData("L", "", "", false)]
	[InlineData("", "j", "3", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string amount, string amount3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount2 = amount2;
		subject.Amount = amount;
		subject.Amount3 = amount3;
		if (amount != "")
			subject.ProductServiceID = "g";
		if (amount3 != "")
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "g", true)]
	[InlineData("3", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount3 = amount3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("3", "j", "L", true)]
	[InlineData("3", "", "", false)]
	[InlineData("", "j", "L", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string amount, string amount2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.Amount3 = amount3;
		subject.Amount = amount;
		subject.Amount2 = amount2;
		if (amount != "")
			subject.ProductServiceID = "g";
		if (amount2 != "")
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "g", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "g", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(7, 7, 2, true)]
	[InlineData(7, 0, 0, false)]
	[InlineData(0, 7, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity2 > 0)
			subject.ProductServiceID = "g";
		if (quantity3 > 0)
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "g", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "g", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(7, 7, 2, true)]
	[InlineData(7, 0, 0, false)]
	[InlineData(0, 7, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.ProductServiceID = "g";
		if (quantity3 > 0)
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "g", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "g", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, 0, true)]
	[InlineData(2, 7, 7, true)]
	[InlineData(2, 0, 0, false)]
	[InlineData(0, 7, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		if (quantity3 > 0)
			subject.Quantity3 = quantity3;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		if (quantity > 0)
			subject.ProductServiceID = "g";
		if (quantity2 > 0)
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S3", "d", true)]
	[InlineData("S3", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		if (referenceIdentification != "")
			subject.ProductServiceID = "g";
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "g", true)]
	[InlineData("d", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
	{
		var subject = new ADJ_AdjustmentsToBalancesOrServices();
		subject.AdjustmentApplicationCode = "n";
		subject.MonetaryAmount = 3;
		subject.Date = "3POPJUzZ";
		subject.Date2 = "P3MUND6b";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ProductServiceID = productServiceID;
		if(subject.ProductServiceIDQualifier != ""||subject.ProductServiceIDQualifier != ""||subject.ProductServiceID != "")
		{
			subject.ProductServiceIDQualifier = "nd";
			subject.ProductServiceID = "g";
		}
		if(subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentificationQualifier != ""||subject.ReferenceIdentification != "")
		{
			subject.ReferenceIdentificationQualifier = "S3";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
