using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class ACKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACK*st*8*Bu*LO0*NRi64OF4*2*Ut*4*EN*u*PR*Y*VR*4*Im*V*Qc*N*GQ*W*3a*Z*A3*w*m5*d*r5*d*E";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "st",
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "Bu",
			DateTimeQualifier = "LO0",
			Date = "NRi64OF4",
			RequestReferenceNumber = "2",
			ProductServiceIDQualifier = "Ut",
			ProductServiceID = "4",
			ProductServiceIDQualifier2 = "EN",
			ProductServiceID2 = "u",
			ProductServiceIDQualifier3 = "PR",
			ProductServiceID3 = "Y",
			ProductServiceIDQualifier4 = "VR",
			ProductServiceID4 = "4",
			ProductServiceIDQualifier5 = "Im",
			ProductServiceID5 = "V",
			ProductServiceIDQualifier6 = "Qc",
			ProductServiceID6 = "N",
			ProductServiceIDQualifier7 = "GQ",
			ProductServiceID7 = "W",
			ProductServiceIDQualifier8 = "3a",
			ProductServiceID8 = "Z",
			ProductServiceIDQualifier9 = "A3",
			ProductServiceID9 = "w",
			ProductServiceIDQualifier10 = "m5",
			ProductServiceID10 = "d",
			AgencyQualifierCode = "r5",
			SourceSubqualifier = "d",
			IndustryCode = "E",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("st", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Bu", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Bu", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LO0", "NRi64OF4", true)]
	[InlineData("LO0", "", false)]
	[InlineData("", "NRi64OF4", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ut", "4", true)]
	[InlineData("Ut", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("EN", "u", true)]
	[InlineData("EN", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PR", "Y", true)]
	[InlineData("PR", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VR", "4", true)]
	[InlineData("VR", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Im", "V", true)]
	[InlineData("Im", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qc", "N", true)]
	[InlineData("Qc", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GQ", "W", true)]
	[InlineData("GQ", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3a", "Z", true)]
	[InlineData("3a", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A3", "w", true)]
	[InlineData("A3", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m5", "d", true)]
	[InlineData("m5", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r5", "d", true)]
	[InlineData("r5", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "st";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
