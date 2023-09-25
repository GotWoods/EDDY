using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*9*u*V*yy*t*i4u*N9*fT*W*q7*j*JM";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "9",
			ActionCode = "u",
			TransportationMethodTypeCode = "V",
			CountryCode = "yy",
			ReferenceIdentification = "t",
			PostalCode = "i4u",
			CountryCode2 = "N9",
			StateOrProvinceCode = "fT",
			Authority = "W",
			StandardCarrierAlphaCode = "q7",
			LocationIdentifier = "j",
			VesselName = "JM",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.ActionCode = "u";
		subject.TransportationMethodTypeCode = "V";
		subject.CountryCode = "yy";
		subject.ReferenceIdentification = "t";
		subject.StandardCarrierAlphaCode = "q7";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "9";
		subject.TransportationMethodTypeCode = "V";
		subject.CountryCode = "yy";
		subject.ReferenceIdentification = "t";
		subject.StandardCarrierAlphaCode = "q7";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "9";
		subject.ActionCode = "u";
		subject.CountryCode = "yy";
		subject.ReferenceIdentification = "t";
		subject.StandardCarrierAlphaCode = "q7";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yy", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "9";
		subject.ActionCode = "u";
		subject.TransportationMethodTypeCode = "V";
		subject.ReferenceIdentification = "t";
		subject.StandardCarrierAlphaCode = "q7";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "9";
		subject.ActionCode = "u";
		subject.TransportationMethodTypeCode = "V";
		subject.CountryCode = "yy";
		subject.StandardCarrierAlphaCode = "q7";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q7", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "9";
		subject.ActionCode = "u";
		subject.TransportationMethodTypeCode = "V";
		subject.CountryCode = "yy";
		subject.ReferenceIdentification = "t";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
