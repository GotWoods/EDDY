using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMD*er*XX*l";

		var expected = new SMD_ConsolidatedShipmentManifestData()
		{
			ServiceLevelCode = "er",
			ShipmentMethodOfPayment = "XX",
			PickUpOrDeliveryCode = "l",
		};

		var actual = Map.MapObject<SMD_ConsolidatedShipmentManifestData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("er", true)]
	public void Validation_RequiredServiceLevelCode(string serviceLevelCode, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ShipmentMethodOfPayment = "XX";
		//Test Parameters
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XX", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new SMD_ConsolidatedShipmentManifestData();
		//Required fields
		subject.ServiceLevelCode = "er";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
