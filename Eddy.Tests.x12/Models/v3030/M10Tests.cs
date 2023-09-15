using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*ay*S*qm*D*o2*Y9*1*8*V*w*f";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "ay",
			TransportationMethodTypeCode = "S",
			CountryCode = "qm",
			VesselCode = "D",
			VesselName = "o2",
			FlightVoyageNumber = "Y9",
			ReferenceNumber = "1",
			Quantity = 8,
			ManifestTypeCode = "V",
			VesselCodeQualifier = "w",
			YesNoConditionOrResponseCode = "f",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ay", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "S";
		subject.CountryCode = "qm";
		subject.VesselName = "o2";
		subject.FlightVoyageNumber = "Y9";
		subject.ManifestTypeCode = "V";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "ay";
		subject.CountryCode = "qm";
		subject.VesselName = "o2";
		subject.FlightVoyageNumber = "Y9";
		subject.ManifestTypeCode = "V";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qm", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "ay";
		subject.TransportationMethodTypeCode = "S";
		subject.VesselName = "o2";
		subject.FlightVoyageNumber = "Y9";
		subject.ManifestTypeCode = "V";
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o2", true)]
	public void Validation_RequiredVesselName(string vesselName, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "ay";
		subject.TransportationMethodTypeCode = "S";
		subject.CountryCode = "qm";
		subject.FlightVoyageNumber = "Y9";
		subject.ManifestTypeCode = "V";
		subject.VesselName = vesselName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y9", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "ay";
		subject.TransportationMethodTypeCode = "S";
		subject.CountryCode = "qm";
		subject.VesselName = "o2";
		subject.ManifestTypeCode = "V";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "ay";
		subject.TransportationMethodTypeCode = "S";
		subject.CountryCode = "qm";
		subject.VesselName = "o2";
		subject.FlightVoyageNumber = "Y9";
		subject.ManifestTypeCode = manifestTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
