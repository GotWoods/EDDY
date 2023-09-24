using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*fT*l*rv*a*dg*W3*T*1*8*P*u*M*TA*EI*X*ut*S";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "fT",
			TransportationMethodTypeCode = "l",
			CountryCode = "rv",
			VesselCode = "a",
			VesselName = "dg",
			FlightVoyageNumber = "W3",
			ReferenceIdentification = "T",
			Quantity = 1,
			ManifestTypeCode = "8",
			VesselCodeQualifier = "P",
			YesNoConditionOrResponseCode = "u",
			ReferenceIdentification2 = "M",
			TransactionSetPurposeCode = "TA",
			ApplicationTypeCode = "EI",
			AmendmentTypeCode = "X",
			AmendmentCode = "ut",
			ManifestTypeCode2 = "S",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "P", true)]
	[InlineData("a", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "X";
			subject.AmendmentCode = "ut";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "ut", true)]
	[InlineData("X", "", false)]
	[InlineData("", "ut", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "a";
			subject.VesselCodeQualifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
