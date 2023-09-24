using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT1*E*2*OJ*4*bM*jv*b*gR*C*Oh*C*lX*Y*V9*J*tN*O*sx*Q*z1*2*XC*I*p2*L";

		var expected = new IT1_BaselineItemDataInvoice()
		{
			AssignedIdentification = "E",
			QuantityInvoiced = 2,
			UnitOfMeasurementCode = "OJ",
			UnitPrice = 4,
			BasisOfUnitPriceCode = "bM",
			ProductServiceIDQualifier = "jv",
			ProductServiceID = "b",
			ProductServiceIDQualifier2 = "gR",
			ProductServiceID2 = "C",
			ProductServiceIDQualifier3 = "Oh",
			ProductServiceID3 = "C",
			ProductServiceIDQualifier4 = "lX",
			ProductServiceID4 = "Y",
			ProductServiceIDQualifier5 = "V9",
			ProductServiceID5 = "J",
			ProductServiceIDQualifier6 = "tN",
			ProductServiceID6 = "O",
			ProductServiceIDQualifier7 = "sx",
			ProductServiceID7 = "Q",
			ProductServiceIDQualifier8 = "z1",
			ProductServiceID8 = "2",
			ProductServiceIDQualifier9 = "XC",
			ProductServiceID9 = "I",
			ProductServiceIDQualifier10 = "p2",
			ProductServiceID10 = "L",
		};

		var actual = Map.MapObject<IT1_BaselineItemDataInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OJ", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitPrice = 4;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jv", "b", true)]
	[InlineData("jv", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gR", "C", true)]
	[InlineData("gR", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Oh", "C", true)]
	[InlineData("Oh", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lX", "Y", true)]
	[InlineData("lX", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V9", "J", true)]
	[InlineData("V9", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tN", "O", true)]
	[InlineData("tN", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sx", "Q", true)]
	[InlineData("sx", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z1", "2", true)]
	[InlineData("z1", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XC", "I", true)]
	[InlineData("XC", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p2", "L", true)]
	[InlineData("p2", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 2;
		subject.UnitOfMeasurementCode = "OJ";
		subject.UnitPrice = 4;
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
