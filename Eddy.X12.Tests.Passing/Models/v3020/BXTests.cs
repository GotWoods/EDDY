using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BX*SO*F*Pp*V*Mb*p*8*b*z*E*jJ*n*k";

		var expected = new BX_GeneralShipmentInformation()
		{
			TransactionSetPurposeCode = "SO",
			TransportationMethodTypeCode = "F",
			ShipmentMethodOfPayment = "Pp",
			ShipmentIdentificationNumber = "V",
			StandardCarrierAlphaCode = "Mb",
			WeightUnitQualifier = "p",
			ShipmentQualifier = "8",
			SectionSevenCode = "b",
			CapacityLoadCode = "z",
			StatusReportRequestCode = "E",
			CustomsDocumentationHandlingCode = "jJ",
			ConfidentialBillingRequestCode = "n",
			GoodsAndServicesTaxReasonCode = "k",
		};

		var actual = Map.MapObject<BX_GeneralShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SO", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransportationMethodTypeCode = "F";
		subject.ShipmentMethodOfPayment = "Pp";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "SO";
		subject.ShipmentMethodOfPayment = "Pp";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pp", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "SO";
		subject.TransportationMethodTypeCode = "F";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
