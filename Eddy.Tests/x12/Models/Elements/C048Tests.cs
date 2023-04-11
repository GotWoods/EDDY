using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C048Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "2D*J2*Ih*v";

        var expected = new C048_CompositeUseOfProceeds()
        {
            UseOfProceedsCode = "2D",
            RefinanceTypeCode = "J2",
            UseOfProceedsCode2 = "Ih",
            YesNoConditionOrResponseCode = "v",
        };

        var actual = Map.MapObject<C048_CompositeUseOfProceeds>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("2D", true)]
    public void Validatation_RequiredUseOfProceedsCode(string useOfProceedsCode, bool isValidExpected)
    {
        var subject = new C048_CompositeUseOfProceeds();
        subject.UseOfProceedsCode = useOfProceedsCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}