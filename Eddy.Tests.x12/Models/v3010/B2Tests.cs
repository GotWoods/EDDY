using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*PPB*j0*h3Xmr0*31967*W*y*r*VO*U*R*j*k*V*f*6*7*q*KJ";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TransactionSetIdentifierCode = "PPB",
			StandardCarrierAlphaCode = "j0",
			StandardPointLocationCode = "h3Xmr0",
			RepetitivePatternNumber = 31967,
			ReferencedPatternIdentifier = "W",
			ShipmentIdentificationNumber = "y",
			WeightUnitQualifier = "r",
			ShipmentMethodOfPayment = "VO",
			StatusReportRequestCode = "U",
			ShipmentQualifier = "R",
			BillingCode = "j",
			SectionSevenCode = "k",
			CapacityLoadCode = "V",
			ConfidentialBillingRequestCode = "f",
			FreightBillDispositionCode = "6",
			TotalEquipment = 7,
			ShipmentWeightCode = "q",
			CustomsDocumentationHandlingCode = "KJ",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VO", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
