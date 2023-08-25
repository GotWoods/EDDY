using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class AK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK3*O7*7*6*s";

		var expected = new AK3_DataSegmentNote()
		{
			SegmentIDCode = "O7",
			SegmentPositionInTransactionSet = 7,
			LoopIdentifierCode = "6",
			SegmentSyntaxErrorCode = "s",
		};

		var actual = Map.MapObject<AK3_DataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O7", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentPositionInTransactionSet = 7;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentIDCode = "O7";
		if (segmentPositionInTransactionSet > 0)
		subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}