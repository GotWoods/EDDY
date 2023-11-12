using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BX*jj*e*zY*Z*F6*K*j*u*8*A*3e*V*7*rl";

		var expected = new BX_GeneralShipmentInformation()
		{
			TransactionSetPurposeCode = "jj",
			TransportationMethodTypeCode = "e",
			ShipmentMethodOfPayment = "zY",
			ShipmentIdentificationNumber = "Z",
			StandardCarrierAlphaCode = "F6",
			WeightUnitCode = "K",
			ShipmentQualifier = "j",
			SectionSevenCode = "u",
			CapacityLoadCode = "8",
			StatusReportRequestCode = "A",
			CustomsDocumentationHandlingCode = "3e",
			ConfidentialBillingRequestCode = "V",
			GoodsAndServicesTaxReasonCode = "7",
			ApplicationType = "rl",
		};

		var actual = Map.MapObject<BX_GeneralShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransportationMethodTypeCode = "e";
		subject.ShipmentMethodOfPayment = "zY";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "jj";
		subject.ShipmentMethodOfPayment = "zY";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zY", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "jj";
		subject.TransportationMethodTypeCode = "e";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
