using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AOITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AOI*a*p*u*gN*9*Py*Bx*8*f3*6*0R5caJ85*6*UJ";

        var expected = new AOI_AnimalOffspringFetusIdentification
        {
            YesNoConditionOrResponseCode = "a",
            ReferenceIdentification = "p",
            GenderCode = "u",
            OffspringFetusStatusCode = "gN",
            TestPeriodOrIntervalValue = 9,
            UnitOfTimePeriodOrIntervalCode = "Py",
            AnimalDispositionCode = "Bx",
            TestPeriodOrIntervalValue2 = 8,
            UnitOfTimePeriodOrIntervalCode2 = "f3",
            ReferenceIdentification2 = "6",
            Date = "0R5caJ85",
            TestPeriodOrIntervalValue3 = 6,
            UnitOfTimePeriodOrIntervalCode3 = "UJ"
        };

        var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("a", true)]
    public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.ReferenceIdentification = "p";
        subject.GenderCode = "u";
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("p", true)]
    public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.GenderCode = "u";
        subject.ReferenceIdentification = referenceIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("u", true)]
    public void Validatation_RequiredGenderCode(string genderCode, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.ReferenceIdentification = "p";
        subject.GenderCode = genderCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("Bx", 8, true)]
    [InlineData("", 8, false)]
    [InlineData("Bx", 0, false)]
    public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.ReferenceIdentification = "p";
        subject.GenderCode = "u";
        subject.AnimalDispositionCode = animalDispositionCode;
        if (testPeriodOrIntervalValue2 > 0)
        {
            subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
            subject.UnitOfTimePeriodOrIntervalCode2 = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "f3", true)]
    [InlineData(0, "f3", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.ReferenceIdentification = "p";
        subject.GenderCode = "u";
        if (testPeriodOrIntervalValue2 > 0)
        {
            subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
            subject.AnimalDispositionCode = "AB";
        }
        subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", 0, true)]
    [InlineData("", "0R5caJ85", 0, true)]
    [InlineData("6", "0R5caJ85", 1, true)]
    [InlineData("6", "", 0, false)]
    public void Validation_NEWReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.ReferenceIdentification = "p";
        subject.GenderCode = "u";
        subject.ReferenceIdentification2 = referenceIdentification2;

        subject.Date = date;
        if (testPeriodOrIntervalValue3 > 0)
        {
            subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
            subject.UnitOfTimePeriodOrIntervalCode3 = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(6, "UJ", true)]
    [InlineData(0, "UJ", false)]
    [InlineData(6, "", false)]
    public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
    {
        var subject = new AOI_AnimalOffspringFetusIdentification();
        subject.YesNoConditionOrResponseCode = "a";
        subject.ReferenceIdentification = "p";
        subject.GenderCode = "u";
        if (testPeriodOrIntervalValue3 > 0)
            subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
        subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}