﻿using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C033Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "mnq*4";

        var expected = new C033_SecurityTokenValue()
        {
            SecurityValueQualifier = "mnq",
            EncodedSecurityValue = "4",
        };

        var actual = Map.MapObject<C033_SecurityTokenValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("mnq", true)]
    public void Validation_RequiredSecurityValueQualifier(string securityValueQualifier, bool isValidExpected)
    {
        var subject = new C033_SecurityTokenValue();
        subject.EncodedSecurityValue = "4";
        subject.SecurityValueQualifier = securityValueQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("4", true)]
    public void Validation_RequiredEncodedSecurityValue(string encodedSecurityValue, bool isValidExpected)
    {
        var subject = new C033_SecurityTokenValue();
        subject.SecurityValueQualifier = "mnq";
        subject.EncodedSecurityValue = encodedSecurityValue;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}