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
		string x12Line = "ACK*XJ*9*MG*fNr*HcAUqn*D*2U*n*Ha*e*gy*L*mC*m*fO*L*mW*C*wN*d*0K*L*2T*j*mm*r";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "XJ",
			Quantity = 9,
			UnitOfMeasurementCode = "MG",
			DateTimeQualifier = "fNr",
			Date = "HcAUqn",
			RequestReferenceNumber = "D",
			ProductServiceIDQualifier = "2U",
			ProductServiceID = "n",
			ProductServiceIDQualifier2 = "Ha",
			ProductServiceID2 = "e",
			ProductServiceIDQualifier3 = "gy",
			ProductServiceID3 = "L",
			ProductServiceIDQualifier4 = "mC",
			ProductServiceID4 = "m",
			ProductServiceIDQualifier5 = "fO",
			ProductServiceID5 = "L",
			ProductServiceIDQualifier6 = "mW",
			ProductServiceID6 = "C",
			ProductServiceIDQualifier7 = "wN",
			ProductServiceID7 = "d",
			ProductServiceIDQualifier8 = "0K",
			ProductServiceID8 = "L",
			ProductServiceIDQualifier9 = "2T",
			ProductServiceID9 = "j",
			ProductServiceIDQualifier10 = "mm",
			ProductServiceID10 = "r",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XJ", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
