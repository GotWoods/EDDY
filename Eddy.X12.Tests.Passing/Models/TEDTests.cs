using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TED*W*u*uy*7***r*0";

		var expected = new TED_TechnicalErrorDescription()
		{
			ApplicationErrorConditionCode = "W",
			FreeFormMessage = "u",
			SegmentIDCode = "uy",
			SegmentPositionInTransactionSet = 7,
			PositionInSegment = null,
			ReferenceInSegment = null,
			CopyOfBadDataElement = "r",
			DataElementNewContent = "0",
		};

		var actual = Map.MapObject<TED_TechnicalErrorDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new TED_TechnicalErrorDescription();
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
