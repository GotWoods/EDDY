using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*1*J*v*md*1*j*k43*n*p*ca*DK*F*hf*H*2B";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "1",
			CensusMerchandiseTypeCode = "J",
			TransportationMethodTypeCode = "v",
			CountryCode = "md",
			ReferenceIdentification = "1",
			CensusExportLicenseIdentifierCode = "j",
			PostalCode = "k43",
			CensusContainerCode = "n",
			CensusSpecialIdentifierCode = "p",
			CountryCode2 = "ca",
			StateOrProvinceCode = "DK",
			Authority = "F",
			StandardCarrierAlphaCode = "hf",
			LocationIdentifier = "H",
			VesselName = "2B",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.CensusMerchandiseTypeCode = "J";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "md";
		subject.ReferenceIdentification = "1";
		subject.CensusExportLicenseIdentifierCode = "j";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCensusMerchandiseTypeCode(string censusMerchandiseTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "md";
		subject.ReferenceIdentification = "1";
		subject.CensusExportLicenseIdentifierCode = "j";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.CensusMerchandiseTypeCode = censusMerchandiseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.CensusMerchandiseTypeCode = "J";
		subject.CountryCode = "md";
		subject.ReferenceIdentification = "1";
		subject.CensusExportLicenseIdentifierCode = "j";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("md", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.CensusMerchandiseTypeCode = "J";
		subject.TransportationMethodTypeCode = "v";
		subject.ReferenceIdentification = "1";
		subject.CensusExportLicenseIdentifierCode = "j";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.CensusMerchandiseTypeCode = "J";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "md";
		subject.CensusExportLicenseIdentifierCode = "j";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredCensusExportLicenseIdentifierCode(string censusExportLicenseIdentifierCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.CensusMerchandiseTypeCode = "J";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "md";
		subject.ReferenceIdentification = "1";
		subject.PostalCode = "k43";
		//Test Parameters
		subject.CensusExportLicenseIdentifierCode = censusExportLicenseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k43", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "1";
		subject.CensusMerchandiseTypeCode = "J";
		subject.TransportationMethodTypeCode = "v";
		subject.CountryCode = "md";
		subject.ReferenceIdentification = "1";
		subject.CensusExportLicenseIdentifierCode = "j";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
