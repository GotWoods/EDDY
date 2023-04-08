using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*8*v*m*It*j*1up*ew*5S*C*jH*K*cB";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "8",
			ActionCode = "v",
			TransportationMethodTypeCode = "m",
			CountryCode = "It",
			ReferenceIdentification = "j",
			PostalCode = "1up",
			CountryCode2 = "ew",
			StateOrProvinceCode = "5S",
			Authority = "C",
			StandardCarrierAlphaCode = "jH",
			LocationIdentifier = "K",
			VesselName = "cB",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validatation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.ActionCode = "v";
		subject.TransportationMethodTypeCode = "m";
		subject.CountryCode = "It";
		subject.ReferenceIdentification = "j";
		subject.StandardCarrierAlphaCode = "jH";
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.RelatedCompanyIndicationCode = "8";
		subject.TransportationMethodTypeCode = "m";
		subject.CountryCode = "It";
		subject.ReferenceIdentification = "j";
		subject.StandardCarrierAlphaCode = "jH";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validatation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.RelatedCompanyIndicationCode = "8";
		subject.ActionCode = "v";
		subject.CountryCode = "It";
		subject.ReferenceIdentification = "j";
		subject.StandardCarrierAlphaCode = "jH";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("It", true)]
	public void Validatation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.RelatedCompanyIndicationCode = "8";
		subject.ActionCode = "v";
		subject.TransportationMethodTypeCode = "m";
		subject.ReferenceIdentification = "j";
		subject.StandardCarrierAlphaCode = "jH";
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.RelatedCompanyIndicationCode = "8";
		subject.ActionCode = "v";
		subject.TransportationMethodTypeCode = "m";
		subject.CountryCode = "It";
		subject.StandardCarrierAlphaCode = "jH";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jH", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		subject.RelatedCompanyIndicationCode = "8";
		subject.ActionCode = "v";
		subject.TransportationMethodTypeCode = "m";
		subject.CountryCode = "It";
		subject.ReferenceIdentification = "j";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
