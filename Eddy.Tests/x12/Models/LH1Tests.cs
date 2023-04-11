using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LH1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LH1*cx*6*cRiao0*UgQyVS*cw1cKrH8LHWAQlbLII7H1GgRjU9imv*xQ*2*9*e*ZSe*4tADW*Xa1vtUaTWJ4wjZMTb34coemFkVFoBx";

        var expected = new LH1_HazardousIdentificationInformation()
        {
            UnitOrBasisForMeasurementCode = "cx",
            LadingQuantity = 6,
            UNNAIdentificationCode = "cRiao0",
            HazardousMaterialsPage = "UgQyVS",
            CommodityCode = "cw1cKrH8LHWAQlbLII7H1GgRjU9imv",
            UnitOrBasisForMeasurementCode2 = "xQ",
            Quantity = 2,
            CompartmentIDCode = "9",
            ResidueIndicatorCode = "e",
            PackingGroupCode = "ZSe",
            InterimHazardousMaterialRegulatoryNumber = "4tADW",
            IndustryCode = "Xa1vtUaTWJ4wjZMTb34coemFkVFoBx",
        };

        var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("cx", true)]
    public void Validatation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new LH1_HazardousIdentificationInformation();
        subject.UnitOrBasisForMeasurementCode = "AB";
        subject.LadingQuantity = 1;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
    {
        var subject = new LH1_HazardousIdentificationInformation();
        subject.UnitOrBasisForMeasurementCode = "AB";
        if (ladingQuantity > 0)
            subject.LadingQuantity = ladingQuantity;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity, bool isValidExpected)
    {
        var subject = new LH1_HazardousIdentificationInformation();
        subject.UnitOrBasisForMeasurementCode = "AB";
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        subject.LadingQuantity = 1;
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}