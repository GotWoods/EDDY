using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ACKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACK*K9*5*Bc*n99*m2BsUH*F*l0*h*Mf*w*Ii*N*sz*b*by*h*Mn*z*4c*r*hZ*9*Wu*R*zQ*s";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "K9",
			Quantity = 5,
			UnitOfMeasurementCode = "Bc",
			DateTimeQualifier = "n99",
			Date = "m2BsUH",
			RequestReferenceNumber = "F",
			ProductServiceIDQualifier = "l0",
			ProductServiceID = "h",
			ProductServiceIDQualifier2 = "Mf",
			ProductServiceID2 = "w",
			ProductServiceIDQualifier3 = "Ii",
			ProductServiceID3 = "N",
			ProductServiceIDQualifier4 = "sz",
			ProductServiceID4 = "b",
			ProductServiceIDQualifier5 = "by",
			ProductServiceID5 = "h",
			ProductServiceIDQualifier6 = "Mn",
			ProductServiceID6 = "z",
			ProductServiceIDQualifier7 = "4c",
			ProductServiceID7 = "r",
			ProductServiceIDQualifier8 = "hZ",
			ProductServiceID8 = "9",
			ProductServiceIDQualifier9 = "Wu",
			ProductServiceID9 = "R",
			ProductServiceIDQualifier10 = "zQ",
			ProductServiceID10 = "s",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K9", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
