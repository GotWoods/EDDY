using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N7Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N7*p*G*1*d*Rjw*JQ*S*o*W*s*kF*IJ*XJG*I*8hop*j*f*F*mT*5*9*g6Ow*z9*U";

        var expected = new N7_EquipmentDetails()
        {
            EquipmentInitial = "p",
            EquipmentNumber = "G",
            Weight = 1,
            WeightQualifier = "d",
            TareWeight = "Rjw",
            WeightAllowance = "JQ",
            Dunnage = "S",
            Volume = "o",
            VolumeUnitQualifier = "W",
            OwnershipCode = "s",
            EquipmentDescriptionCode = "kF",
            StandardCarrierAlphaCode = "IJ",
            TemperatureControl = "XJG",
            Position = "I",
            EquipmentLength = "8hop",
            TareQualifierCode = "j",
            WeightUnitCode = "f",
            EquipmentNumberCheckDigit = "F",
            TypeOfServiceCode = "mT",
            Height = 5,
            Width = 9,
            EquipmentTypeCode = "g6Ow",
            StandardCarrierAlphaCode2 = "z9",
            CarTypeCode = "U",
        };

        var actual = Map.MapObject<N7_EquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
    {
        var subject = new N7_EquipmentDetails();
        subject.EquipmentNumber = equipmentNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
    {
        var subject = new N7_EquipmentDetails();
        subject.EquipmentNumber = "12";
        if (weight > 0)
            subject.Weight = weight;
        subject.WeightQualifier = weightQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("123", "1", true)]
    [InlineData("", "1", false)]
    [InlineData("123", "", false)]
    public void Validation_AllAreRequiredTareWeight(string tareWeight, string tareQualifierCode, bool isValidExpected)
    {
        var subject = new N7_EquipmentDetails();
        subject.EquipmentNumber = "12";
        subject.TareWeight = tareWeight;
        subject.TareQualifierCode = tareQualifierCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "1", true)]
    [InlineData("", "1", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredVolume(string volume, string volumeUnitQualifier, bool isValidExpected)
    {
        var subject = new N7_EquipmentDetails();
        subject.EquipmentNumber = "12";

        subject.Volume = volume;
        subject.VolumeUnitQualifier = volumeUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}