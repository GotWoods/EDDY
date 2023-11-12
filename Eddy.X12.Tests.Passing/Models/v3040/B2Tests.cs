using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*IW*Br*vWHcae*86554*i*R*j*Yf*J*T*6*f*4*z*p*2*g*hi*gTs";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "IW",
			StandardCarrierAlphaCode = "Br",
			StandardPointLocationCode = "vWHcae",
			RepetitivePatternNumber = 86554,
			ReferencedPatternIdentifier = "i",
			ShipmentIdentificationNumber = "R",
			WeightUnitCode = "j",
			ShipmentMethodOfPayment = "Yf",
			StatusReportRequestCode = "J",
			ShipmentQualifier = "T",
			BillingCode = "6",
			SectionSevenCode = "f",
			CapacityLoadCode = "4",
			ConfidentialBillingRequestCode = "z",
			FreightBillDispositionCode = "p",
			TotalEquipment = 2,
			ShipmentWeightCode = "g",
			CustomsDocumentationHandlingCode = "hi",
			TransportationTermsCode = "gTs",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(86554, "i", false)]
	[InlineData(86554, "", true)]
	[InlineData(0, "i", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = "Yf";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yf", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
