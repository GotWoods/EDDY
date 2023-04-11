using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AOCTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AOC*0a*9*7wRAyvyC*8*mw";

        var expected = new AOC_AnimalOffspringCounts
        {
            OffspringCountCode = "0a",
            Count = 9,
            Date = "7wRAyvyC",
            TestPeriodOrIntervalValue = 8,
            UnitOfTimePeriodOrIntervalCode = "mw"
        };

        var actual = Map.MapObject<AOC_AnimalOffspringCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("0a", true)]
    public void Validation_RequiredOffspringCountCode(string offspringCountCode, bool isValidExpected)
    {
        var subject = new AOC_AnimalOffspringCounts();
        subject.Count = 9;
        subject.OffspringCountCode = offspringCountCode;
        subject.Date = "20230101";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(9, true)]
    public void Validation_RequiredCount(int count, bool isValidExpected)
    {
        var subject = new AOC_AnimalOffspringCounts();
        subject.OffspringCountCode = "0a";
        if (count > 0)
            subject.Count = count;

        subject.Date = "20230101";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("7wRAyvyC", 8, true)]
    [InlineData("", 8, true)]
    [InlineData("7wRAyvyC", 0, true)]
    public void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)
    {
        var subject = new AOC_AnimalOffspringCounts();
        subject.OffspringCountCode = "0a";
        subject.Count = 9;
        subject.Date = date;
        if (testPeriodOrIntervalValue > 0)
        {
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
            subject.UnitOfTimePeriodOrIntervalCode = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "mw", true)]
    [InlineData(0, "mw", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new AOC_AnimalOffspringCounts();
        subject.OffspringCountCode = "0a";
        subject.Count = 9;
        if (testPeriodOrIntervalValue > 0)
        {
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
            subject.UnitOfTimePeriodOrIntervalCode = "AB";
        }
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
        subject.Date = "20230101";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}