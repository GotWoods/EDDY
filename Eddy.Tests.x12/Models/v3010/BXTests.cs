using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BX*PZ*m*81*L*jT*e*Y*A*8*G*ie*A";

		var expected = new BX_GeneralShipmentInformation()
		{
			TransactionSetPurposeCode = "PZ",
			TransportationMethodTypeCode = "m",
			ShipmentMethodOfPayment = "81",
			ShipmentIdentificationNumber = "L",
			StandardCarrierAlphaCode = "jT",
			WeightUnitQualifier = "e",
			ShipmentQualifier = "Y",
			SectionSevenCode = "A",
			CapacityLoadCode = "8",
			StatusReportRequestCode = "G",
			CustomsDocumentationHandlingCode = "ie",
			ConfidentialBillingRequestCode = "A",
		};

		var actual = Map.MapObject<BX_GeneralShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransportationMethodTypeCode = "m";
		subject.ShipmentMethodOfPayment = "81";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "PZ";
		subject.ShipmentMethodOfPayment = "81";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("81", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BX_GeneralShipmentInformation();
		subject.TransactionSetPurposeCode = "PZ";
		subject.TransportationMethodTypeCode = "m";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
