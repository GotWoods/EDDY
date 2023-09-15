using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*Fs*0*nH*n*Ld*A4*5*6*r*9*z*r*OD*TO*J*jC*U";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "Fs",
			TransportationMethodTypeCode = "0",
			CountryCode = "nH",
			VesselCode = "n",
			VesselName = "Ld",
			FlightVoyageNumber = "A4",
			ReferenceIdentification = "5",
			Quantity = 6,
			ManifestTypeCode = "r",
			VesselCodeQualifier = "9",
			YesNoConditionOrResponseCode = "z",
			ReferenceIdentification2 = "r",
			TransactionSetPurposeCode = "OD",
			ApplicationTypeCode = "TO",
			AmendmentTypeCode = "J",
			AmendmentCode = "jC",
			ManifestTypeCode2 = "U",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "9", true)]
	[InlineData("n", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "J";
			subject.AmendmentCode = "jC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "jC", true)]
	[InlineData("J", "", false)]
	[InlineData("", "jC", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "n";
			subject.VesselCodeQualifier = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
