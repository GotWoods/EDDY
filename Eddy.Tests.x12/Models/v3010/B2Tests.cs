using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*5m1*fS*LJoGsJ*36696*B*0*Z*u6*j*8*V*u*g*x*V*1*6*SN";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TransactionSetIdentifierCode = "5m1",
			StandardCarrierAlphaCode = "fS",
			StandardPointLocationCode = "LJoGsJ",
			RepetitivePatternNumber = 36696,
			ReferencedPatternIdentifier = "B",
			ShipmentIdentificationNumber = "0",
			WeightUnitQualifier = "Z",
			ShipmentMethodOfPayment = "u6",
			StatusReportRequestCode = "j",
			ShipmentQualifier = "8",
			BillingCode = "V",
			SectionSevenCode = "u",
			CapacityLoadCode = "g",
			ConfidentialBillingRequestCode = "x",
			FreightBillDispositionCode = "V",
			TotalEquipment = 1,
			ShipmentWeightCode = "6",
			CustomsDocumentationHandlingCode = "SN",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u6", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
