using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*NI*u*Yl*B*V9*tz*d*1*L*h*e*6";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "NI",
			TransportationMethodTypeCode = "u",
			CountryCode = "Yl",
			VesselCode = "B",
			VesselName = "V9",
			FlightVoyageNumber = "tz",
			ReferenceIdentification = "d",
			Quantity = 1,
			ManifestTypeCode = "L",
			VesselCodeQualifier = "h",
			YesNoConditionOrResponseCode = "e",
			ReferenceIdentification2 = "6",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NI", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Yl";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = "L";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "V9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.CountryCode = "Yl";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = "L";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "V9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yl", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.TransportationMethodTypeCode = "u";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = "L";
		subject.CountryCode = countryCode;
			subject.VesselName = "V9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "h", true)]
	[InlineData("B", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Yl";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = "L";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "V9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("V9", "B", true)]
	[InlineData("V9", "", true)]
	[InlineData("", "B", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Yl";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = "L";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tz", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Yl";
		subject.ManifestTypeCode = "L";
		subject.FlightVoyageNumber = flightVoyageNumber;
			subject.VesselName = "V9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "NI";
		subject.TransportationMethodTypeCode = "u";
		subject.CountryCode = "Yl";
		subject.FlightVoyageNumber = "tz";
		subject.ManifestTypeCode = manifestTypeCode;
			subject.VesselName = "V9";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "B";
			subject.VesselCodeQualifier = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
