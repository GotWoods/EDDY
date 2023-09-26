using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class CTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTX**jK*8*7**";

		var expected = new CTX_Context()
		{
			ContextIdentification = null,
			SegmentIDCode = "jK",
			SegmentPositionInTransactionSet = 8,
			LoopIdentifierCode = "7",
			PositionInSegment = null,
			ReferenceInSegment = null,
		};

		var actual = Map.MapObject<CTX_Context>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredContextIdentification(string contextIdentification, bool isValidExpected)
	{
		var subject = new CTX_Context();
		//Required fields
		//Test Parameters
		if (contextIdentification != "") 
			subject.ContextIdentification = new C998_ContextIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
