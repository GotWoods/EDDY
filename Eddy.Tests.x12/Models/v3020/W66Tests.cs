using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W66*oI*d*N*gE*y*B3*T*h*s";

		var expected = new W66_WarehouseCarrierInformation()
		{
			ShipmentMethodOfPayment = "oI",
			TransportationMethodTypeCode = "d",
			PalletExchangeCode = "N",
			UnitLoadOptionCode = "gE",
			Routing = "y",
			FOBPointCode = "B3",
			FOBPoint = "T",
			CODMethodOfPaymentCode = "h",
			Amount = "s",
		};

		var actual = Map.MapObject<W66_WarehouseCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oI", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "d";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "h";
			subject.Amount = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPayment = "oI";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "h";
			subject.Amount = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "s", true)]
	[InlineData("h", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredCODMethodOfPaymentCode(string cODMethodOfPaymentCode, string amount, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPayment = "oI";
		subject.TransportationMethodTypeCode = "d";
		//Test Parameters
		subject.CODMethodOfPaymentCode = cODMethodOfPaymentCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
