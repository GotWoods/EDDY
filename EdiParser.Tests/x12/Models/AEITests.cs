using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AEITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AEI*bC*7*k";

        var expected = new AEI_EquipmentInformationSummary
        {
            EquipmentDescriptionCode = "bC",
            Quantity = 7,
            YesNoConditionOrResponseCode = "k"
        };

        var actual = Map.MapObject<AEI_EquipmentInformationSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("bC", true)]
    public void Validatation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
    {
        var subject = new AEI_EquipmentInformationSummary();
        subject.Quantity = 7;
        subject.YesNoConditionOrResponseCode = "k";
        subject.EquipmentDescriptionCode = equipmentDescriptionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredQuantity(decimal quantity, bool isValidExpected)
    {
        var subject = new AEI_EquipmentInformationSummary();
        subject.EquipmentDescriptionCode = "bC";
        subject.YesNoConditionOrResponseCode = "k";
        if (quantity > 0)
            subject.Quantity = quantity;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("k", true)]
    public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
    {
        var subject = new AEI_EquipmentInformationSummary();
        subject.EquipmentDescriptionCode = "bC";
        subject.Quantity = 7;
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}