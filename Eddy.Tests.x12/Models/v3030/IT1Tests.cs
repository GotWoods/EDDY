using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT1*n*3*xt*7*xY*XM*u*tX*F*a1*Q*Fe*u*Y6*f*UW*U*Io*9*BO*I*Me*P*Kc*g";

		var expected = new IT1_BaselineItemDataInvoice()
		{
			AssignedIdentification = "n",
			QuantityInvoiced = 3,
			UnitOrBasisForMeasurementCode = "xt",
			UnitPrice = 7,
			BasisOfUnitPriceCode = "xY",
			ProductServiceIDQualifier = "XM",
			ProductServiceID = "u",
			ProductServiceIDQualifier2 = "tX",
			ProductServiceID2 = "F",
			ProductServiceIDQualifier3 = "a1",
			ProductServiceID3 = "Q",
			ProductServiceIDQualifier4 = "Fe",
			ProductServiceID4 = "u",
			ProductServiceIDQualifier5 = "Y6",
			ProductServiceID5 = "f",
			ProductServiceIDQualifier6 = "UW",
			ProductServiceID6 = "U",
			ProductServiceIDQualifier7 = "Io",
			ProductServiceID7 = "9",
			ProductServiceIDQualifier8 = "BO",
			ProductServiceID8 = "I",
			ProductServiceIDQualifier9 = "Me",
			ProductServiceID9 = "P",
			ProductServiceIDQualifier10 = "Kc",
			ProductServiceID10 = "g",
		};

		var actual = Map.MapObject<IT1_BaselineItemDataInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xt", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitPrice = 7;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XM", "u", true)]
	[InlineData("XM", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tX", "F", true)]
	[InlineData("tX", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a1", "Q", true)]
	[InlineData("a1", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fe", "u", true)]
	[InlineData("Fe", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y6", "f", true)]
	[InlineData("Y6", "", false)]
	[InlineData("", "f", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UW", "U", true)]
	[InlineData("UW", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Io", "9", true)]
	[InlineData("Io", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BO", "I", true)]
	[InlineData("BO", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Me", "P", true)]
	[InlineData("Me", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kc", "g", true)]
	[InlineData("Kc", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 3;
		subject.UnitOrBasisForMeasurementCode = "xt";
		subject.UnitPrice = 7;
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
