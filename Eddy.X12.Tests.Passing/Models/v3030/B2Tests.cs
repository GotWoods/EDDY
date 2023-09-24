using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B2*v0*NV*wD8VVg*88537*B*2*t*Kh*P*1*1*Q*b*C*I*4*x*Na";

		var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
		{
			TariffServiceCode = "v0",
			StandardCarrierAlphaCode = "NV",
			StandardPointLocationCode = "wD8VVg",
			RepetitivePatternNumber = 88537,
			ReferencedPatternIdentifier = "B",
			ShipmentIdentificationNumber = "2",
			WeightUnitCode = "t",
			ShipmentMethodOfPayment = "Kh",
			StatusReportRequestCode = "P",
			ShipmentQualifier = "1",
			BillingCode = "1",
			SectionSevenCode = "Q",
			CapacityLoadCode = "b",
			ConfidentialBillingRequestCode = "C",
			FreightBillDispositionCode = "I",
			TotalEquipment = 4,
			ShipmentWeightCode = "x",
			CustomsDocumentationHandlingCode = "Na",
		};

		var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.ShipmentMethodOfPayment = "Kh";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(88537, "B", false)]
	[InlineData(88537, "", true)]
	[InlineData(0, "B", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.StandardCarrierAlphaCode = "NV";
		subject.ShipmentMethodOfPayment = "Kh";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kh", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
		subject.StandardCarrierAlphaCode = "NV";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
