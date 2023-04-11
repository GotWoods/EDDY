using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*uH*j*4M*D*qL*1K*3*1*r*A*q*p*Sc*16*r*dw*k";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "uH",
			TransportationMethodTypeCode = "j",
			CountryCode = "4M",
			VesselCode = "D",
			VesselName = "qL",
			FlightVoyageNumber = "1K",
			ReferenceIdentification = "3",
			Quantity = 1,
			ManifestTypeCode = "r",
			VesselCodeQualifier = "A",
			YesNoConditionOrResponseCode = "q",
			ReferenceIdentification2 = "p",
			TransactionSetPurposeCode = "Sc",
			ApplicationTypeCode = "16",
			AmendmentTypeCode = "r",
			AmendmentCode = "dw",
			ManifestTypeCode2 = "k",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D", "A", true)]
	[InlineData("", "A", false)]
	[InlineData("D", "", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("r", "dw", true)]
	[InlineData("", "dw", false)]
	[InlineData("r", "", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
