using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C063Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "6*6*5*3*4*9";

        var expected = new C063_ChangeQuantities()
        {
            Quantity = 6,
            Quantity2 = 6,
            Quantity3 = 5,
            Quantity4 = 3,
            Quantity5 = 4,
            Quantity6 = 9,
        };

        var actual = Map.MapObject<C063_ChangeQuantities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(6, 5, false)]
    [InlineData(0, 5, true)]
    [InlineData(6, 0, true)]
    public void Validation_OnlyOneOfQuantity2(decimal quantity2, decimal quantity3, bool isValidExpected)
    {
        var subject = new C063_ChangeQuantities();
        if (quantity2 > 0)
            subject.Quantity2 = quantity2;
        if (quantity3 > 0)
            subject.Quantity3 = quantity3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

}