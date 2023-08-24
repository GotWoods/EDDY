using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK3*kp*9*2*P*p*y*a*F";

		var expected = new AK3_DataSegmentNote()
		{
			SegmentIDCode = "kp",
			SegmentPositionInTransactionSet = 9,
			LoopIdentifierCode = "2",
			SegmentSyntaxErrorCode = "P",
			SegmentSyntaxErrorCode2 = "p",
			SegmentSyntaxErrorCode3 = "y",
			SegmentSyntaxErrorCode4 = "a",
			SegmentSyntaxErrorCode5 = "F",
		};

		var actual = Map.MapObject<AK3_DataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kp", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentPositionInTransactionSet = 9;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new AK3_DataSegmentNote();
		subject.SegmentIDCode = "kp";
		if (segmentPositionInTransactionSet > 0)
		subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
