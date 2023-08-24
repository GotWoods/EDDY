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
		string x12Line = "AK4*1*8*I*7";

		var expected = new AK4_DataElementNote()
		{
			ElementPositionInSegment = 1,
			DataElementReferenceNumber = 8,
			DataElementSyntaxErrorCode = "I",
			CopyOfBadDataElement = "7",
		};

		var actual = Map.MapObject<AK4_DataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredElementPositionInSegment(int elementPositionInSegment, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.DataElementSyntaxErrorCode = "I";
		if (elementPositionInSegment > 0)
		subject.ElementPositionInSegment = elementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredDataElementSyntaxErrorCode(string dataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.ElementPositionInSegment = 1;
		subject.DataElementSyntaxErrorCode = dataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
