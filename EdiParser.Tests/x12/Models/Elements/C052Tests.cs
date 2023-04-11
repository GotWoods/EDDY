using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C052Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "e*y*i*Y";

        var expected = new C052_MedicareStatusCode()
        {
            MedicarePlanCode = "e",
            EligibilityReasonCode = "y",
            EligibilityReasonCode2 = "i",
            EligibilityReasonCode3 = "Y",
        };

        var actual = Map.MapObject<C052_MedicareStatusCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("e", true)]
    public void Validatation_RequiredMedicarePlanCode(string medicarePlanCode, bool isValidExpected)
    {
        var subject = new C052_MedicareStatusCode();
        subject.MedicarePlanCode = medicarePlanCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}