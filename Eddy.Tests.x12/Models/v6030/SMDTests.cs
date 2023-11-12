using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMD*CL*9z*O";

		var expected = new SMD_ConsolidatedShipmentManifestData()
		{
			ServiceLevelCode = "CL",
			ShipmentMethodOfPaymentCode = "9z",
			PickupOrDeliveryCode = "O",
		};

		var actual = Map.MapObject<SMD_ConsolidatedShipmentManifestData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CL", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ShipmentMethodOfPaymentCode = "9z";
		//Test Parameters
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9z", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ServiceLevelCode = "CL";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
