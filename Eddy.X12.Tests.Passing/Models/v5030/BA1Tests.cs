using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*w*T*x*jg*M*lmL*sM*5K*j*Of*u*gU";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "w",
			ActionCode = "T",
			TransportationMethodTypeCode = "x",
			CountryCode = "jg",
			ReferenceIdentification = "M",
			PostalCode = "lmL",
			CountryCode2 = "sM",
			StateOrProvinceCode = "5K",
			Authority = "j",
			StandardCarrierAlphaCode = "Of",
			LocationIdentifier = "u",
			VesselName = "gU",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.ActionCode = "T";
		subject.TransportationMethodTypeCode = "x";
		subject.CountryCode = "jg";
		subject.ReferenceIdentification = "M";
		subject.StandardCarrierAlphaCode = "Of";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "w";
		subject.TransportationMethodTypeCode = "x";
		subject.CountryCode = "jg";
		subject.ReferenceIdentification = "M";
		subject.StandardCarrierAlphaCode = "Of";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "w";
		subject.ActionCode = "T";
		subject.CountryCode = "jg";
		subject.ReferenceIdentification = "M";
		subject.StandardCarrierAlphaCode = "Of";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jg", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "w";
		subject.ActionCode = "T";
		subject.TransportationMethodTypeCode = "x";
		subject.ReferenceIdentification = "M";
		subject.StandardCarrierAlphaCode = "Of";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "w";
		subject.ActionCode = "T";
		subject.TransportationMethodTypeCode = "x";
		subject.CountryCode = "jg";
		subject.StandardCarrierAlphaCode = "Of";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Of", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "w";
		subject.ActionCode = "T";
		subject.TransportationMethodTypeCode = "x";
		subject.CountryCode = "jg";
		subject.ReferenceIdentification = "M";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
