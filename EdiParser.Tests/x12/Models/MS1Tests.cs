using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class MS1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "MS1*QB*F2*gd*AoczcS9*8EsWu3g*q*c*Wao*t*h";

        var expected = new MS1_EquipmentShipmentOrRealPropertyLocation
        {
            CityName = "QB",
            StateOrProvinceCode = "F2",
            CountryCode = "gd",
            LongitudeCode = "AoczcS9",
            LatitudeCode = "8EsWu3g",
            LongitudeDirectionIdentifierCode = "q",
            LatitudeDirectionIdentifierCode = "c",
            PostalCode = "Wao",
            LongitudeDecimalFormat = "t",
            LatitudeDecimalFormat = "h"
        };

        var actual = Map.MapObject<MS1_EquipmentShipmentOrRealPropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    //l010203
    [Theory]
    [InlineData("", "", "", true)]
    [InlineData("v1", "", "", false)]
    [InlineData("v1", "v2", "v3", true)]
    [InlineData("v1", "v2", "", true)]
    [InlineData("v1", "", "v3", true)]
    public void Validation_IfCityNameThenStateOrCountryIsRequired(string cityName, string stateOrProvinceCode, string countryCode, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.CityName = cityName;
        subject.StateOrProvinceCode = stateOrProvinceCode;
        subject.CountryCode = countryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData("", "", "", true)]
    [InlineData("1", "", "", false)]
    [InlineData("1", "1234567", "v3", true)]
    [InlineData("1", "1234567", "", true)]
    [InlineData("1", "", "v3", true)]
    public void Validation_IfDirectionIdentifierCodeThenLongitudeCodeOrLongitudeDecimalFormatRequired(string directionIdentifierCode, string longitudeCode, string longitudeDecimalFormat, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.LongitudeDirectionIdentifierCode = directionIdentifierCode;
        subject.LongitudeCode = longitudeCode;
        subject.LongitudeDecimalFormat = longitudeDecimalFormat;


        if (!string.IsNullOrEmpty(longitudeCode))
            subject.LatitudeCode = longitudeCode; //this is needed to pass a different validation

        if (!string.IsNullOrEmpty(longitudeDecimalFormat))
            subject.LatitudeDecimalFormat = longitudeDecimalFormat; //this is needed to pass a different validation


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData("", "", "", true)]
    [InlineData("1", "", "", false)]
    [InlineData("1", "1234567", "v3", true)]
    [InlineData("1", "1234567", "", true)]
    [InlineData("1", "", "v3", true)]
    public void Validation_DirectionIdentifierCodeThenLatitudeCodeOrLatitudeDecimalFormatRequired(string directionIdentifierCode, string latitudeCode, string latitudeDecimalFormat, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.LatitudeDirectionIdentifierCode = directionIdentifierCode;
        subject.LatitudeCode = latitudeCode;
        subject.LatitudeDecimalFormat = latitudeDecimalFormat;

        if (!string.IsNullOrEmpty(latitudeCode))
            subject.LongitudeCode = latitudeCode; //this is needed to pass a different validation

        if (!string.IsNullOrEmpty(latitudeDecimalFormat))
            subject.LongitudeDecimalFormat = latitudeDecimalFormat; //this is needed to pass a different validation

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }


    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "", false)]
    public void Validation_StateOrProvinceCodeRequiresCityName(string stateOrProvinceCode, string cityName, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.StateOrProvinceCode = stateOrProvinceCode;
        subject.CityName = cityName;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_CountryCodeRequiresCity(string countryCode, string cityName, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.CountryCode = countryCode;
        subject.CityName = cityName;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("1234567", "1234567", true)]
    [InlineData("", "1234567", false)]
    [InlineData("1234567", "", false)]
    public void Validation_LongitudeCodeOrLatituteCodeRequiresEachOther(string longitudeCode, string latitudeCode, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.LongitudeCode = longitudeCode;
        subject.LatitudeCode = latitudeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("123", "123", true)]
    [InlineData("123", "", false)]
    public void Validation_PostalCodeRequiresCityName(string postalCode, string cityName, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.PostalCode = postalCode;
        subject.CityName = cityName;

        if (!string.IsNullOrEmpty(cityName))
            subject.StateOrProvinceCode = "AB"; //required for a different validation

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("1234567", "1234567", true)]
    [InlineData("", "1234567", false)]
    [InlineData("1234567", "", false)]
    public void Validation_AllAreRequiredLongitudeDecimalFormat(string longitudeDecimalFormat, string latitudeDecimalFormat, bool isValidExpected)
    {
        var subject = new MS1_EquipmentShipmentOrRealPropertyLocation();
        subject.LongitudeDecimalFormat = longitudeDecimalFormat;
        subject.LatitudeDecimalFormat = latitudeDecimalFormat;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}