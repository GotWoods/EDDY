using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class TD3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "TD3*DZ*h*m*f*6*Hz*G*Id*w*3KQd";

        var expected = new TD3_CarrierDetailsEquipment()
        {
            EquipmentDescriptionCode = "DZ",
            EquipmentInitial = "h",
            EquipmentNumber = "m",
            WeightQualifier = "f",
            Weight = 6,
            UnitOrBasisForMeasurementCode = "Hz",
            OwnershipCode = "G",
            SealStatusCode = "Id",
            SealNumber = "w",
            EquipmentTypeCode = "3KQd",
        };

        var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", false)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_OnlyOneOfEquipmentDescriptionCode(string equipmentDescriptionCode, string equipmentTypeCode, bool isValidExpected)
    {
        var subject = new TD3_CarrierDetailsEquipment();
        subject.EquipmentDescriptionCode = equipmentDescriptionCode;
        subject.EquipmentTypeCode = equipmentTypeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
    {
        var subject = new TD3_CarrierDetailsEquipment();
        subject.EquipmentInitial = equipmentInitial;
        subject.EquipmentNumber = equipmentNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 1, true)]
    [InlineData("v1", 0, false)]
    public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
    {
        var subject = new TD3_CarrierDetailsEquipment();
        subject.WeightQualifier = weightQualifier;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new TD3_CarrierDetailsEquipment();
        if (weight > 0)
            subject.Weight = weight;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}