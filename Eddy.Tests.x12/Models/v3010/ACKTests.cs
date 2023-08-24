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
		string x12Line = "ACK*yo*6*y1*pgM*DxIRik*2*6U*K*bc*L*AU*H*RW*D*1o*1*CJ*W*DK*8*ll*2*x1*C*gf*n";

		var expected = new ACK_LineItemAcknowledgment()
		{
			LineItemStatusCode = "yo",
			Quantity = 6,
			UnitOfMeasurementCode = "y1",
			DateTimeQualifier = "pgM",
			Date = "DxIRik",
			RequestReferenceNumber = "2",
			ProductServiceIDQualifier = "6U",
			ProductServiceID = "K",
			ProductServiceIDQualifier2 = "bc",
			ProductServiceID2 = "L",
			ProductServiceIDQualifier3 = "AU",
			ProductServiceID3 = "H",
			ProductServiceIDQualifier4 = "RW",
			ProductServiceID4 = "D",
			ProductServiceIDQualifier5 = "1o",
			ProductServiceID5 = "1",
			ProductServiceIDQualifier6 = "CJ",
			ProductServiceID6 = "W",
			ProductServiceIDQualifier7 = "DK",
			ProductServiceID7 = "8",
			ProductServiceIDQualifier8 = "ll",
			ProductServiceID8 = "2",
			ProductServiceIDQualifier9 = "x1",
			ProductServiceID9 = "C",
			ProductServiceIDQualifier10 = "gf",
			ProductServiceID10 = "n",
		};

		var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yo", true)]
	public void Validation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
	{
		var subject = new ACK_LineItemAcknowledgment();
		subject.LineItemStatusCode = lineItemStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
