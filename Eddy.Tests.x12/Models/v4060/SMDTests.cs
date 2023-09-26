using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class SMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMD*0Y*Hl*Z";

		var expected = new SMD_ConsolidatedShipmentManifestData()
		{
			ServiceLevelCode = "0Y",
			ShipmentMethodOfPayment = "Hl",
			PickupOrDeliveryCode = "Z",
		};

		var actual = Map.MapObject<SMD_ConsolidatedShipmentManifestData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0Y", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ShipmentMethodOfPayment = "Hl";
		//Test Parameters
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hl", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ServiceLevelCode = "0Y";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
