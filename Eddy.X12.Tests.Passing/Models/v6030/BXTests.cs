using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BX*uP*Y*TP*k*No*9*5*s*0*6*z6*x*p*Cc";

		var expected = new BX_GeneralShipmentInformation()
		{
			TransactionSetPurposeCode = "uP",
			TransportationMethodTypeCode = "Y",
			ShipmentMethodOfPaymentCode = "TP",
			ShipmentIdentificationNumber = "k",
			StandardCarrierAlphaCode = "No",
			WeightUnitCode = "9",
			ShipmentQualifier = "5",
			SectionSevenCode = "s",
			CapacityLoadCode = "0",
			StatusReportRequestCode = "6",
			CustomsDocumentationHandlingCode = "z6",
			ConfidentialBillingRequestCode = "x",
			GoodsAndServicesTaxReasonCode = "p",
			ApplicationTypeCode = "Cc",
		};

		var actual = Map.MapObject<BX_GeneralShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransportationMethodTypeCode = "Y";
		subject.ShipmentMethodOfPaymentCode = "TP";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "uP";
		subject.ShipmentMethodOfPaymentCode = "TP";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TP", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "uP";
		subject.TransportationMethodTypeCode = "Y";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
