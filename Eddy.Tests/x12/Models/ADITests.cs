using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ADITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ADI*oV*QW7wVLZm*5*5M";

        var expected = new ADI_AnimalDisposition
        {
            AnimalDispositionCode = "oV",
            Date = "QW7wVLZm",
            TestPeriodOrIntervalValue = 5,
            UnitOfTimePeriodOrIntervalCode = "5M"
        };

        var actual = Map.MapObject<ADI_AnimalDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("oV", true)]
    public void Validation_RequiredAnimalDispositionCode(string animalDispositionCode, bool isValidExpected)
    {
        var subject = new ADI_AnimalDisposition();
        subject.Date = "QW7wVLZm";
        subject.AnimalDispositionCode = animalDispositionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("QW7wVLZm", true)]
    public void Validation_RequiredDate(string date, bool isValidExpected)
    {
        var subject = new ADI_AnimalDisposition();
        subject.AnimalDispositionCode = "oV";
        subject.Date = date;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "5M", true)]
    [InlineData(0, "5M", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new ADI_AnimalDisposition();
        subject.AnimalDispositionCode = "oV";
        subject.Date = "QW7wVLZm";
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}