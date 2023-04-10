using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class CTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTX**34*6*0**";

		var expected = new CTX_Context()
		{
			ContextIdentification = "",
			SegmentIDCode = "34",
			SegmentPositionInTransactionSet = 6,
			LoopIdentifierCode = "0",
			PositionInSegment = "",
			ReferenceInSegment = "",
		};

		var actual = Map.MapObject<CTX_Context>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validatation_RequiredContextIdentification(C998_ContextIdentification contextIdentification, bool isValidExpected)
	{
		var subject = new CTX_Context();
		subject.ContextIdentification = contextIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
