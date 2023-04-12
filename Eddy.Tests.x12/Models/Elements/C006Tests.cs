using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C006Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "T*T*o*x*J";

        var expected = new C006_OralCavityDesignation()
        {
            OralCavityDesignationCode = "T",
            OralCavityDesignationCode2 = "T",
            OralCavityDesignationCode3 = "o",
            OralCavityDesignationCode4 = "x",
            OralCavityDesignationCode5 = "J",
        };

        var actual = Map.MapObject<C006_OralCavityDesignation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("T", true)]
    public void Validation_RequiredOralCavityDesignationCode(string oralCavityDesignationCode, bool isValidExpected)
    {
        var subject = new C006_OralCavityDesignation();
        subject.OralCavityDesignationCode = oralCavityDesignationCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}