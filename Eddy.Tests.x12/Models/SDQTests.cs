using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SDQTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "SDQ*BC*2*Zg*1*rg*2*Wf*3*VD*4*7Y*5*Rj*6*OO*7*kq*8*Q1*9*AB*10*x";

        var expected = new SDQ_DestinationQuantity()
        {
            UnitOrBasisForMeasurementCode = "BC",
            IdentificationCodeQualifier = "2",
            IdentificationCode = "Zg",
            Quantity = 1,
            IdentificationCode2 = "rg",
            Quantity2 = 2,
            IdentificationCode3 = "Wf",
            Quantity3 = 3,
            IdentificationCode4 = "VD",
            Quantity4 = 4,
            IdentificationCode5 = "7Y",
            Quantity5 = 5,
            IdentificationCode6 = "Rj",
            Quantity6 = 6,
            IdentificationCode7 = "OO",
            Quantity7 = 7,
            IdentificationCode8 = "kq",
            Quantity8 = 8,
            IdentificationCode9 = "Q1",
            Quantity9 = 9,
            IdentificationCode10 = "AB",
            Quantity10 = 10,
            LocationIdentifier = "x",
        };

        var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;

        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = identificationCode;
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";

        if (quantity > 0)
            subject.Quantity = quantity;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode10(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;

        subject.IdentificationCode10 = identificationCode;
        if (quantity > 0)
            subject.Quantity10 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode2(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode2 = identificationCode;
        if (quantity > 0)
            subject.Quantity2 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode3(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode3 = identificationCode;
        if (quantity > 0)
            subject.Quantity3 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode4(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode4 = identificationCode;
        if (quantity > 0)
            subject.Quantity4 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode5(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode5 = identificationCode;
        if (quantity > 0)
            subject.Quantity5 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode6(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode6 = identificationCode;
        if (quantity > 0)
            subject.Quantity6 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode7(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode7 = identificationCode;
        if (quantity > 0)
            subject.Quantity7 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode8(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode8 = identificationCode;
        if (quantity > 0)
            subject.Quantity8 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredIdentificationCode9(string identificationCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SDQ_DestinationQuantity();
        subject.IdentificationCode = "V1";
        subject.UnitOrBasisForMeasurementCode = "Q1";
        subject.Quantity = 1;
        subject.IdentificationCode9 = identificationCode;
        if (quantity > 0)
            subject.Quantity9 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}