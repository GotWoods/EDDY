using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*u*2*7*Xn*pp*A*U*9T1*S*l*d4*dY*w*X8";

		var expected = new BA1_BeginningSegmentForShippersExportDeclaration()
		{
			RelatedCompanyIndicationCode = "u",
			CensusMerchandiseTypeCode = "2",
			TransportationMethodTypeCode = "7",
			CensusStatisticalMonthCode = "Xn",
			CountryCode = "pp",
			CensusTradeIdentifierCode = "A",
			CensusExportLicenseIdentifierCode = "U",
			PostalCode = "9T1",
			CensusContainerCode = "S",
			CensusSpecialIdentifierCode = "l",
			CountryCode2 = "d4",
			StateOrProvinceCode = "dY",
			Authority = "w",
			StandardCarrierAlphaCode = "X8",
		};

		var actual = Map.MapObject<BA1_BeginningSegmentForShippersExportDeclaration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredCensusMerchandiseTypeCode(string censusMerchandiseTypeCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.CensusMerchandiseTypeCode = censusMerchandiseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xn", true)]
	public void Validation_RequiredCensusStatisticalMonthCode(string censusStatisticalMonthCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.CensusStatisticalMonthCode = censusStatisticalMonthCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pp", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCensusTradeIdentifierCode(string censusTradeIdentifierCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusExportLicenseIdentifierCode = "U";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.CensusTradeIdentifierCode = censusTradeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCensusExportLicenseIdentifierCode(string censusExportLicenseIdentifierCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.PostalCode = "9T1";
		//Test Parameters
		subject.CensusExportLicenseIdentifierCode = censusExportLicenseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9T1", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "u";
		subject.CensusMerchandiseTypeCode = "2";
		subject.TransportationMethodTypeCode = "7";
		subject.CensusStatisticalMonthCode = "Xn";
		subject.CountryCode = "pp";
		subject.CensusTradeIdentifierCode = "A";
		subject.CensusExportLicenseIdentifierCode = "U";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
