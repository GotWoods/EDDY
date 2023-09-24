using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK4*8*3*z*D";

		var expected = new AK4_DataElementNote()
		{
			ElementPositionInSegment = 8,
			DataElementReferenceNumber = 3,
			DataElementSyntaxErrorCode = "z",
			CopyOfBadDataElement = "D",
		};

		var actual = Map.MapObject<AK4_DataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredElementPositionInSegment(int elementPositionInSegment, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.DataElementSyntaxErrorCode = "z";
		if (elementPositionInSegment > 0)
			subject.ElementPositionInSegment = elementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDataElementSyntaxErrorCode(string dataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.ElementPositionInSegment = 8;
		subject.DataElementSyntaxErrorCode = dataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
