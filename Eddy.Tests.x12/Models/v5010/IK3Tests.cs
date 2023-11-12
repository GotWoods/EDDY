using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class IK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK3*DQ*2*4*r";

		var expected = new IK3_ImplementationDataSegmentNote()
		{
			SegmentIDCode = "DQ",
			SegmentPositionInTransactionSet = 2,
			LoopIdentifierCode = "4",
			ImplementationSegmentSyntaxErrorCode = "r",
		};

		var actual = Map.MapObject<IK3_ImplementationDataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DQ", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new IK3_ImplementationDataSegmentNote();
		//Required fields
		subject.SegmentPositionInTransactionSet = 2;
		//Test Parameters
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new IK3_ImplementationDataSegmentNote();
		//Required fields
		subject.SegmentIDCode = "DQ";
		//Test Parameters
		if (segmentPositionInTransactionSet > 0) 
			subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
