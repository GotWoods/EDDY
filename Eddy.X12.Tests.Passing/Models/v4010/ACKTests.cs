using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ACKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACK*9n*7*T9*pqy*Z3hWJKPo*h*O3*2*2T*m*ho*P*55*G*jh*0*Xy*k*24*O*p1*i*7p*0*1l*A*h9*A*d";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "9n",
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "T9",
			DateTimeQualifier = "pqy",
			Date = "Z3hWJKPo",
			RequestReferenceNumber = "h",
			ProductServiceIDQualifier = "O3",
			ProductServiceID = "2",
			ProductServiceIDQualifier2 = "2T",
			ProductServiceID2 = "m",
			ProductServiceIDQualifier3 = "ho",
			ProductServiceID3 = "P",
			ProductServiceIDQualifier4 = "55",
			ProductServiceID4 = "G",
			ProductServiceIDQualifier5 = "jh",
			ProductServiceID5 = "0",
			ProductServiceIDQualifier6 = "Xy",
			ProductServiceID6 = "k",
			ProductServiceIDQualifier7 = "24",
			ProductServiceID7 = "O",
			ProductServiceIDQualifier8 = "p1",
			ProductServiceID8 = "i",
			ProductServiceIDQualifier9 = "7p",
			ProductServiceID9 = "0",
			ProductServiceIDQualifier10 = "1l",
			ProductServiceID10 = "A",
			AgencyQualifierCode = "h9",
			SourceSubqualifier = "A",
			IndustryCode = "d",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9n", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "T9", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "T9", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pqy", "Z3hWJKPo", true)]
	[InlineData("pqy", "", false)]
	[InlineData("", "Z3hWJKPo", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O3", "2", true)]
	[InlineData("O3", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2T", "m", true)]
	[InlineData("2T", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ho", "P", true)]
	[InlineData("ho", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("55", "G", true)]
	[InlineData("55", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jh", "0", true)]
	[InlineData("jh", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xy", "k", true)]
	[InlineData("Xy", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("24", "O", true)]
	[InlineData("24", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p1", "i", true)]
	[InlineData("p1", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7p", "0", true)]
	[InlineData("7p", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1l", "A", true)]
	[InlineData("1l", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h9", "A", true)]
	[InlineData("h9", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = "9n";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
