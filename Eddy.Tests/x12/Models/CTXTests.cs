using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTX**34*6*0**";

		var expected = new CTX_Context()
		{
			ContextIdentification = null,
			SegmentIDCode = "34",
			SegmentPositionInTransactionSet = 6,
			LoopIdentifierCode = "0",
			PositionInSegment = null,
			ReferenceInSegment = null,
		};

		var actual = Map.MapObject<CTX_Context>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ab", true)]
	public void Validatation_RequiredContextIdentification(string contextIdentification, bool isValidExpected)
	{
		var subject = new CTX_Context();
		if (contextIdentification != "")
        {
            subject.ContextIdentification = new C998_ContextIdentification() { ContextReference = contextIdentification};
        }
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
