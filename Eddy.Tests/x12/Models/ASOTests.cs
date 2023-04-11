using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ASOTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ASO*o*BJ*Oe*u*O**7*5*6*SE*W";

        var expected = new ASO_AssetOwnership
        {
            PropertyOwnershipRightsCode = "o",
            TypeOfPersonalOrBusinessAssetCode = "BJ",
            TypeOfPersonalOrBusinessAssetCode2 = "Oe",
            FreeFormMessageText = "u",
            GeneralPropertyOwnershipCode = "O",
            //AmountQualifyingDescription = "",
            MonetaryAmount = 7,
            PercentageAsDecimal = 5,
            Quantity = 6,
            ReferenceIdentificationQualifier = "SE",
            ReferenceIdentification = "W"
        };

        var actual = Map.MapObject<ASO_AssetOwnership>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
    {
        var subject = new ASO_AssetOwnership();
        subject.TypeOfPersonalOrBusinessAssetCode = "BJ";
        subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("BJ", true)]
    public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
    {
        var subject = new ASO_AssetOwnership();
        subject.PropertyOwnershipRightsCode = "o";
        subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("SE", "W", true)]
    [InlineData("", "W", false)]
    [InlineData("SE", "", false)]
    public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
    {
        var subject = new ASO_AssetOwnership();
        subject.PropertyOwnershipRightsCode = "o";
        subject.TypeOfPersonalOrBusinessAssetCode = "BJ";
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
        subject.ReferenceIdentification = referenceIdentification;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}