using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*e6*P*Gq*K*nM*qb*3*7*X*T*v*F*7L*jM";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "e6",
			TransportationMethodTypeCode = "P",
			CountryCode = "Gq",
			VesselCode = "K",
			VesselName = "nM",
			FlightVoyageNumber = "qb",
			ReferenceIdentification = "3",
			Quantity = 7,
			ManifestTypeCode = "X",
			VesselCodeQualifier = "T",
			YesNoConditionOrResponseCode = "v",
			ReferenceIdentification2 = "F",
			TransactionSetPurposeCode = "7L",
			ApplicationType = "jM",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e6", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Gq";
		subject.FlightVoyageNumber = "qb";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "nM";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "K";
			subject.VesselCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "e6";
		subject.CountryCode = "Gq";
		subject.FlightVoyageNumber = "qb";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "nM";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "K";
			subject.VesselCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gq", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "e6";
		subject.TransportationMethodTypeCode = "P";
		subject.FlightVoyageNumber = "qb";
		subject.CountryCode = countryCode;
			subject.VesselName = "nM";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "K";
			subject.VesselCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "T", true)]
	[InlineData("K", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "e6";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Gq";
		subject.FlightVoyageNumber = "qb";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "nM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("nM", "K", true)]
	[InlineData("nM", "", true)]
	[InlineData("", "K", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "e6";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Gq";
		subject.FlightVoyageNumber = "qb";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "K";
			subject.VesselCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qb", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "e6";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Gq";
		subject.FlightVoyageNumber = flightVoyageNumber;
			subject.VesselName = "nM";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "K";
			subject.VesselCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
