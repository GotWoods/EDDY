using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TED*V*0*ZP*6*6*4*f*A";

		var expected = new TED_TechnicalErrorDescription()
		{
			ApplicationErrorConditionCode = "V",
			FreeFormMessage = "0",
			SegmentIDCode = "ZP",
			SegmentPositionInTransactionSet = 6,
			ElementPositionInSegment = 6,
			DataElementReferenceNumber = 4,
			CopyOfBadDataElement = "f",
			DataElementNewContent = "A",
		};

		var actual = Map.MapObject<TED_TechnicalErrorDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new TED_TechnicalErrorDescription();
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
