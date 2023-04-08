using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ANITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ANI*3*T2qUplCm*taGU3aow*3*TM*p*0*UeXJ48tW*W";

        var expected = new ANI_AnimalIdentification
        {
            ReferenceIdentification = "3",
            Date = "T2qUplCm",
            Date2 = "taGU3aow",
            TestPeriodOrIntervalValue = 3,
            UnitOfTimePeriodOrIntervalCode = "TM",
            ReferenceIdentification2 = "p",
            ReferenceIdentification3 = "0",
            Date3 = "UeXJ48tW",
            ReferenceIdentification4 = "W"
        };

        var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("3", true)]
    public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
    {
        var subject = new ANI_AnimalIdentification();
        subject.Date = "T2qUplCm";
        subject.Date2 = "taGU3aow";
        subject.ReferenceIdentification = referenceIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("T2qUplCm", true)]
    public void Validatation_RequiredDate(string date, bool isValidExpected)
    {
        var subject = new ANI_AnimalIdentification();
        subject.ReferenceIdentification = "3";
        subject.Date2 = "taGU3aow";
        subject.Date = date;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("taGU3aow", true)]
    public void Validatation_RequiredDate2(string date2, bool isValidExpected)
    {
        var subject = new ANI_AnimalIdentification();
        subject.ReferenceIdentification = "3";
        subject.Date = "T2qUplCm";
        subject.Date2 = date2;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(3, "TM", true)]
    [InlineData(0, "TM", false)]
    [InlineData(3, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
    {
        var subject = new ANI_AnimalIdentification();
        subject.ReferenceIdentification = "3";
        subject.Date = "T2qUplCm";
        subject.Date2 = "taGU3aow";
        if (testPeriodOrIntervalValue > 0)
            subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}