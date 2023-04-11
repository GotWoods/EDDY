﻿using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IEATests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "IEA*1*123456789";

        var expected = new IEA_InterchangeControlTrailer()
        {
            NumberOfIncludedFunctionalGroups = 1,
            InterchangeControlNumber = 123456789.ToString(),
        };

        var actual = Map.MapObject<IEA_InterchangeControlTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredNumberOfIncludedFunctionalGroups(int numberOfIncludedFunctionalGroups, bool isValidExpected)
    {
        var subject = new IEA_InterchangeControlTrailer();
        subject.InterchangeControlNumber = 123456789.ToString();

        if (numberOfIncludedFunctionalGroups > 0)
            subject.NumberOfIncludedFunctionalGroups = numberOfIncludedFunctionalGroups;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(123456789, true)]
    public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
    {
        var subject = new IEA_InterchangeControlTrailer();
        subject.NumberOfIncludedFunctionalGroups = 1;

        if (interchangeControlNumber > 0)
            subject.InterchangeControlNumber = interchangeControlNumber.ToString();
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}