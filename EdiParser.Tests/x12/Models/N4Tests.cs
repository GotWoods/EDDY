using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class N4Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N4*CY*RN*ogc*83*B*m**";

        var expected = new N4_GeographicLocation()
        {
            CityName = "CY",
            StateOrProvinceCode = "RN",
            PostalCode = "ogc",
            CountryCode = "83",
            LocationQualifier = "B",
            LocationIdentifier = "m",
            //CountrySubdivisionCode = "U", //this can not be present if stateProvince specified
            //PostalCodeFormatted = "CoH", //can not be present if PostalCode is specified
        };

        var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
       Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", false)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
    {
        var subject = new N4_GeographicLocation();
        subject.StateOrProvinceCode = stateOrProvinceCode;
        subject.CountrySubdivisionCode = countrySubdivisionCode;
        if (!string.IsNullOrEmpty(countrySubdivisionCode))
            subject.CountryCode = "12";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("123", "123", false)]
    [InlineData("", "123", true)]
    [InlineData("123", "", true)]
    public void Validation_OnlyOneOfPostalCode(string postalCode, string postalCodeFormatted, bool isValidExpected)
    {
        var subject = new N4_GeographicLocation();
        subject.PostalCode = postalCode;
        subject.PostalCodeFormatted = postalCodeFormatted;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
    {
        var subject = new N4_GeographicLocation();
        subject.LocationIdentifier = locationIdentifier;
        subject.LocationQualifier = locationQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
    {
        var subject = new N4_GeographicLocation();
        subject.CountrySubdivisionCode = countrySubdivisionCode;
        subject.CountryCode = countryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}