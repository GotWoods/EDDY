using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C040Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "Pc*e*ko*U*vm*j";

        var expected = new C040_ReferenceIdentifier()
        {
            ReferenceIdentificationQualifier = "Pc",
            ReferenceIdentification = "e",
            ReferenceIdentificationQualifier2 = "ko",
            ReferenceIdentification2 = "U",
            ReferenceIdentificationQualifier3 = "vm",
            ReferenceIdentification3 = "j",
        };

        var actual = Map.MapObject<C040_ReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Pc", true)]
    public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
    {
        var subject = new C040_ReferenceIdentifier();
        subject.ReferenceIdentification = "e";
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("e", true)]
    public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
    {
        var subject = new C040_ReferenceIdentifier();
        subject.ReferenceIdentificationQualifier = "Pc";
        subject.ReferenceIdentification = referenceIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("ko", "U", true)]
    [InlineData("", "U", false)]
    [InlineData("ko", "", false)]
    public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
    {
        var subject = new C040_ReferenceIdentifier();
        subject.ReferenceIdentificationQualifier = "Pc";
        subject.ReferenceIdentification = "e";
        subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
        subject.ReferenceIdentification2 = referenceIdentification2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("vm", "j", true)]
    [InlineData("", "j", false)]
    [InlineData("vm", "", false)]
    public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification3, bool isValidExpected)
    {
        var subject = new C040_ReferenceIdentifier();
        subject.ReferenceIdentificationQualifier = "Pc";
        subject.ReferenceIdentification = "e";
        subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
        subject.ReferenceIdentification3 = referenceIdentification3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}