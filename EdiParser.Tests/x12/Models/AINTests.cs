using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AINTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AIN*UR*u*5*2*P*t*2*B*3*XN*3*V*C";

        var expected = new AIN_Income
        {
            TypeOfIncomeCode = "UR",
            FrequencyCode = "u",
            MonetaryAmount = 5,
            Quantity = 2,
            YesNoConditionOrResponseCode = "P",
            ReferenceIdentification = "t",
            AmountQualifierCode = "2",
            TaxTreatmentCode = "B",
            EarningsRateOfPay = 3,
            UnitOrBasisForMeasurementCode = "XN",
            Quantity2 = 3,
            IndustryCode = "V",
            Description = "C"
        };

        var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("UR", true)]
    public void Validatation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
    {
        var subject = new AIN_Income();
        subject.FrequencyCode = "u";
        subject.MonetaryAmount = 5;
        subject.TypeOfIncomeCode = typeOfIncomeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("u", true)]
    public void Validatation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
    {
        var subject = new AIN_Income();
        subject.TypeOfIncomeCode = "UR";
        subject.MonetaryAmount = 5;
        subject.FrequencyCode = frequencyCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new AIN_Income();
        subject.TypeOfIncomeCode = "UR";
        subject.FrequencyCode = "u";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}