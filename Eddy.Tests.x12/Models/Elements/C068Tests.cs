using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C068Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "*S*4y*j*AF*u*Ru*U*ZY*t*5Y*P*RO*7*nx*F*o0";

        var expected = new C068_CompositeIngredientInformation()
        {
            FreeFormMessageText = "S",
            LanguageCode = "4y",
            FreeFormMessageText2 = "j",
            LanguageCode2 = "AF",
            FreeFormMessageText3 = "u",
            LanguageCode3 = "Ru",
            FreeFormMessageText4 = "U",
            LanguageCode4 = "ZY",
            FreeFormMessageText5 = "t",
            LanguageCode5 = "5Y",
            FreeFormMessageText6 = "P",
            LanguageCode6 = "RO",
            FreeFormMessageText7 = "7",
            LanguageCode7 = "nx",
            FreeFormMessageText8 = "F",
            LanguageCode8 = "o0",
        };

        var actual = Map.MapObject<C068_CompositeIngredientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("S", true)]
    public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText = freeFormMessageText;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("4y", true)]
    public void Validation_RequiredLanguageCode(string languageCode, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = languageCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("j", "AF", true)]
    [InlineData("", "AF", false)]
    [InlineData("j", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText2(string freeFormMessageText2, string languageCode2, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText2 = freeFormMessageText2;
        subject.LanguageCode2 = languageCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("u", "Ru", true)]
    [InlineData("", "Ru", false)]
    [InlineData("u", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText3(string freeFormMessageText3, string languageCode3, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText3 = freeFormMessageText3;
        subject.LanguageCode3 = languageCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("U", "ZY", true)]
    [InlineData("", "ZY", false)]
    [InlineData("U", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText4(string freeFormMessageText4, string languageCode4, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText4 = freeFormMessageText4;
        subject.LanguageCode4 = languageCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("t", "5Y", true)]
    [InlineData("", "5Y", false)]
    [InlineData("t", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText5(string freeFormMessageText5, string languageCode5, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText5 = freeFormMessageText5;
        subject.LanguageCode5 = languageCode5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("P", "RO", true)]
    [InlineData("", "RO", false)]
    [InlineData("P", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText6(string freeFormMessageText6, string languageCode6, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText6 = freeFormMessageText6;
        subject.LanguageCode6 = languageCode6;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("7", "nx", true)]
    [InlineData("", "nx", false)]
    [InlineData("7", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText7(string freeFormMessageText7, string languageCode7, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText7 = freeFormMessageText7;
        subject.LanguageCode7 = languageCode7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("F", "o0", true)]
    [InlineData("", "o0", false)]
    [InlineData("F", "", false)]
    public void Validation_AllAreRequiredFreeFormMessageText8(string freeFormMessageText8, string languageCode8, bool isValidExpected)
    {
        var subject = new C068_CompositeIngredientInformation();
        subject.FreeFormMessageText = "S";
        subject.LanguageCode = "4y";
        subject.FreeFormMessageText8 = freeFormMessageText8;
        subject.LanguageCode8 = languageCode8;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}