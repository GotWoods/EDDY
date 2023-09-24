using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*H8*v*Ra*aDmA*jr*9a*N*6*s*k";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "H8",
			TransportationMethodTypeCode = "v",
			CountryCode = "Ra",
			VesselCode = "aDmA",
			VesselName = "jr",
			FlightVoyageNumber = "9a",
			ReferenceNumber = "N",
			Quantity = 6,
			ManifestTypeCode = "s",
			VesselCodeQualifier = "k",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "Ra";
		subject.VesselName = "jr";
		subject.FlightVoyageNumber = "9a";
		subject.ManifestTypeCode = "s";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "H8";
		subject.CountryCode = "Ra";
		subject.VesselName = "jr";
		subject.FlightVoyageNumber = "9a";
		subject.ManifestTypeCode = "s";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ra", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "H8";
		subject.TransportationMethodTypeCode = "v";
		subject.VesselName = "jr";
		subject.FlightVoyageNumber = "9a";
		subject.ManifestTypeCode = "s";
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jr", true)]
	public void Validation_RequiredVesselName(string vesselName, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "H8";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "Ra";
		subject.FlightVoyageNumber = "9a";
		subject.ManifestTypeCode = "s";
		subject.VesselName = vesselName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9a", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "H8";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "Ra";
		subject.VesselName = "jr";
		subject.ManifestTypeCode = "s";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "H8";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "Ra";
		subject.VesselName = "jr";
		subject.FlightVoyageNumber = "9a";
		subject.ManifestTypeCode = manifestTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
