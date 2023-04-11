using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AORTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AOR*5*W*v*O*S*m*N*3*d4*3*jP*5*ae";

        var expected = new AOR_AnimalObservationResult
        {
            ObservationDistribution = "5",
            ObservationSeverity = "W",
            NeoplasmCode = "v",
            YesNoConditionOrResponseCode = "O",
            LinkageIdentifier = "S",
            LinkageIdentifier2 = "m",
            YesNoConditionOrResponseCode2 = "N",
            TestPeriodOrIntervalValue = 3,
            UnitOfTimePeriodOrIntervalCode = "d4",
            TestPeriodOrIntervalValue2 = 3,
            UnitOfTimePeriodOrIntervalCode2 = "jP",
            TestPeriodOrIntervalValue3 = 5,
            UnitOfTimePeriodOrIntervalCode3 = "ae"
        };

        var actual = Map.MapObject<AOR_AnimalObservationResult>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(3, "d4", true)]
    [InlineData(0, "d4", false)]
    [InlineData(3, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new AOR_AnimalObservationResult();
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(3, "jP", true)]
    [InlineData(0, "jP", false)]
    [InlineData(3, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
    {
        var subject = new AOR_AnimalObservationResult();
        if (testPeriodOrIntervalValue2 > 0)
            subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
        subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "ae", true)]
    [InlineData(0, "ae", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
    {
        var subject = new AOR_AnimalObservationResult();
        if (testPeriodOrIntervalValue3 > 0)
            subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
        subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}