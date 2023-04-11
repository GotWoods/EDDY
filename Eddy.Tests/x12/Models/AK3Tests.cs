using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AK3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK3*9WG*2*1Qvl8d*w9R";

        var expected = new AK3_DataSegmentNote()
        {
            SegmentIDCode = "9WG",
            SegmentPositionInTransactionSet = 2,
            LoopIdentifierCode = "1Qvl8d",
            SegmentSyntaxErrorCode = "w9R",
        };

        var actual = Map.MapObject<AK3_DataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("9WG", true)]
    public void Validatation_RequiredSegmentIDCode(string segmentIdCode, bool isValidExpected)
    {
        var subject = new AK3_DataSegmentNote();
        subject.SegmentPositionInTransactionSet = 1;
        subject.SegmentIDCode = segmentIdCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
    {
        var subject = new AK3_DataSegmentNote();
        subject.SegmentIDCode = "9WG";
        if (segmentPositionInTransactionSet > 0)
            subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}