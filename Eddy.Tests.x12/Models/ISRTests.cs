using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISR*2a*PJWNlLFG*qJq";

		var expected = new ISR_ItemStatusReport()
		{
			ShipmentOrderStatusCode = "2a",
			Date = "PJWNlLFG",
			StatusReasonCode = "qJq",
		};

		var actual = Map.MapObject<ISR_ItemStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2a", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new ISR_ItemStatusReport();
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
