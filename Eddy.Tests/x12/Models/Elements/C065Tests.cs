using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C065Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "Q*d*o*6*k*g*w*x*i*2";

        var expected = new C065_ProductUnitIndicator()
        {
            YesNoConditionOrResponseCode = "Q",
            YesNoConditionOrResponseCode2 = "d",
            YesNoConditionOrResponseCode3 = "o",
            YesNoConditionOrResponseCode4 = "6",
            YesNoConditionOrResponseCode5 = "k",
            YesNoConditionOrResponseCode6 = "g",
            YesNoConditionOrResponseCode7 = "w",
            YesNoConditionOrResponseCode8 = "x",
            YesNoConditionOrResponseCode9 = "i",
            YesNoConditionOrResponseCode10 = "2",
        };

        var actual = Map.MapObject<C065_ProductUnitIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

}