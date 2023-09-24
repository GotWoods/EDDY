using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMD*px*je*S";

		var expected = new SMD_ConsolidatedShipmentManifestData()
		{
			ServiceLevelCode = "px",
			ShipmentMethodOfPaymentCode = "je",
			PickupOrDeliveryCode = "S",
		};

		var actual = Map.MapObject<SMD_ConsolidatedShipmentManifestData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("px", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		subject.ShipmentMethodOfPaymentCode = "je";
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("je", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		subject.ServiceLevelCode = "px";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
