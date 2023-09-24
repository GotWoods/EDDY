using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LEPTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LEP*Kx7SVn*uLSJklSm8PFJpUIl*M9*HGh0zJ8YWNaMz5piLJccisOg1tWG4xzn88FDhPMuRBgDElLIq2WJrv0MZwk3kXdeQDeSgWXrTxNiXeXf";

        var expected = new LEP_EPARequiredData()
        {
            EPAWasteStreamNumberCode = "Kx7SVn",
            WasteCharacteristicsCode = "uLSJklSm8PFJpUIl",
            StateOrProvinceCode = "M9",
            ReferenceIdentification = "HGh0zJ8YWNaMz5piLJccisOg1tWG4xzn88FDhPMuRBgDElLIq2WJrv0MZwk3kXdeQDeSgWXrTxNiXeXf",
        };

        var actual = Map.MapObject<LEP_EPARequiredData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string referenceIdentification, bool isValidExpected)
    {
        var subject = new LEP_EPARequiredData();
        subject.StateOrProvinceCode = stateOrProvinceCode;
        subject.ReferenceIdentification = referenceIdentification;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}