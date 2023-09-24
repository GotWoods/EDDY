using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*Nw*j*ZF*T*Ei*42*M*9*m*b*Y*Z*so*uU*B*Io*W";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "Nw",
			TransportationMethodTypeCode = "j",
			CountryCode = "ZF",
			VesselCode = "T",
			VesselName = "Ei",
			FlightVoyageNumber = "42",
			ReferenceIdentification = "M",
			Quantity = 9,
			ManifestTypeCode = "m",
			VesselCodeQualifier = "b",
			YesNoConditionOrResponseCode = "Y",
			ReferenceIdentification2 = "Z",
			TransactionSetPurposeCode = "so",
			ApplicationType = "uU",
			AmendmentTypeCode = "B",
			AmendmentCode = "Io",
			ManifestTypeCode2 = "W",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "b", true)]
	[InlineData("T", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "B";
			subject.AmendmentCode = "Io";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Io", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Io", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "T";
			subject.VesselCodeQualifier = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
