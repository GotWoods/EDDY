using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LH2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LH2*KyOdbOGxF4htmwXgIa2zUwBkJ1eeLI*L*6oSD55au38ACS3joN89Y3JoS1V0FPer6XkdiiDNh*gUTqTcSRMUqdubb9ZIJcV88YW*JT*L1*5*0z*5*VG*5*3*9";

        var expected = new LH2_HazardousClassificationInformation()
        {
            HazardousClassificationCode = "KyOdbOGxF4htmwXgIa2zUwBkJ1eeLI",
            HazardousClassQualifier = "L",
            HazardousPlacardNotationCode = "6oSD55au38ACS3joN89Y3JoS1V0FPer6XkdiiDNh",
            HazardousEndorsementCode = "gUTqTcSRMUqdubb9ZIJcV88YW",
            ReportableQuantityCode = "JT",
            UnitOrBasisForMeasurementCode = "L1",
            Temperature = 5,
            UnitOrBasisForMeasurementCode2 = "0z",
            Temperature2 = 5,
            UnitOrBasisForMeasurementCode3 = "VG",
            Temperature3 = 5,
            WeightUnitCode = "3",
            NetExplosiveQuantity = 9,
        };

        var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, bool isValidExpected)
    {
        var subject = new LH2_HazardousClassificationInformation();
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        if (temperature > 0)
            subject.Temperature = temperature;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal temperature2, bool isValidExpected)
    {
        var subject = new LH2_HazardousClassificationInformation();
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        if (temperature2 > 0)
            subject.Temperature2 = temperature2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal temperature3, bool isValidExpected)
    {
        var subject = new LH2_HazardousClassificationInformation();
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
        if (temperature3 > 0)
            subject.Temperature3 = temperature3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, int netExplosiveQuantity, bool isValidExpected)
    {
        var subject = new LH2_HazardousClassificationInformation();
        subject.WeightUnitCode = weightUnitCode;
        if (netExplosiveQuantity > 0)
            subject.NetExplosiveQuantity = netExplosiveQuantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}