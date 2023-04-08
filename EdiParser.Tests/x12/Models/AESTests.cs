using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AESTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AES*5*X*x*R*k";

        var expected = new AES_AutomaticEquipmentIdentificationSiteInformation
        {
            AutomaticEquipmentIdentificationSiteStatusCode = "5",
            MovementTypeCode = "X",
            TrainTerminationStatusCode = "x",
            AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "R",
            IndustryCode = "k"
        };

        var actual = Map.MapObject<AES_AutomaticEquipmentIdentificationSiteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5", true)]
    public void Validatation_RequiredAutomaticEquipmentIdentificationSiteStatusCode(string automaticEquipmentIdentificationSiteStatusCode, bool isValidExpected)
    {
        var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
        subject.MovementTypeCode = "X";
        subject.TrainTerminationStatusCode = "x";
        subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "R";
        subject.AutomaticEquipmentIdentificationSiteStatusCode = automaticEquipmentIdentificationSiteStatusCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("X", true)]
    public void Validatation_RequiredMovementTypeCode(string movementTypeCode, bool isValidExpected)
    {
        var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
        subject.AutomaticEquipmentIdentificationSiteStatusCode = "5";
        subject.TrainTerminationStatusCode = "x";
        subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "R";
        subject.MovementTypeCode = movementTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("x", true)]
    public void Validatation_RequiredTrainTerminationStatusCode(string trainTerminationStatusCode, bool isValidExpected)
    {
        var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
        subject.AutomaticEquipmentIdentificationSiteStatusCode = "5";
        subject.MovementTypeCode = "X";
        subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = "R";
        subject.TrainTerminationStatusCode = trainTerminationStatusCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("R", true)]
    public void Validatation_RequiredAutomaticEquipmentIdentificationConsistConfidenceLevelCode(string automaticEquipmentIdentificationConsistConfidenceLevelCode, bool isValidExpected)
    {
        var subject = new AES_AutomaticEquipmentIdentificationSiteInformation();
        subject.AutomaticEquipmentIdentificationSiteStatusCode = "5";
        subject.MovementTypeCode = "X";
        subject.TrainTerminationStatusCode = "x";
        subject.AutomaticEquipmentIdentificationConsistConfidenceLevelCode = automaticEquipmentIdentificationConsistConfidenceLevelCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}