using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BX*RE*I*oX*e*w6*G*A*V*I*3*cz*i*6*Qh";

		var expected = new BX_GeneralShipmentInformation()
		{
			TransactionSetPurposeCode = "RE",
			TransportationMethodTypeCode = "I",
			ShipmentMethodOfPaymentCode = "oX",
			ShipmentIdentificationNumber = "e",
			StandardCarrierAlphaCode = "w6",
			WeightUnitCode = "G",
			ShipmentQualifier = "A",
			SectionSevenCode = "V",
			CapacityLoadCode = "I",
			StatusReportRequestCode = "3",
			CustomsDocumentationHandlingCode = "cz",
			ConfidentialBillingRequestCode = "i",
			GoodsAndServicesTaxReasonCode = "6",
			ApplicationTypeCode = "Qh",
		};

		var actual = Map.MapObject<BX_GeneralShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RE", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransportationMethodTypeCode = "I";
		subject.ShipmentMethodOfPaymentCode = "oX";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "RE";
		subject.ShipmentMethodOfPaymentCode = "oX";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oX", true)]
	public void Validatation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "RE";
		subject.TransportationMethodTypeCode = "I";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
