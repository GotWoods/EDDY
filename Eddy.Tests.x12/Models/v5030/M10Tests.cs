using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*s2*a*6L*a*tT*PP*M*7*V*e*t*s*tb*un*c*SA*4";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "s2",
			TransportationMethodTypeCode = "a",
			CountryCode = "6L",
			VesselCode = "a",
			VesselName = "tT",
			FlightVoyageNumber = "PP",
			ReferenceIdentification = "M",
			Quantity = 7,
			ManifestTypeCode = "V",
			VesselCodeQualifier = "e",
			YesNoConditionOrResponseCode = "t",
			ReferenceIdentification2 = "s",
			TransactionSetPurposeCode = "tb",
			ApplicationType = "un",
			AmendmentTypeCode = "c",
			AmendmentCode = "SA",
			ManifestTypeCode2 = "4",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s2", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "a";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "tT";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "a";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "c";
			subject.AmendmentCode = "SA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "s2";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "tT";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "a";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "c";
			subject.AmendmentCode = "SA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "e", true)]
	[InlineData("a", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "s2";
		subject.TransportationMethodTypeCode = "a";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "tT";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "c";
			subject.AmendmentCode = "SA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("tT", "a", true)]
	[InlineData("tT", "", true)]
	[InlineData("", "a", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "s2";
		subject.TransportationMethodTypeCode = "a";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "a";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "c";
			subject.AmendmentCode = "SA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "SA", true)]
	[InlineData("c", "", false)]
	[InlineData("", "SA", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "s2";
		subject.TransportationMethodTypeCode = "a";
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;
			subject.VesselName = "tT";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "a";
			subject.VesselCodeQualifier = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
