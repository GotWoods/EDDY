using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class M10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M10*Ah*3*7w*q*j5*7K*5*9*r*e*G*x*HR*QJ*s*9X*P";

		var expected = new M10_ManifestIdentifyingInformation()
		{
			StandardCarrierAlphaCode = "Ah",
			TransportationMethodTypeCode = "3",
			CountryCode = "7w",
			VesselCode = "q",
			VesselName = "j5",
			FlightVoyageNumber = "7K",
			ReferenceIdentification = "5",
			Quantity = 9,
			ManifestTypeCode = "r",
			VesselCodeQualifier = "e",
			YesNoConditionOrResponseCode = "G",
			ReferenceIdentification2 = "x",
			TransactionSetPurposeCode = "HR",
			ApplicationType = "QJ",
			AmendmentTypeCode = "s",
			AmendmentCode = "9X",
			ManifestTypeCode2 = "P",
		};

		var actual = Map.MapObject<M10_ManifestIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ah", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.TransportationMethodTypeCode = "3";
		subject.CountryCode = "7w";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
			subject.VesselName = "j5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "q";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "s";
			subject.AmendmentCode = "9X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "Ah";
		subject.CountryCode = "7w";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.VesselName = "j5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "q";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "s";
			subject.AmendmentCode = "9X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7w", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "Ah";
		subject.TransportationMethodTypeCode = "3";
		subject.CountryCode = countryCode;
			subject.VesselName = "j5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "q";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "s";
			subject.AmendmentCode = "9X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "e", true)]
	[InlineData("q", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredVesselCode(string vesselCode, string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "Ah";
		subject.TransportationMethodTypeCode = "3";
		subject.CountryCode = "7w";
		subject.VesselCode = vesselCode;
		subject.VesselCodeQualifier = vesselCodeQualifier;
			subject.VesselName = "j5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "s";
			subject.AmendmentCode = "9X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("j5", "q", true)]
	[InlineData("j5", "", true)]
	[InlineData("", "q", true)]
	public void Validation_AtLeastOneVesselName(string vesselName, string vesselCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "Ah";
		subject.TransportationMethodTypeCode = "3";
		subject.CountryCode = "7w";
		subject.VesselName = vesselName;
		subject.VesselCode = vesselCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "q";
			subject.VesselCodeQualifier = "e";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentTypeCode) || !string.IsNullOrEmpty(subject.AmendmentCode))
		{
			subject.AmendmentTypeCode = "s";
			subject.AmendmentCode = "9X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "9X", true)]
	[InlineData("s", "", false)]
	[InlineData("", "9X", false)]
	public void Validation_AllAreRequiredAmendmentTypeCode(string amendmentTypeCode, string amendmentCode, bool isValidExpected)
	{
		var subject = new M10_ManifestIdentifyingInformation();
		subject.StandardCarrierAlphaCode = "Ah";
		subject.TransportationMethodTypeCode = "3";
		subject.CountryCode = "7w";
		subject.AmendmentTypeCode = amendmentTypeCode;
		subject.AmendmentCode = amendmentCode;
			subject.VesselName = "j5";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCode) || !string.IsNullOrEmpty(subject.VesselCodeQualifier))
		{
			subject.VesselCode = "q";
			subject.VesselCodeQualifier = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
