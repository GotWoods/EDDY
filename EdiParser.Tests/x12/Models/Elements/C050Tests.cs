﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C050Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "0X*aJp*d*f*Zr*uig*c*B*tc*oCD*d*d";

        var expected = new C050_CertificateLookUpInformation()
        {
            LookUpValueProtocolCode = "0X",
            FilterIDCode = "aJp",
            VersionIdentifier = "d",
            LookUpValue = "f",
            LookUpValueProtocolCode2 = "Zr",
            FilterIDCode2 = "uig",
            VersionIdentifier2 = "c",
            LookUpValue2 = "B",
            LookUpValueProtocolCode3 = "tc",
            FilterIDCode3 = "oCD",
            VersionIdentifier3 = "d",
            LookUpValue3 = "d",
        };

        var actual = Map.MapObject<C050_CertificateLookUpInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        try
        {
            Assert.Equivalent(expected, actual);
        }
        catch
        {
            Assert.Fail(actual.ValidationResult.ToString());
        }
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("0X", true)]
    public void Validatation_RequiredLookUpValueProtocolCode(string lookUpValueProtocolCode, bool isValidExpected)
    {
        var subject = new C050_CertificateLookUpInformation();
        subject.FilterIDCode = "aJp";
        subject.VersionIdentifier = "d";
        subject.LookUpValue = "f";
        subject.LookUpValueProtocolCode = lookUpValueProtocolCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("aJp", true)]
    public void Validatation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
    {
        var subject = new C050_CertificateLookUpInformation();
        subject.LookUpValueProtocolCode = "0X";
        subject.VersionIdentifier = "d";
        subject.LookUpValue = "f";
        subject.FilterIDCode = filterIDCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("d", true)]
    public void Validatation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
    {
        var subject = new C050_CertificateLookUpInformation();
        subject.LookUpValueProtocolCode = "0X";
        subject.FilterIDCode = "aJp";
        subject.LookUpValue = "f";
        subject.VersionIdentifier = versionIdentifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("f", true)]
    public void Validatation_RequiredLookUpValue(string lookUpValue, bool isValidExpected)
    {
        var subject = new C050_CertificateLookUpInformation();
        subject.LookUpValueProtocolCode = "0X";
        subject.FilterIDCode = "aJp";
        subject.VersionIdentifier = "d";
        subject.LookUpValue = lookUpValue;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}