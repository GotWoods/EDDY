using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ISRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISR*Vm*CauUCA*aZQ";

		var expected = new ISR_ItemStatusReport()
		{
			ShipmentOrderStatusCode = "Vm",
			Date = "CauUCA",
			StatusReasonCode = "aZQ",
		};

		var actual = Map.MapObject<ISR_ItemStatusReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vm", true)]
	public void Validation_RequiredShipmentOrderStatusCode(string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new ISR_ItemStatusReport();
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
