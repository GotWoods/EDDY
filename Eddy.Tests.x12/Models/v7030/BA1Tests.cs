using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*D*X*o*x6*u*Ps5*FV*0v*Q*cI*B*HW";

		var expected = new BA1_ExportShipmentIdentifyingInformation()
		{
			RelatedCompanyIndicationCode = "D",
			ActionCode = "X",
			TransportationMethodTypeCode = "o",
			CountryCode = "x6",
			ReferenceIdentification = "u",
			PostalCode = "Ps5",
			CountryCode2 = "FV",
			StateOrProvinceCode = "0v",
			Authority = "Q",
			StandardCarrierAlphaCode = "cI",
			LocationIdentifier = "B",
			VesselName = "HW",
		};

		var actual = Map.MapObject<BA1_ExportShipmentIdentifyingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.ActionCode = "X";
		subject.TransportationMethodTypeCode = "o";
		subject.CountryCode = "x6";
		subject.ReferenceIdentification = "u";
		subject.StandardCarrierAlphaCode = "cI";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "D";
		subject.TransportationMethodTypeCode = "o";
		subject.CountryCode = "x6";
		subject.ReferenceIdentification = "u";
		subject.StandardCarrierAlphaCode = "cI";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "D";
		subject.ActionCode = "X";
		subject.CountryCode = "x6";
		subject.ReferenceIdentification = "u";
		subject.StandardCarrierAlphaCode = "cI";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x6", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "D";
		subject.ActionCode = "X";
		subject.TransportationMethodTypeCode = "o";
		subject.ReferenceIdentification = "u";
		subject.StandardCarrierAlphaCode = "cI";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "D";
		subject.ActionCode = "X";
		subject.TransportationMethodTypeCode = "o";
		subject.CountryCode = "x6";
		subject.StandardCarrierAlphaCode = "cI";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cI", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA1_ExportShipmentIdentifyingInformation();
		//Required fields
		subject.RelatedCompanyIndicationCode = "D";
		subject.ActionCode = "X";
		subject.TransportationMethodTypeCode = "o";
		subject.CountryCode = "x6";
		subject.ReferenceIdentification = "u";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
