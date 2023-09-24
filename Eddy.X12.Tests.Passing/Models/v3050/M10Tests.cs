using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*lb*1*6r*X*WD*Ft*O*9*h*x*1*r";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "lb",
			TransportationMethodTypeCode = "1",
			CountryCode = "6r",
			VesselCode = "X",
			VesselName = "WD",
			FlightVoyageNumber = "Ft",
			ReferenceNumber = "O",
			Quantity = 9,
			ManifestTypeCode = "h",
			VesselCodeQualifier = "x",
			YesNoConditionOrResponseCode = "1",
			ReferenceNumber2 = "r",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "1";
		subject.CountryCode = "6r";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = "h";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "WD";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.CountryCode = "6r";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = "h";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "WD";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6r", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.TransportationMethodTypeCode = "1";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = "h";
		subject.CountryCode = countryCode;
			subject.VesselName = "WD";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "x", true)]
	[InlineData("X", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.TransportationMethodTypeCode = "1";
		subject.CountryCode = "6r";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = "h";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "WD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("WD", "X", true)]
	[InlineData("WD", "", true)]
	[InlineData("", "X", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.TransportationMethodTypeCode = "1";
		subject.CountryCode = "6r";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = "h";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ft", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.TransportationMethodTypeCode = "1";
		subject.CountryCode = "6r";
		subject.ManifestTypeCode = "h";
		subject.FlightVoyageNumber = flightVoyageNumber;
			subject.VesselName = "WD";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "lb";
		subject.TransportationMethodTypeCode = "1";
		subject.CountryCode = "6r";
		subject.FlightVoyageNumber = "Ft";
		subject.ManifestTypeCode = manifestTypeCode;
			subject.VesselName = "WD";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "X";
			subject.VesselCodeQualifier = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
