using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA1*B*x*9*PF*Tg*a*y*kSm*n*I*wX*Ek*L*NN";

		var expected = new BA1_BeginningSegmentForShippersExportDeclaration()
		{
			RelatedCompanyIndicationCode = "B",
			CensusMerchandiseTypeCode = "x",
			TransportationMethodTypeCode = "9",
			CensusStatisticalMonthCode = "PF",
			CountryCode = "Tg",
			CensusTradeIdentifierCode = "a",
			CensusExportLicenseIdentifierCode = "y",
			PostalCode = "kSm",
			CensusContainerCode = "n",
			CensusSpecialIdentifierCode = "I",
			CountryCode2 = "wX",
			StateOrProvinceCode = "Ek",
			Authority = "L",
			StandardCarrierAlphaCode = "NN",
		};

		var actual = Map.MapObject<BA1_BeginningSegmentForShippersExportDeclaration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredRelatedCompanyIndicationCode(string relatedCompanyIndicationCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.RelatedCompanyIndicationCode = relatedCompanyIndicationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredCensusMerchandiseTypeCode(string censusMerchandiseTypeCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.CensusMerchandiseTypeCode = censusMerchandiseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PF", true)]
	public void Validation_RequiredCensusStatisticalMonthCode(string censusStatisticalMonthCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.CensusStatisticalMonthCode = censusStatisticalMonthCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tg", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCensusTradeIdentifierCode(string censusTradeIdentifierCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusExportLicenseIdentifierCode = "y";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.CensusTradeIdentifierCode = censusTradeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredCensusExportLicenseIdentifierCode(string censusExportLicenseIdentifierCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.PostalCode = "kSm";
		//Test Parameters
		subject.CensusExportLicenseIdentifierCode = censusExportLicenseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kSm", true)]
	public void Validation_RequiredPostalCode(string postalCode, bool isValidExpected)
	{
		var subject = new BA1_BeginningSegmentForShippersExportDeclaration();
		//Required fields
		subject.RelatedCompanyIndicationCode = "B";
		subject.CensusMerchandiseTypeCode = "x";
		subject.TransportationMethodTypeCode = "9";
		subject.CensusStatisticalMonthCode = "PF";
		subject.CountryCode = "Tg";
		subject.CensusTradeIdentifierCode = "a";
		subject.CensusExportLicenseIdentifierCode = "y";
		//Test Parameters
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
