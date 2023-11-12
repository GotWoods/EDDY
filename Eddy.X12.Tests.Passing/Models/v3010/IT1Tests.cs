using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT1*e*4*Nm*5*nm*Lv*I*4V*3*ve*E*C6*L*by*c*6a*O*H8*8*0j*q*qR*V*pY*l";

		var expected = new IT1_BaselineItemDataInvoice()
		{
			AssignedIdentification = "e",
			QuantityInvoiced = 4,
			UnitOfMeasurementCode = "Nm",
			UnitPrice = 5,
			BasisOfUnitPriceCode = "nm",
			ProductServiceIDQualifier = "Lv",
			ProductServiceID = "I",
			ProductServiceIDQualifier2 = "4V",
			ProductServiceID2 = "3",
			ProductServiceIDQualifier3 = "ve",
			ProductServiceID3 = "E",
			ProductServiceIDQualifier4 = "C6",
			ProductServiceID4 = "L",
			ProductServiceIDQualifier5 = "by",
			ProductServiceID5 = "c",
			ProductServiceIDQualifier6 = "6a",
			ProductServiceID6 = "O",
			ProductServiceIDQualifier7 = "H8",
			ProductServiceID7 = "8",
			ProductServiceIDQualifier8 = "0j",
			ProductServiceID8 = "q",
			ProductServiceIDQualifier9 = "qR",
			ProductServiceID9 = "V",
			ProductServiceIDQualifier10 = "pY",
			ProductServiceID10 = "l",
		};

		var actual = Map.MapObject<IT1_BaselineItemDataInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.UnitOfMeasurementCode = "Nm";
		subject.UnitPrice = 5;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nm", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 4;
		subject.UnitPrice = 5;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.QuantityInvoiced = 4;
		subject.UnitOfMeasurementCode = "Nm";
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
