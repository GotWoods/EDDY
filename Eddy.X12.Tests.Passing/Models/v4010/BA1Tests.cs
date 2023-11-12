using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*e*o*P*Tc*8*MTw*vV*fU*5*gb*e*3C";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "e",
			ActionCode = "o",
			TransportationMethodTypeCode = "P",
			CountryCode = "Tc",
			ReferenceIdentification = "8",
			PostalCode = "MTw",
			CountryCode2 = "vV",
			StateOrProvinceCode = "fU",
			Authority = "5",
			StandardCarrierAlphaCode = "gb",
			LocationIdentifier = "e",
			VesselName = "3C",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.ActionCode = "o";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Tc";
		subject.ReferenceIdentification = "8";
		subject.StandardCarrierAlphaCode = "gb";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "e";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Tc";
		subject.ReferenceIdentification = "8";
		subject.StandardCarrierAlphaCode = "gb";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "e";
		subject.ActionCode = "o";
		subject.CountryCode = "Tc";
		subject.ReferenceIdentification = "8";
		subject.StandardCarrierAlphaCode = "gb";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tc", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "e";
		subject.ActionCode = "o";
		subject.TransportationMethodTypeCode = "P";
		subject.ReferenceIdentification = "8";
		subject.StandardCarrierAlphaCode = "gb";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "e";
		subject.ActionCode = "o";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Tc";
		subject.StandardCarrierAlphaCode = "gb";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "e";
		subject.ActionCode = "o";
		subject.TransportationMethodTypeCode = "P";
		subject.CountryCode = "Tc";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
