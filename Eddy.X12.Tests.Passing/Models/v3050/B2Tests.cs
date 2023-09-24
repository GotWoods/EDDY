using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*y6*8t*vrCbWg*96583*C*I*c*rM*m*m*Y*a*m*r*V*5*i*qj*pho";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "y6",
			StandardCarrierAlphaCode = "8t",
			StandardPointLocationCode = "vrCbWg",
			RepetitivePatternNumber = 96583,
			ReferencedPatternIdentifier = "C",
			ShipmentIdentificationNumber = "I",
			WeightUnitCode = "c",
			ShipmentMethodOfPayment = "rM",
			StatusReportRequestCode = "m",
			ShipmentQualifier = "m",
			BillingCode = "Y",
			SectionSevenCode = "a",
			CapacityLoadCode = "m",
			ConfidentialBillingRequestCode = "r",
			ReportTransmissionCode = "V",
			TotalEquipment = 5,
			ShipmentWeightCode = "i",
			CustomsDocumentationHandlingCode = "qj",
			TransportationTermsCode = "pho",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(96583, "C", false)]
	[InlineData(96583, "", true)]
	[InlineData(0, "C", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = "rM";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rM", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
