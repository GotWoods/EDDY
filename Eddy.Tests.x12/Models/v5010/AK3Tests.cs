using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class AK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK3*2f*2*v*P";

		var expected = new AK3_DataSegmentNote()
		{
			SegmentIDCode = "2f",
			SegmentPositionInTransactionSet = 2,
			LoopIdentifierCode = "v",
			SegmentSyntaxErrorCode = "P",
		};

		var actual = Map.MapObject<AK3_DataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2f", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentPositionInTransactionSet = 2;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentIDCode = "2f";
		if (segmentPositionInTransactionSet > 0)
		subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
