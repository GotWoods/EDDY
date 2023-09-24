using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ACKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACK*Cb*6*MQ*ce2*7ZB2CV*d*oH*k*Xq*d*kn*D*A8*y*29*9*Oe*2*CX*U*wF*I*Be*s*HS*5*b8*f*Z";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "Cb",
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "MQ",
			DateTimeQualifier = "ce2",
			Date = "7ZB2CV",
			RequestReferenceNumber = "d",
			ProductServiceIDQualifier = "oH",
			ProductServiceID = "k",
			ProductServiceIDQualifier2 = "Xq",
			ProductServiceID2 = "d",
			ProductServiceIDQualifier3 = "kn",
			ProductServiceID3 = "D",
			ProductServiceIDQualifier4 = "A8",
			ProductServiceID4 = "y",
			ProductServiceIDQualifier5 = "29",
			ProductServiceID5 = "9",
			ProductServiceIDQualifier6 = "Oe",
			ProductServiceID6 = "2",
			ProductServiceIDQualifier7 = "CX",
			ProductServiceID7 = "U",
			ProductServiceIDQualifier8 = "wF",
			ProductServiceID8 = "I",
			ProductServiceIDQualifier9 = "Be",
			ProductServiceID9 = "s",
			ProductServiceIDQualifier10 = "HS",
			ProductServiceID10 = "5",
			AgencyQualifierCode = "b8",
			SourceSubqualifier = "f",
			IndustryCode = "Z",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cb", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "MQ", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "MQ", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ce2", "7ZB2CV", true)]
	[InlineData("ce2", "", false)]
	[InlineData("", "7ZB2CV", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oH", "k", true)]
	[InlineData("oH", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xq", "d", true)]
	[InlineData("Xq", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kn", "D", true)]
	[InlineData("kn", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A8", "y", true)]
	[InlineData("A8", "", false)]
	[InlineData("", "y", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("29", "9", true)]
	[InlineData("29", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Oe", "2", true)]
	[InlineData("Oe", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CX", "U", true)]
	[InlineData("CX", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wF", "I", true)]
	[InlineData("wF", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Be", "s", true)]
	[InlineData("Be", "", false)]
	[InlineData("", "s", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HS", "5", true)]
	[InlineData("HS", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b8", "f", true)]
	[InlineData("b8", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "Cb";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
