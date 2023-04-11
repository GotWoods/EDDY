using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C059Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "4C*iz*nE";

        var expected = new C059_DrugUseReviewDUR()
        {
            ReasonForServiceCode = "4C",
            ProfessionalServiceCode = "iz",
            ResultOfServiceCode = "nE",
        };

        var actual = Map.MapObject<C059_DrugUseReviewDUR>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("4C", true)]
    public void Validatation_RequiredReasonForServiceCode(string reasonForServiceCode, bool isValidExpected)
    {
        var subject = new C059_DrugUseReviewDUR();
        subject.ProfessionalServiceCode = "iz";
        subject.ResultOfServiceCode = "nE";
        subject.ReasonForServiceCode = reasonForServiceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("iz", true)]
    public void Validatation_RequiredProfessionalServiceCode(string professionalServiceCode, bool isValidExpected)
    {
        var subject = new C059_DrugUseReviewDUR();
        subject.ReasonForServiceCode = "4C";
        subject.ResultOfServiceCode = "nE";
        subject.ProfessionalServiceCode = professionalServiceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("nE", true)]
    public void Validatation_RequiredResultOfServiceCode(string resultOfServiceCode, bool isValidExpected)
    {
        var subject = new C059_DrugUseReviewDUR();
        subject.ReasonForServiceCode = "4C";
        subject.ProfessionalServiceCode = "iz";
        subject.ResultOfServiceCode = resultOfServiceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}