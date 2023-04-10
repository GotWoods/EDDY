using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C076Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "F*MQ*g*DM*g*G6";

        var expected = new C076_CompositeIdentificationCodes()
        {
            IdentificationCodeQualifier = "F",
            IdentificationCode = "MQ",
            IdentificationCodeQualifier2 = "g",
            IdentificationCode2 = "DM",
            IdentificationCodeQualifier3 = "g",
            IdentificationCode3 = "G6",
        };

        var actual = Map.MapObject<C076_CompositeIdentificationCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("F", true)]
    public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
    {
        var subject = new C076_CompositeIdentificationCodes();
        subject.IdentificationCode = "MQ";
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("MQ", true)]
    public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
    {
        var subject = new C076_CompositeIdentificationCodes();
        subject.IdentificationCodeQualifier = "F";
        subject.IdentificationCode = identificationCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("g", "DM", true)]
    [InlineData("", "DM", false)]
    [InlineData("g", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
    {
        var subject = new C076_CompositeIdentificationCodes();
        subject.IdentificationCodeQualifier = "F";
        subject.IdentificationCode = "MQ";
        subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
        subject.IdentificationCode2 = identificationCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("g", "G6", true)]
    [InlineData("", "G6", false)]
    [InlineData("g", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
    {
        var subject = new C076_CompositeIdentificationCodes();
        subject.IdentificationCodeQualifier = "F";
        subject.IdentificationCode = "MQ";
        subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
        subject.IdentificationCode3 = identificationCode3;
        if (identificationCodeQualifier3 != "")
        {
            subject.IdentificationCodeQualifier2 = "AB";
            subject.IdentificationCode2 = "CA";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "g", true)]
    [InlineData("g", "", false)]
    public void Validation_ARequiresBIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCodeQualifier2, bool isValidExpected)
    {
        var subject = new C076_CompositeIdentificationCodes();
        subject.IdentificationCodeQualifier = "F";
        subject.IdentificationCode = "MQ";
        subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
        subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;

        if (identificationCodeQualifier2 != "")
            subject.IdentificationCode2 = "AQ";

        if (identificationCodeQualifier3 != "")
            subject.IdentificationCode3 = "AQ";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}