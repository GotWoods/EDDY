using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK3*w4*1*O*h";

		var expected = new AK3_DataSegmentNote()
		{
			SegmentIDCode = "w4",
			SegmentPositionInTransactionSet = 1,
			LoopIdentifierCode = "O",
			SegmentSyntaxErrorCode = "h",
		};

		var actual = Map.MapObject<AK3_DataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w4", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentPositionInTransactionSet = 1;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentIDCode = "w4";
		if (segmentPositionInTransactionSet > 0)
		subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
