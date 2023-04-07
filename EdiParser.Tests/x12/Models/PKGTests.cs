using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class PKGTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "PKG*g*w*Rc*h*7*QF*jz";

        var expected = new PKG_MarkingPackagingLoading()
        {
            ItemDescriptionTypeCode = "g",
            PackagingCharacteristicCode = "w",
            AgencyQualifierCode = "Rc",
            PackagingDescriptionCode = "h",
            Description = "7",
            UnitLoadOptionCode = "QF",
            LanguageCode = "jz",
        };

        var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBPackagingDescriptionCode(string packagingDescriptionCode, string agencyQualifierCode, bool isValidExpected)
    {
        var subject = new PKG_MarkingPackagingLoading();
        subject.PackagingDescriptionCode = packagingDescriptionCode;
        subject.AgencyQualifierCode = agencyQualifierCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBDescription(string description, string itemDescriptionTypeCode, bool isValidExpected)
    {
        var subject = new PKG_MarkingPackagingLoading();
        subject.Description = description;
        subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
    {
        var subject = new PKG_MarkingPackagingLoading();
        subject.LanguageCode = languageCode;
        subject.Description = description;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}