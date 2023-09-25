using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W66*Aa*H*j*OZ*D*KS*l*2*i";

		var expected = new W66_WarehouseCarrierInformation()
		{
			ShipmentMethodOfPayment = "Aa",
			TransportationMethodTypeCode = "H",
			PalletExchangeCode = "j",
			UnitLoadOptionCode = "OZ",
			Routing = "D",
			FOBPointCode = "KS",
			FOBPoint = "l",
			CODMethodOfPaymentCode = "2",
			Amount = "i",
		};

		var actual = Map.MapObject<W66_WarehouseCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Aa", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "H";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPayment = "Aa";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
