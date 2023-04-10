﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C023Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "D*O*W";

        var expected = new C023_HealthCareServiceLocationInformation()
        {
            FacilityCodeValue = "D",
            FacilityCodeQualifier = "O",
            ClaimFrequencyTypeCode = "W",
        };

        var actual = Map.MapObject<C023_HealthCareServiceLocationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("D", true)]
    public void Validatation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
    {
        var subject = new C023_HealthCareServiceLocationInformation();
        subject.FacilityCodeQualifier = "O";
        subject.FacilityCodeValue = facilityCodeValue;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("O", true)]
    public void Validatation_RequiredFacilityCodeQualifier(string facilityCodeQualifier, bool isValidExpected)
    {
        var subject = new C023_HealthCareServiceLocationInformation();
        subject.FacilityCodeValue = "D";
        subject.FacilityCodeQualifier = facilityCodeQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}