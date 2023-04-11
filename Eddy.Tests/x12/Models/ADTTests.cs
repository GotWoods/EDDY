using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ADTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ADT*a*z8I1Eigx*6*bt*FY1yCOhi*9*n2*6Psk*8*AQ";

        var expected = new ADT_AnimalParturitionStatus
        {
            ParturitionStatusCode = "a",
            Date = "z8I1Eigx",
            TestPeriodOrIntervalValue = 6,
            UnitOfTimePeriodOrIntervalCode = "bt",
            Date2 = "FY1yCOhi",
            TestPeriodOrIntervalValue2 = 9,
            UnitOfTimePeriodOrIntervalCode2 = "n2",
            Time = "6Psk",
            TestPeriodOrIntervalValue3 = 8,
            UnitOfTimePeriodOrIntervalCode3 = "AQ"
        };

        var actual = Map.MapObject<ADT_AnimalParturitionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("a", true)]
    public void Validatation_RequiredParturitionStatusCode(string parturitionStatusCode, bool isValidExpected)
    {
        var subject = new ADT_AnimalParturitionStatus();
        subject.ParturitionStatusCode = parturitionStatusCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(6, "bt", true)]
    [InlineData(0, "bt", false)]
    [InlineData(6, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new ADT_AnimalParturitionStatus();
        subject.ParturitionStatusCode = "a";
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "n2", true)]
    [InlineData(0, "n2", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
    {
        var subject = new ADT_AnimalParturitionStatus();
        subject.ParturitionStatusCode = "a";
        if (testPeriodOrIntervalValue2 > 0)
            subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
        subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "AQ", true)]
    [InlineData(0, "AQ", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
    {
        var subject = new ADT_AnimalParturitionStatus();
        subject.ParturitionStatusCode = "a";
        if (testPeriodOrIntervalValue3 > 0)
            subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
        subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}