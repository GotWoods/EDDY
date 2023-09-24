using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*tl*u*Tu*j*7q*SV*i*2*H*L*O*1";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "tl",
			TransportationMethodTypeCode = "u",
			CountryCode = "Tu",
			VesselCode = "j",
			VesselName = "7q",
			FlightVoyageNumber = "SV",
			ReferenceIdentification = "i",
			Quantity = 2,
			ManifestTypeCode = "H",
			VesselCodeQualifier = "L",
			YesNoConditionOrResponseCode = "O",
			ReferenceIdentification2 = "1",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tl", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Tu";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = "H";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "7q";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.CountryCode = "Tu";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = "H";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "7q";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tu", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.TransportationMethodTypeCode = "u";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = "H";
		subject.CountryCode = countryCode;
			subject.VesselName = "7q";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "L", true)]
	[InlineData("j", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Tu";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = "H";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "7q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("7q", "j", true)]
	[InlineData("7q", "", true)]
	[InlineData("", "j", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Tu";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = "H";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SV", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Tu";
		subject.ManifestTypeCode = "H";
		subject.FlightVoyageNumber = flightVoyageNumber;
			subject.VesselName = "7q";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "tl";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Tu";
		subject.FlightVoyageNumber = "SV";
		subject.ManifestTypeCode = manifestTypeCode;
			subject.VesselName = "7q";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "j";
			subject.VesselCodeQualifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
