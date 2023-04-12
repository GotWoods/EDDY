using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C005Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "Q*Z*E*r*h";

        var expected = new C005_ToothSurface()
        {
            ToothSurfaceCode = "Q",
            ToothSurfaceCode2 = "Z",
            ToothSurfaceCode3 = "E",
            ToothSurfaceCode4 = "r",
            ToothSurfaceCode5 = "h",
        };

        var actual = Map.MapObject<C005_ToothSurface>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Q", true)]
    public void Validation_RequiredToothSurfaceCode(string toothSurfaceCode, bool isValidExpected)
    {
        var subject = new C005_ToothSurface();
        subject.ToothSurfaceCode = toothSurfaceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}