using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class W66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W66*cm*T*a*HI*u*EW*i*x*y*my";

		var expected = new W66_WarehouseCarrierInformation()
		{
			ShipmentMethodOfPaymentCode = "cm",
			TransportationMethodTypeCode = "T",
			PalletExchangeCode = "a",
			UnitLoadOptionCode = "HI",
			Routing = "u",
			FOBPointCode = "EW",
			FOBPoint = "i",
			CODMethodOfPaymentCode = "x",
			Amount = "y",
			StandardCarrierAlphaCode = "my",
		};

		var actual = Map.MapObject<W66_WarehouseCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cm", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "x";
			subject.Amount = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPaymentCode = "cm";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.CODMethodOfPaymentCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.CODMethodOfPaymentCode = "x";
			subject.Amount = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "y", true)]
	[InlineData("x", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredCODMethodOfPaymentCode(string cODMethodOfPaymentCode, string amount, bool isValidExpected)
	{
		var subject = new W66_WarehouseCarrierInformation();
		//Required fields
		subject.ShipmentMethodOfPaymentCode = "cm";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.CODMethodOfPaymentCode = cODMethodOfPaymentCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
