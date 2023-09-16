using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TED*7*V*6q*4***m*M";

		var expected = new TED_TechnicalErrorDescription()
		{
			ApplicationErrorConditionCode = "7",
			FreeFormMessage = "V",
			SegmentIDCode = "6q",
			SegmentPositionInTransactionSet = 4,
			PositionInSegment = null,
			ReferenceInSegment = null,
			CopyOfBadDataElement = "m",
			DataElementNewContent = "M",
		};

		var actual = Map.MapObject<TED_TechnicalErrorDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new TED_TechnicalErrorDescription();
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
