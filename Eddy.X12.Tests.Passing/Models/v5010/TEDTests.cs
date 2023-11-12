using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class TEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TED*f*a*UY*4***j*m";

		var expected = new TED_TechnicalErrorDescription()
		{
			ApplicationErrorConditionCode = "f",
			FreeFormMessage = "a",
			SegmentIDCode = "UY",
			SegmentPositionInTransactionSet = 4,
			PositionInSegment = null,
			ReferenceInSegment = null,
			CopyOfBadDataElement = "j",
			DataElementNewContent = "m",
		};

		var actual = Map.MapObject<TED_TechnicalErrorDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new TED_TechnicalErrorDescription();
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
