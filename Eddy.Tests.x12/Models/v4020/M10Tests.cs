using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*jV*G*Rf*b*ij*6y*O*2*A*K*h*6*4L*M5";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "jV",
			TransportationMethodTypeCode = "G",
			CountryCode = "Rf",
			VesselCode = "b",
			VesselName = "ij",
			FlightVoyageNumber = "6y",
			ReferenceIdentification = "O",
			Quantity = 2,
			ManifestTypeCode = "A",
			VesselCodeQualifier = "K",
			YesNoConditionOrResponseCode = "h",
			ReferenceIdentification2 = "6",
			TransactionSetPurposeCode = "4L",
			ApplicationType = "M5",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "G";
		subject.CountryCode = "Rf";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = "A";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "ij";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.CountryCode = "Rf";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = "A";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "ij";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rf", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.TransportationMethodTypeCode = "G";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = "A";
		subject.CountryCode = countryCode;
			subject.VesselName = "ij";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "K", true)]
	[InlineData("b", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.TransportationMethodTypeCode = "G";
		subject.CountryCode = "Rf";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = "A";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "ij";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ij", "b", true)]
	[InlineData("ij", "", true)]
	[InlineData("", "b", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.TransportationMethodTypeCode = "G";
		subject.CountryCode = "Rf";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = "A";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6y", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.TransportationMethodTypeCode = "G";
		subject.CountryCode = "Rf";
		subject.ManifestTypeCode = "A";
		subject.FlightVoyageNumber = flightVoyageNumber;
			subject.VesselName = "ij";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredManifestTypeCode(string manifestTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "jV";
		subject.TransportationMethodTypeCode = "G";
		subject.CountryCode = "Rf";
		subject.FlightVoyageNumber = "6y";
		subject.ManifestTypeCode = manifestTypeCode;
			subject.VesselName = "ij";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "b";
			subject.VesselCodeQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
