using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W66*lu*s*t*ZK*W*0j*A*x*r*i5";

		var expected = new W66_WarehouseCarrierInformation()
		{
			ShipmentMethodOfPayment = "lu",
			TransportationMethodTypeCode = "s",
			PalletExchangeCode = "t",
			UnitLoadOptionCode = "ZK",
			Routing = "W",
			FOBPointCode = "0j",
			FOBPoint = "A",
			CODMethodOfPaymentCode = "x",
			Amount = "r",
			StandardCarrierAlphaCode = "i5",
		};

		var actual = Map.MapObject<W66_WarehouseCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lu", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "s";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "x";
			subject.Amount = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPayment = "lu";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "x";
			subject.Amount = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "r", true)]
	[InlineData("x", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredCODMethodOfPaymentCode(string cODMethodOfPaymentCode, string amount, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPayment = "lu";
		subject.TransportationMethodTypeCode = "s";
		//Test Parameters
		subject.CODMethodOfPaymentCode = cODMethodOfPaymentCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
