using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class IK3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK3*Kq*9*Q*w";

		var expected = new IK3_ImplementationDataSegmentNote()
		{
			SegmentIDCode = "Kq",
			SegmentPositionInTransactionSet = 9,
			LoopIdentifierCode = "Q",
			ImplementationSegmentSyntaxErrorCode = "w",
		};

		var actual = Map.MapObject<IK3_ImplementationDataSegmentNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kq", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new IK3_ImplementationDataSegmentNote();
		//Required fields
		subject.SegmentPositionInTransactionSet = 9;
		//Test Parameters
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredSegmentPositionInTransactionSet(int segmentPositionInTransactionSet, bool isValidExpected)
	{
		var subject = new IK3_ImplementationDataSegmentNote();
		//Required fields
		subject.SegmentIDCode = "Kq";
		//Test Parameters
		if (segmentPositionInTransactionSet > 0) 
			subject.SegmentPositionInTransactionSet = segmentPositionInTransactionSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
