using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MS2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "MS2*2M*Q*KE*v";

        var expected = new MS2_EquipmentOrContainerOwnerAndType()
        {
            StandardCarrierAlphaCode = "2M",
            EquipmentNumber = "Q",
            EquipmentDescriptionCode = "KE",
            EquipmentNumberCheckDigit = "v",
        };

        var actual = Map.MapObject<MS2_EquipmentOrContainerOwnerAndType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string equipmentNumber, bool isValidExpected)
    {
        var subject = new MS2_EquipmentOrContainerOwnerAndType();
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        subject.EquipmentNumber = equipmentNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("1", "", false)]
    public void Validation_ARequiresBEquipmentNumberCheckDigit(string equipmentNumberCheckDigit, string equipmentNumber, bool isValidExpected)
    {
        var subject = new MS2_EquipmentOrContainerOwnerAndType();
        subject.EquipmentNumberCheckDigit = equipmentNumberCheckDigit;
        subject.EquipmentNumber = equipmentNumber;

        if (!string.IsNullOrEmpty(equipmentNumber))
            subject.StandardCarrierAlphaCode = "1234"; //required for a different validation

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}
