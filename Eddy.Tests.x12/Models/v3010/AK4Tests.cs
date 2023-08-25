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
		string x12Line = "AK4*4*4*l*z";

		var expected = new AK4_DataElementNote()
		{
			ElementPositionInSegment = 4,
			DataElementReferenceNumber = 4,
			DataElementSyntaxErrorCode = "l",
			CopyOfBadDataElement = "z",
		};

		var actual = Map.MapObject<AK4_DataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredElementPositionInSegment(int elementPositionInSegment, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.DataElementSyntaxErrorCode = "l";
		if (elementPositionInSegment > 0)
		subject.ElementPositionInSegment = elementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredDataElementSyntaxErrorCode(string dataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.ElementPositionInSegment = 4;
		subject.DataElementSyntaxErrorCode = dataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
