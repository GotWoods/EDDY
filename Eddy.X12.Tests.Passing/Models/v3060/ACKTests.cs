using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ACKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACK*3Y*5*rp*AZJ*51EXJP*p*6N*h*oG*O*IH*f*lA*D*3G*J*NL*F*k7*B*Uj*Z*yq*m*sX*S*gZ*8*B";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "3Y",
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "rp",
			DateTimeQualifier = "AZJ",
			Date = "51EXJP",
			RequestReferenceNumber = "p",
			ProductServiceIDQualifier = "6N",
			ProductServiceID = "h",
			ProductServiceIDQualifier2 = "oG",
			ProductServiceID2 = "O",
			ProductServiceIDQualifier3 = "IH",
			ProductServiceID3 = "f",
			ProductServiceIDQualifier4 = "lA",
			ProductServiceID4 = "D",
			ProductServiceIDQualifier5 = "3G",
			ProductServiceID5 = "J",
			ProductServiceIDQualifier6 = "NL",
			ProductServiceID6 = "F",
			ProductServiceIDQualifier7 = "k7",
			ProductServiceID7 = "B",
			ProductServiceIDQualifier8 = "Uj",
			ProductServiceID8 = "Z",
			ProductServiceIDQualifier9 = "yq",
			ProductServiceID9 = "m",
			ProductServiceIDQualifier10 = "sX",
			ProductServiceID10 = "S",
			AgencyQualifierCode = "gZ",
			SourceSubqualifier = "8",
			IndustryCode = "B",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3Y", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "rp", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "rp", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AZJ", "51EXJP", true)]
	[InlineData("AZJ", "", false)]
	[InlineData("", "51EXJP", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6N", "h", true)]
	[InlineData("6N", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oG", "O", true)]
	[InlineData("oG", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IH", "f", true)]
	[InlineData("IH", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lA", "D", true)]
	[InlineData("lA", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3G", "J", true)]
	[InlineData("3G", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NL", "F", true)]
	[InlineData("NL", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k7", "B", true)]
	[InlineData("k7", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Uj", "Z", true)]
	[InlineData("Uj", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yq", "m", true)]
	[InlineData("yq", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sX", "S", true)]
	[InlineData("sX", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gZ", "8", true)]
	[InlineData("gZ", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "3Y";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
