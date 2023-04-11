using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CSHTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "CSH*I*8*S*C*lRD95J9a*v1*sb*t*6*b";

        var expected = new CSH_SalesRequirements()
        {
            SalesRequirementCode = "I",
            ActionCode = "8",
            Amount = "S",
            AccountNumber = "C",
            Date = "lRD95J9a",
            AgencyQualifierCode = "v1",
            SpecialServicesCode = "sb",
            ProductServiceSubstitutionCode = "t",
            PercentageAsDecimal = 6,
            PercentQualifier = "b",
        };

        var actual = Map.MapObject<CSH_SalesRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBActionCode(string actionCode, string amount, bool isValidExpected)
    {
        var subject = new CSH_SalesRequirements();
        subject.ActionCode = actionCode;
        subject.Amount = amount;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
    {
        var subject = new CSH_SalesRequirements();
        subject.AgencyQualifierCode = agencyQualifierCode;
        subject.SpecialServicesCode = specialServicesCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredPercentageAsDecimal(decimal percentageAsDecimal, string percentQualifier, bool isValidExpected)
    {
        var subject = new CSH_SalesRequirements();
        if (percentageAsDecimal > 0)
            subject.PercentageAsDecimal = percentageAsDecimal;
        subject.PercentQualifier = percentQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}