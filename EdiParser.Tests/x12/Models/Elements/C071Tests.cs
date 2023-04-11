using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C071Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "*h*5w*m*oC*O*bZ*S*8r";

        var expected = new C071_CompositeMultipleLanguageTextInformation()
        {
            FreeFormMessageText = "h",
            LanguageCode = "5w",
            FreeFormMessageText2 = "m",
            LanguageCode2 = "oC",
            FreeFormMessageText3 = "O",
            LanguageCode3 = "bZ",
            FreeFormMessageText4 = "S",
            LanguageCode4 = "8r",
        };

        var actual = Map.MapObject<C071_CompositeMultipleLanguageTextInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("h", true)]
    public void Validatation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
    {
        var subject = new C071_CompositeMultipleLanguageTextInformation();
        subject.LanguageCode = "5w";
        subject.FreeFormMessageText = freeFormMessageText;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5w", true)]
    public void Validatation_RequiredLanguageCode(string languageCode, bool isValidExpected)
    {
        var subject = new C071_CompositeMultipleLanguageTextInformation();
        subject.FreeFormMessageText = "h";
        subject.LanguageCode = languageCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("m", "oC", true)]
    [InlineData("", "oC", false)]
    [InlineData("m", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText2(string freeFormMessageText2, string languageCode2, bool isValidExpected)
    {
        var subject = new C071_CompositeMultipleLanguageTextInformation();
        subject.FreeFormMessageText = "h";
        subject.LanguageCode = "5w";
        subject.FreeFormMessageText2 = freeFormMessageText2;
        subject.LanguageCode2 = languageCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("O", "bZ", true)]
    [InlineData("", "bZ", false)]
    [InlineData("O", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText3(string freeFormMessageText3, string languageCode3, bool isValidExpected)
    {
        var subject = new C071_CompositeMultipleLanguageTextInformation();
        subject.FreeFormMessageText = "h";
        subject.LanguageCode = "5w";
        subject.FreeFormMessageText3 = freeFormMessageText3;
        subject.LanguageCode3 = languageCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("S", "8r", true)]
    [InlineData("", "8r", false)]
    [InlineData("S", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText4(string freeFormMessageText4, string languageCode4, bool isValidExpected)
    {
        var subject = new C071_CompositeMultipleLanguageTextInformation();
        subject.FreeFormMessageText = "h";
        subject.LanguageCode = "5w";
        subject.FreeFormMessageText4 = freeFormMessageText4;
        subject.LanguageCode4 = languageCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}