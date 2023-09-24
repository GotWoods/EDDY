using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W66*tS*n*s*RL*7*mJ*k*W*0*oZ";

		var expected = new W66_WarehouseCarrierInformation()
		{
			ShipmentMethodOfPaymentCode = "tS",
			TransportationMethodTypeCode = "n",
			PalletExchangeCode = "s",
			UnitLoadOptionCode = "RL",
			Routing = "7",
			FOBPointCode = "mJ",
			FOBPoint = "k",
			CODMethodOfPaymentCode = "W",
			Amount = "0",
			StandardCarrierAlphaCode = "oZ",
		};

		var actual = Map.MapObject<W66_WarehouseCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tS", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		subject.TransportationMethodTypeCode = "n";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		subject.ShipmentMethodOfPaymentCode = "tS";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("W", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("W", "", false)]
	public void Validation_AllAreRequiredCODMethodOfPaymentCode(string cODMethodOfPaymentCode, string amount, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		subject.ShipmentMethodOfPaymentCode = "tS";
		subject.TransportationMethodTypeCode = "n";
		subject.CODMethodOfPaymentCode = cODMethodOfPaymentCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
