using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*bB*Vz*oZC1TE*L*v*As*U*4*T*HF*Bse*eX4";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "bB",
			StandardCarrierAlphaCode = "Vz",
			StandardPointLocationCode = "oZC1TE",
			ShipmentIdentificationNumber = "L",
			WeightUnitCode = "v",
			ShipmentMethodOfPaymentCode = "As",
			ShipmentQualifier = "U",
			TotalEquipment = 4,
			ShipmentWeightCode = "T",
			CustomsDocumentationHandlingCode = "HF",
			TransportationTermsCode = "Bse",
			PaymentMethodCode = "eX4",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("As", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
