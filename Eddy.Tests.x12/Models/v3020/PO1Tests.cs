using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PO1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO1*m*1*34*4*Ij*e6*d*JW*k*1z*k*Zt*w*PU*B*JF*H*O3*I*Zf*m*gd*z*Fe*D";

		var expected = new PO1_PurchaseOrderBaselineItemData()
		{
			AssignedIdentification = "m",
			QuantityOrdered = 1,
			UnitOfMeasurementCode = "34",
			UnitPrice = 4,
			BasisOfUnitPriceCode = "Ij",
			ProductServiceIDQualifier = "e6",
			ProductServiceID = "d",
			ProductServiceIDQualifier2 = "JW",
			ProductServiceID2 = "k",
			ProductServiceIDQualifier3 = "1z",
			ProductServiceID3 = "k",
			ProductServiceIDQualifier4 = "Zt",
			ProductServiceID4 = "w",
			ProductServiceIDQualifier5 = "PU",
			ProductServiceID5 = "B",
			ProductServiceIDQualifier6 = "JF",
			ProductServiceID6 = "H",
			ProductServiceIDQualifier7 = "O3",
			ProductServiceID7 = "I",
			ProductServiceIDQualifier8 = "Zf",
			ProductServiceID8 = "m",
			ProductServiceIDQualifier9 = "gd",
			ProductServiceID9 = "z",
			ProductServiceIDQualifier10 = "Fe",
			ProductServiceID10 = "D",
		};

		var actual = Map.MapObject<PO1_PurchaseOrderBaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.UnitOfMeasurementCode = "34";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("34", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ij", 4, true)]
	[InlineData("Ij", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e6", "d", true)]
	[InlineData("e6", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JW", "k", true)]
	[InlineData("JW", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1z", "k", true)]
	[InlineData("1z", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zt", "w", true)]
	[InlineData("Zt", "", false)]
	[InlineData("", "w", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PU", "B", true)]
	[InlineData("PU", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JF", "H", true)]
	[InlineData("JF", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O3", "I", true)]
	[InlineData("O3", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zf", "m", true)]
	[InlineData("Zf", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gd", "z", true)]
	[InlineData("gd", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fe", "D", true)]
	[InlineData("Fe", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 1;
		subject.UnitOfMeasurementCode = "34";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
