using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*zQ*Su*JcoHjO*24215*r*d*d*96*0*E*V*j*L*i*9*8*S*98*ZPJ*TxD";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "zQ",
			StandardCarrierAlphaCode = "Su",
			StandardPointLocationCode = "JcoHjO",
			RepetitivePatternNumber = 24215,
			ReferencedPatternIdentifier = "r",
			ShipmentIdentificationNumber = "d",
			WeightUnitCode = "d",
			ShipmentMethodOfPayment = "96",
			StatusReportRequestCode = "0",
			ShipmentQualifier = "E",
			BillingCode = "V",
			SectionSevenCode = "j",
			CapacityLoadCode = "L",
			ConfidentialBillingRequestCode = "i",
			ReportTransmissionCode = "9",
			TotalEquipment = 8,
			ShipmentWeightCode = "S",
			CustomsDocumentationHandlingCode = "98",
			TransportationTermsCode = "ZPJ",
			PaymentMethodCode = "TxD",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(24215, "r", false)]
	[InlineData(24215, "", true)]
	[InlineData(0, "r", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = "96";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("96", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
