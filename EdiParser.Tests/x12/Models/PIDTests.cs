using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class PIDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "PID*c*mp*tb*U*x*ex*i*o*Lk*Ex";

        var expected = new PID_ProductItemDescription()
        {
            ItemDescriptionTypeCode = "c",
            ProductProcessCharacteristicCode = "mp",
            AgencyQualifierCode = "tb",
            ProductDescriptionCode = "U",
            Description = "x",
            SurfaceLayerPositionCode = "ex",
            SourceSubqualifier = "i",
            YesNoConditionOrResponseCode = "o",
            LanguageCode = "Lk",
            ProductServiceConditionCode = "Ex",
        };

        var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("c", true)]
    public void Validatation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
    {
        var subject = new PID_ProductItemDescription();
        subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
    {
        var subject = new PID_ProductItemDescription();
        subject.ItemDescriptionTypeCode = "c";
        subject.ProductDescriptionCode = productDescriptionCode;
        subject.AgencyQualifierCode = agencyQualifierCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
    {
        var subject = new PID_ProductItemDescription();
        subject.ItemDescriptionTypeCode = "c";
        subject.SourceSubqualifier = sourceSubqualifier;
        subject.AgencyQualifierCode = agencyQualifierCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("1", "", false)]
    public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string productDescriptionCode, bool isValidExpected)
    {
        var subject = new PID_ProductItemDescription();
        subject.ItemDescriptionTypeCode = "c";
        subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        subject.ProductDescriptionCode = productDescriptionCode;
        if (productDescriptionCode != "")
            subject.AgencyQualifierCode = "AC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
    {
        var subject = new PID_ProductItemDescription();
        subject.ItemDescriptionTypeCode = "c";
        subject.LanguageCode = languageCode;
        subject.Description = description;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}