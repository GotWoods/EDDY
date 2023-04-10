using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C030Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "4*2*1";

        var expected = new C030_PositionInSegment()
        {
            ElementPositionInSegment = 4,
            ComponentDataElementPositionInComposite = 2,
            RepeatingDataElementPosition = 1,
        };

        var actual = Map.MapObject<C030_PositionInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(4, true)]
    public void Validatation_RequiredElementPositionInSegment(int elementPositionInSegment, bool isValidExpected)
    {
        var subject = new C030_PositionInSegment();
        if (elementPositionInSegment > 0)
            subject.ElementPositionInSegment = elementPositionInSegment;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}