using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*DO*W*tG*Uk5Y*dc*gg*8*5*6*c";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "DO",
			TransportationMethodTypeCode = "W",
			CountryCode = "tG",
			VesselCode = "Uk5Y",
			VesselName = "dc",
			FlightVoyageNumber = "gg",
			ReferenceNumber = "8",
			Quantity = 5,
			ManifestTypeCode = "6",
			VesselCodeQualifier = "c",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DO", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "W";
		subject.CountryCode = "tG";
		subject.VesselName = "dc";
		subject.FlightVoyageNumber = "gg";
		subject.ManifestTypeCode = "6";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "DO";
		subject.CountryCode = "tG";
		subject.VesselName = "dc";
		subject.FlightVoyageNumber = "gg";
		subject.ManifestTypeCode = "6";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tG", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "DO";
		subject.TransportationMethodTypeCode = "W";
		subject.VesselName = "dc";
		subject.FlightVoyageNumber = "gg";
		subject.ManifestTypeCode = "6";
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dc", true)]
	public void Validation_RequiredVesselName(string vesselName, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "DO";
		subject.TransportationMethodTypeCode = "W";
		subject.CountryCode = "tG";
		subject.FlightVoyageNumber = "gg";
		subject.ManifestTypeCode = "6";
		subject.VesselName = vesselName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gg", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "DO";
		subject.TransportationMethodTypeCode = "W";
		subject.CountryCode = "tG";
		subject.VesselName = "dc";
		subject.ManifestTypeCode = "6";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "DO";
		subject.TransportationMethodTypeCode = "W";
		subject.CountryCode = "tG";
		subject.VesselName = "dc";
		subject.FlightVoyageNumber = "gg";
		subject.ManifestTypeCode = manifestTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
