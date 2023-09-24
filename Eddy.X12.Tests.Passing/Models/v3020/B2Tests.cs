using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*SU*5f*YshOFf*58276*F*l*l*Gb*J*c*A*V*n*i*K*7*T*s1";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "SU",
			StandardCarrierAlphaCode = "5f",
			StandardPointLocationCode = "YshOFf",
			RepetitivePatternNumber = 58276,
			ReferencedPatternIdentifier = "F",
			ShipmentIdentificationNumber = "l",
			WeightUnitQualifier = "l",
			ShipmentMethodOfPayment = "Gb",
			StatusReportRequestCode = "J",
			ShipmentQualifier = "c",
			BillingCode = "A",
			SectionSevenCode = "V",
			CapacityLoadCode = "n",
			ConfidentialBillingRequestCode = "i",
			FreightBillDispositionCode = "K",
			TotalEquipment = 7,
			ShipmentWeightCode = "T",
			CustomsDocumentationHandlingCode = "s1",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5f", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = "Gb";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(58276, "F", false)]
	[InlineData(58276, "", true)]
	[InlineData(0, "F", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.StandardCarrierAlphaCode = "5f";
		subject.ShipmentMethodOfPayment = "Gb";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gb", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.StandardCarrierAlphaCode = "5f";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
